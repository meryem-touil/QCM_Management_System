using QCM_Management_System.Models;
using QCM_Management_System.Utils;
using QCM_ManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QCM_Management_System.Forms
{
    public partial class TakeQCMForm : Form
    {
        private User currentUser;
        private int qcmId;
        private string qcmTitle;
        private int durationMinutes; // Duration from database
        private List<Question> questions;
        private Dictionary<int, int> userAnswers;
        private int currentQuestionIndex = 0;
        private DateTime startTime;
        private DateTime endTime; // When QCM should end
        private int remainingSeconds; // For countdown

        public TakeQCMForm(User user, int qcmId)
        {
            InitializeComponent();

            this.currentUser = user;
            this.qcmId = qcmId;
            this.userAnswers = new Dictionary<int, int>();

            LoadQCMInfo(); // Load title and duration
            this.startTime = DateTime.Now;
            this.endTime = startTime.AddMinutes(durationMinutes);
            this.remainingSeconds = durationMinutes * 60;

            LoadQCMQuestions();
            DisplayQuestion();

            timerQCM.Start(); // Start countdown timer
        }

        private void LoadQCMInfo()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Title, Duration FROM QCM WHERE IdQCM = @QcmId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@QcmId", qcmId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                qcmTitle = reader["Title"].ToString();
                                durationMinutes = (int)reader["Duration"];

                                lblTitle.Text = $"QCM: {qcmTitle}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading QCM info: " + ex.Message, "Error");
                this.Close();
            }
        }

        private void TimerQCM_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;

            if (remainingSeconds <= 0)
            {
                // Time's up! Auto-submit
                timerQCM.Stop();
                MessageBox.Show("Time's up! Your QCM will be submitted automatically.",
                    "Time Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SubmitQCM();
                return;
            }

            // Update timer display (countdown)
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;
            lblTimer.Text = $"Time Left: {minutes:D2}:{seconds:D2}";

            // Change color when less than 2 minutes remaining
            if (remainingSeconds <= 120) // 2 minutes
            {
                lblTimer.ForeColor = Color.Red;

                // Flash warning at 1 minute
                if (remainingSeconds == 60)
                {
                    MessageBox.Show("⚠ Only 1 minute remaining!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (remainingSeconds <= 300) // 5 minutes
            {
                lblTimer.ForeColor = Color.Orange;
            }
            else
            {
                lblTimer.ForeColor = Color.Green;
            }
        }

        private void LoadQCMQuestions()
        {
            questions = new List<Question>();
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT IdQuestion, QuestionText FROM Questions WHERE IdQCM = @IdQCM ORDER BY OrderNumber";
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
                    foreach (var q in questions)
                        q.Answers = LoadAnswersForQuestion(q.IdQuestion, conn);
                }

                if (questions.Count == 0)
                {
                    MessageBox.Show("No questions found.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                this.Close();
            }
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
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10)
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
            if (currentQuestionIndex == questions.Count - 1)
            {
                // Ask for confirmation before submitting
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to submit your QCM?\n\nYou cannot change your answers after submission.",
                    "Confirm Submission",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SubmitQCM();
                }
            }
            else
            {
                currentQuestionIndex++;
                DisplayQuestion();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                DisplayQuestion();
            }
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
            DateTime actualEndTime = DateTime.Now;

            // Calculate actual time taken (could be less than duration if submitted early)
            TimeSpan actualTimeTaken = actualEndTime - startTime;

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
                else
                {
                    // Question not answered
                    results.Add(new
                    {
                        QuestionId = q.IdQuestion,
                        AnswerId = (int?)null,
                        IsCorrect = false
                    });
                }
            }

            decimal score = (questions.Count > 0) ? (decimal)correctCount * 100 / questions.Count : 0;
            SaveResultToDatabase(score, questions.Count, correctCount, results, startTime, actualEndTime);

            // Show quick summary
            MessageBox.Show(
                $"QCM Submitted Successfully!\n\n" +
                $"Score: {correctCount}/{questions.Count} ({score:F1}%)\n" +
                $"Time Taken: {actualTimeTaken:mm\\:ss}\n" +
                $"Duration: {durationMinutes} minutes",
                "QCM Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Open detailed results
            ResultDetailsForm resultForm = new ResultDetailsForm(questions, userAnswers, score, actualTimeTaken);
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
                            // Insert main result
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

                            // Insert user responses
                            foreach (var r in details)
                            {
                                // Save even if not answered (AnswerId will be null)
                                string sqlAns = "INSERT INTO UserResponses (IdResult, IdQuestion, IdAnswer, IsCorrect) VALUES (@r, @q, @a, @ic)";
                                using (SqlCommand cmd = new SqlCommand(sqlAns, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@r", resId);
                                    cmd.Parameters.AddWithValue("@q", r.QuestionId);
                                    cmd.Parameters.AddWithValue("@a", r.AnswerId ?? (object)DBNull.Value);
                                    cmd.Parameters.AddWithValue("@ic", r.IsCorrect);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            trans.Commit();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }

        private void TakeQCMForm_Load(object sender, EventArgs e) { }

        private void TakeQCMForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Warn if trying to close without submitting
            if (timerQCM.Enabled)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to exit?\n\nYour progress will be lost!",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}