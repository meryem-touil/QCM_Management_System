using QCM_Management_System.Models;
using QCM_Management_System.Utils;
using QCM_ManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace QCM_Management_System.Forms
{
    public partial class TakeQCMForm : Form
    {
        private User currentUser;
        private int qcmId;
        private List<Question> questions;
        private Dictionary<int, int> userAnswers;
        private int currentQuestionIndex = 0;
        private DateTime startTime;

        public TakeQCMForm(User user, int qcmId)
        {
            InitializeComponent(); 

            this.currentUser = user;
            this.qcmId = qcmId;
            this.userAnswers = new Dictionary<int, int>();

            this.startTime = DateTime.Now;
            timerQCM.Start(); // Démarre le timer

            LoadQCMQuestions();
            DisplayQuestion();
        }

        private void TimerQCM_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            lblTimer.Text = $"Time: {elapsed:mm\\:ss}";
        }

        private void LoadQCMQuestions()
        {
            questions = new List<Question>();
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT IdQuestion, QuestionText FROM Questions WHERE IdQCM = @IdQCM ORDER BY IdQuestion";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdQCM", qcmId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                questions.Add(new Question
                                {
                                    IdQuestion = (int)reader["IdQuestion"],
                                    QuestionText = reader["QuestionText"].ToString()
                                });
                            }
                        }
                    }
                    foreach (var q in questions) q.Answers = LoadAnswersForQuestion(q.IdQuestion, conn);
                }
                if (questions.Count == 0) { MessageBox.Show("No questions found."); this.Close(); }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); this.Close(); }
        }

        private List<Answer> LoadAnswersForQuestion(int questionId, SqlConnection conn)
        {
            List<Answer> answers = new List<Answer>();
            string query = "SELECT IdAnswer, AnswerText, IsCorrect FROM Answers WHERE IdQuestion = @IdQuestion";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IdQuestion", questionId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        answers.Add(new Answer
                        {
                            IdAnswer = (int)reader["IdAnswer"],
                            AnswerText = reader["AnswerText"].ToString(),
                            IsCorrect = (bool)reader["IsCorrect"]
                        });
                    }
                }
            }
            return answers;
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex >= questions.Count) return;

            Question q = questions[currentQuestionIndex];
            lblQuestionNumber.Text = $"Question {currentQuestionIndex + 1} / {questions.Count}";
            lblQuestionText.Text = q.QuestionText;
            panelAnswers.Controls.Clear();

            int y = 10;
            foreach (var ans in q.Answers)
            {
                RadioButton rb = new RadioButton
                {
                    Text = ans.AnswerText,
                    Tag = ans.IdAnswer,
                    Location = new Point(10, y),
                    Width = 550,
                    AutoSize = true
                };
                if (userAnswers.ContainsKey(q.IdQuestion) && userAnswers[q.IdQuestion] == ans.IdAnswer)
                    rb.Checked = true;

                panelAnswers.Controls.Add(rb);
                y += 40;
            }
            btnPrevious.Enabled = currentQuestionIndex > 0;
            btnNext.Text = (currentQuestionIndex == questions.Count - 1) ? "Submit" : "Next";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();
            if (currentQuestionIndex == questions.Count - 1) SubmitQCM();
            else { currentQuestionIndex++; DisplayQuestion(); }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();
            if (currentQuestionIndex > 0) { currentQuestionIndex--; DisplayQuestion(); }
        }

        private void SaveCurrentAnswer()
        {
            foreach (Control c in panelAnswers.Controls)
            {
                if (c is RadioButton rb && rb.Checked)
                {
                    userAnswers[questions[currentQuestionIndex].IdQuestion] = (int)rb.Tag;
                    return;
                }
            }
        }

        private void SubmitQCM()
        {
            timerQCM.Stop();
            DateTime endTime = DateTime.Now;
            TimeSpan totalTime = endTime - startTime;
            int correctCount = 0;
            var results = new List<dynamic>();

            foreach (var q in questions)
            {
                if (userAnswers.TryGetValue(q.IdQuestion, out int ansId))
                {
                    bool isCorrect = q.Answers.Any(a => a.IdAnswer == ansId && a.IsCorrect);
                    if (isCorrect) correctCount++;

                    results.Add(new
                    {
                        QuestionId = q.IdQuestion,
                        AnswerId = (int?)ansId,
                        IsCorrect = isCorrect
                    });
                }
            }

            decimal score = (questions.Count > 0) ? (decimal)correctCount * 100 / questions.Count : 0;
            SaveResultToDatabase(score, questions.Count, correctCount, results, startTime, endTime);

            //  Afficher un message rapide
            MessageBox.Show($"QCM terminé!\nScore: {correctCount}/{questions.Count} ({score:F1}%)\nTemps: {totalTime:mm\\:ss}");

            //  Ouvrir le formulaire des résultats détaillés
            ResultDetailsForm resultForm = new ResultDetailsForm(questions, userAnswers, score, totalTime);
            resultForm.ShowDialog();

            this.Close();
        }

        private void SaveResultToDatabase(decimal score, int totalQ, int correctA, IEnumerable<dynamic> details, DateTime start, DateTime end)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            // Insertion du résultat principal
                            string sqlRes = @"INSERT INTO Results (IdUser, IdQCM, Score, TotalQuestions, CorrectAnswers, StartTime, EndTime) 
                                    VALUES (@u, @q, @s, @t, @c, @st, @et); SELECT SCOPE_IDENTITY();";

                            int resId;
                            using (SqlCommand cmd = new SqlCommand(sqlRes, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@u", currentUser.IdUser);
                                cmd.Parameters.AddWithValue("@q", qcmId);
                                cmd.Parameters.AddWithValue("@s", score);
                                cmd.Parameters.AddWithValue("@t", totalQ);
                                cmd.Parameters.AddWithValue("@c", correctA);
                                cmd.Parameters.AddWithValue("@st", start);
                                cmd.Parameters.AddWithValue("@et", end);
                                resId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            foreach (var r in details)
                            {
                                //  Ne sauvegarder que si l'utilisateur a répondu
                                if (r.AnswerId != null)
                                {
                                    string sqlAns = "INSERT INTO UserResponses (IdResult, IdQuestion, IdAnswer, IsCorrect) VALUES (@r, @q, @a, @ic)";
                                    using (SqlCommand cmd = new SqlCommand(sqlAns, conn, trans))
                                    {
                                        cmd.Parameters.AddWithValue("@r", resId);
                                        cmd.Parameters.AddWithValue("@q", r.QuestionId);
                                        cmd.Parameters.AddWithValue("@a", r.AnswerId);
                                        cmd.Parameters.AddWithValue("@ic", r.IsCorrect);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                // Si AnswerId est null, on ne fait rien (question non répondue)
                            }
                            trans.Commit();
                        }
                        catch { trans.Rollback(); throw; }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message); }
        }
        private void TakeQCMForm_Load(object sender, EventArgs e) { }
    }
}