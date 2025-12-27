using QCM_Management_System.Models;
using QCM_Management_System.Utils;
using QCM_ManagementSystem.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QCM_Management_System.Forms
{
    public partial class UserDashboard : Form
    {
        private User currentUser;

        public UserDashboard(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadUserInfo();
            LoadActiveQCMs();
            LoadUserResults();
        }

        private void LoadUserInfo()
        {
            lblWelcome.Text = $"Welcome, {currentUser.FullName}!";
        }

        private void LoadActiveQCMs()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT IdQCM, Title, Description 
                                    FROM QCM 
                                    WHERE IsActive = 1 
                                    ORDER BY CreatedAt DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvQCMs.DataSource = dt;

                        if (dgvQCMs.Columns["IdQCM"] != null)
                            dgvQCMs.Columns["IdQCM"].Visible = false;

                        dgvQCMs.Columns["Title"].HeaderText = "QCM Title";
                        dgvQCMs.Columns["Description"].HeaderText = "Description";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading QCMs: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserResults()
        {
            try
            {
                if (dgvResults == null)
                {
                    MessageBox.Show("dgvResults n'existe pas!", "Erreur");
                    return;
                }

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT 
                                        R.IdResult,
                                        Q.Title AS QCMTitle,
                                        R.Score,
                                        R.TotalQuestions,
                                        R.CorrectAnswers,
                                        R.StartTime,
                                        R.EndTime
                                    FROM Results R
                                    INNER JOIN QCM Q ON R.IdQCM = Q.IdQCM
                                    WHERE R.IdUser = @IdUser
                                    ORDER BY R.IdResult DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUser", currentUser.IdUser);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Columns.Add("IdResult", typeof(int));
                            dt.Columns.Add("QCM", typeof(string));
                            dt.Columns.Add("Score (%)", typeof(string));
                            dt.Columns.Add("Questions", typeof(int));
                            dt.Columns.Add("Correct", typeof(int));
                            dt.Columns.Add("Date", typeof(string));
                            dt.Columns.Add("Time", typeof(string));

                            while (reader.Read())
                            {
                                DataRow row = dt.NewRow();

                                row["IdResult"] = reader["IdResult"];
                                row["QCM"] = reader["QCMTitle"];
                                row["Score (%)"] = ((decimal)reader["Score"]).ToString("0.0");
                                row["Questions"] = reader["TotalQuestions"];
                                row["Correct"] = reader["CorrectAnswers"];

                                if (reader["StartTime"] != DBNull.Value)
                                {
                                    DateTime startTime = (DateTime)reader["StartTime"];
                                    row["Date"] = startTime.ToString("dd/MM/yyyy HH:mm");

                                    if (reader["EndTime"] != DBNull.Value)
                                    {
                                        DateTime endTime = (DateTime)reader["EndTime"];
                                        TimeSpan duration = endTime - startTime;
                                        row["Time"] = $"{(int)duration.TotalMinutes:D2}:{duration.Seconds:D2}";
                                    }
                                    else
                                    {
                                        row["Time"] = "N/A";
                                    }
                                }
                                else
                                {
                                    row["Date"] = "N/A";
                                    row["Time"] = "N/A";
                                }

                                dt.Rows.Add(row);
                            }

                            dgvResults.DataSource = dt;

                            if (dgvResults.Columns["IdResult"] != null)
                                dgvResults.Columns["IdResult"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading results:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTakeQCM_Click(object sender, EventArgs e)
        {
            if (dgvQCMs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a QCM to take.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedQCMId = Convert.ToInt32(dgvQCMs.SelectedRows[0].Cells["IdQCM"].Value);

            TakeQCMForm takeQCMForm = new TakeQCMForm(currentUser, selectedQCMId);
            takeQCMForm.ShowDialog();

            LoadActiveQCMs();
            LoadUserResults();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a result to view details.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int resultId = Convert.ToInt32(dgvResults.SelectedRows[0].Cells["IdResult"].Value);
            LoadResultDetails(resultId);
        }

        // ✅ NOUVELLE MÉTHODE : Supprimer un résultat
        private void btnDeleteResult_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a result to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this result?\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                int resultId = Convert.ToInt32(dgvResults.SelectedRows[0].Cells["IdResult"].Value);
                DeleteResult(resultId);
            }
        }

        private void DeleteResult(int resultId)
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
                            // Supprimer d'abord les réponses utilisateur
                            string deleteResponses = "DELETE FROM UserResponses WHERE IdResult = @IdResult";
                            using (SqlCommand cmd = new SqlCommand(deleteResponses, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@IdResult", resultId);
                                cmd.ExecuteNonQuery();
                            }

                            // Ensuite supprimer le résultat
                            string deleteResult = "DELETE FROM Results WHERE IdResult = @IdResult";
                            using (SqlCommand cmd = new SqlCommand(deleteResult, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@IdResult", resultId);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    trans.Commit();
                                    MessageBox.Show("Result deleted successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    LoadUserResults();
                                }
                                else
                                {
                                    trans.Rollback();
                                    MessageBox.Show("Result not found or already deleted.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show($"Error during deletion:\n{ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadResultDetails(int resultId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string queryResult = @"SELECT R.IdQCM, R.Score, R.StartTime, R.EndTime 
                                          FROM Results R WHERE R.IdResult = @IdResult";

                    int qcmId = 0;
                    decimal score = 0;
                    DateTime startTime = DateTime.Now;
                    DateTime endTime = DateTime.Now;

                    using (SqlCommand cmd = new SqlCommand(queryResult, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdResult", resultId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                qcmId = (int)reader["IdQCM"];
                                score = (decimal)reader["Score"];

                                if (reader["StartTime"] != DBNull.Value)
                                    startTime = (DateTime)reader["StartTime"];
                                else
                                    startTime = DateTime.Now;

                                if (reader["EndTime"] != DBNull.Value)
                                    endTime = (DateTime)reader["EndTime"];
                                else
                                    endTime = DateTime.Now;
                            }
                            else
                            {
                                MessageBox.Show("Result not found!", "Error");
                                return;
                            }
                        }
                    }

                    var questions = LoadQuestionsForResult(qcmId, conn);
                    var userAnswers = LoadUserAnswersForResult(resultId, conn);

                    TimeSpan timeTaken = endTime - startTime;

                    ResultDetailsForm detailsForm = new ResultDetailsForm(questions, userAnswers, score, timeTaken);
                    detailsForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading result details:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private System.Collections.Generic.List<Question> LoadQuestionsForResult(int qcmId, SqlConnection conn)
        {
            var questions = new System.Collections.Generic.List<Question>();

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

            foreach (var q in questions)
            {
                q.Answers = LoadAnswersForQuestion(q.IdQuestion, conn);
            }

            return questions;
        }

        private System.Collections.Generic.List<Answer> LoadAnswersForQuestion(int questionId, SqlConnection conn)
        {
            var answers = new System.Collections.Generic.List<Answer>();

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

        private System.Collections.Generic.Dictionary<int, int> LoadUserAnswersForResult(int resultId, SqlConnection conn)
        {
            var userAnswers = new System.Collections.Generic.Dictionary<int, int>();

            string query = "SELECT IdQuestion, IdAnswer FROM UserResponses WHERE IdResult = @IdResult";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IdResult", resultId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int questionId = (int)reader["IdQuestion"];
                        int answerId = (int)reader["IdAnswer"];
                        userAnswers[questionId] = answerId;
                    }
                }
            }
            return userAnswers;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            MessageBox.Show("You have been logged out.", "Logout",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoginForm loginForm = new LoginForm();
            this.Close();
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
        }
    }
}