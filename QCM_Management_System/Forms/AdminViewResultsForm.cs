using QCM_Management_System.Models;
using QCM_ManagementSystem.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QCM_Management_System.Forms
{
    public partial class AdminViewResultsForm : Form
    {
        private User currentUser;

        public AdminViewResultsForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadQCMsForFilter();
            LoadAllResults();
        }

        private void LoadQCMsForFilter()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Load only QCMs created by this admin
                    string query = @"SELECT IdQCM, Title FROM QCM 
                                    WHERE CreatedBy = @AdminId 
                                    ORDER BY Title";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AdminId", currentUser.IdUser);

                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        // Add "All QCMs" option
                        DataRow allRow = dt.NewRow();
                        allRow["IdQCM"] = 0;
                        allRow["Title"] = "-- All My QCMs --";
                        dt.Rows.InsertAt(allRow, 0);

                        cmbFilterQCM.DisplayMember = "Title";
                        cmbFilterQCM.ValueMember = "IdQCM";
                        cmbFilterQCM.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading QCMs: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllResults()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT 
                                        r.IdResult,
                                        q.Title as 'QCM Title',
                                        u.FullName as 'full Name',
                                        u.Username as 'Username',
                                        r.Score as 'Score (%)',
                                        r.CorrectAnswers as 'Correct',
                                        r.TotalQuestions as 'Total',
                                        r.StartTime as 'Date Taken',
                                        DATEDIFF(SECOND, r.StartTime, r.EndTime) as 'Duration (sec)'
                                    FROM Results r
                                    INNER JOIN QCM q ON r.IdQCM = q.IdQCM
                                    INNER JOIN Users u ON r.IdUser = u.IdUser
                                    WHERE q.CreatedBy = @AdminId
                                    ORDER BY r.StartTime DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AdminId", currentUser.IdUser);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvResults.DataSource = dt;

                        // Hide IdResult column
                        if (dgvResults.Columns["IdResult"] != null)
                        {
                            dgvResults.Columns["IdResult"].Visible = false;
                        }

                        // Format Date column
                        if (dgvResults.Columns["Date Taken"] != null)
                        {
                            dgvResults.Columns["Date Taken"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                        }

                        // Format Score column
                        if (dgvResults.Columns["Score (%)"] != null)
                        {
                            dgvResults.Columns["Score (%)"].DefaultCellStyle.Format = "0.00";
                        }
                    }
                }

                lblTotalResults.Text = $"Total Results: {dgvResults.Rows.Count}";
                ColorCodeScores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading results: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadResultsByQCM(int qcmId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT 
                                        r.IdResult,
                                        q.Title as 'QCM Title',
                                        u.FullName as 'Full Name',
                                        u.Username as 'Username',
                                        r.Score as 'Score (%)',
                                        r.CorrectAnswers as 'Correct',
                                        r.TotalQuestions as 'Total',
                                        r.StartTime as 'Date Taken',
                                        DATEDIFF(SECOND, r.StartTime, r.EndTime) as 'Duration (sec)'
                                    FROM Results r
                                    INNER JOIN QCM q ON r.IdQCM = q.IdQCM
                                    INNER JOIN Users u ON r.IdUser = u.IdUser
                                    WHERE q.IdQCM = @QcmId AND q.CreatedBy = @AdminId
                                    ORDER BY r.StartTime DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@QcmId", qcmId);
                        cmd.Parameters.AddWithValue("@AdminId", currentUser.IdUser);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvResults.DataSource = dt;

                        // Hide IdResult
                        if (dgvResults.Columns["IdResult"] != null)
                        {
                            dgvResults.Columns["IdResult"].Visible = false;
                        }

                        // Format columns
                        if (dgvResults.Columns["Date Taken"] != null)
                        {
                            dgvResults.Columns["Date Taken"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                        }

                        if (dgvResults.Columns["Score (%)"] != null)
                        {
                            dgvResults.Columns["Score (%)"].DefaultCellStyle.Format = "0.00";
                        }
                    }
                }

                lblTotalResults.Text = $"Total Results: {dgvResults.Rows.Count}";
                ColorCodeScores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading results: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorCodeScores()
        {
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                if (row.Cells["Score (%)"].Value != null)
                {
                    decimal score = Convert.ToDecimal(row.Cells["Score (%)"].Value);

                    if (score >= 80)
                    {
                        row.Cells["Score (%)"].Style.BackColor = System.Drawing.Color.LightGreen;
                        row.Cells["Score (%)"].Style.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                    else if (score >= 50)
                    {
                        row.Cells["Score (%)"].Style.BackColor = System.Drawing.Color.LightYellow;
                        row.Cells["Score (%)"].Style.ForeColor = System.Drawing.Color.DarkOrange;
                    }
                    else
                    {
                        row.Cells["Score (%)"].Style.BackColor = System.Drawing.Color.LightPink;
                        row.Cells["Score (%)"].Style.ForeColor = System.Drawing.Color.DarkRed;
                    }

                    row.Cells["Score (%)"].Style.Font =
                        new System.Drawing.Font(dgvResults.Font, System.Drawing.FontStyle.Bold);
                }
            }
        }

        private void cmbFilterQCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterQCM.SelectedValue != null)
            {
                int qcmId = Convert.ToInt32(cmbFilterQCM.SelectedValue);

                if (qcmId == 0)
                {
                    LoadAllResults();
                }
                else
                {
                    LoadResultsByQCM(qcmId);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbFilterQCM.SelectedValue != null && Convert.ToInt32(cmbFilterQCM.SelectedValue) == 0)
            {
                LoadAllResults();
            }
            else if (cmbFilterQCM.SelectedValue != null)
            {
                LoadResultsByQCM(Convert.ToInt32(cmbFilterQCM.SelectedValue));
            }

            MessageBox.Show("Results refreshed!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a result to view details", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int resultId = (int)dgvResults.SelectedRows[0].Cells["IdResult"].Value;

            // Load the result details
            LoadResultDetails(resultId);
        }

        private void LoadResultDetails(int resultId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Get result info
                    string resultQuery = @"SELECT r.IdQCM, r.IdUser, r.Score, r.StartTime, r.EndTime
                                          FROM Results r
                                          WHERE r.IdResult = @ResultId";

                    int qcmId = 0;
                    int userId = 0;
                    decimal score = 0;
                    DateTime startTime = DateTime.Now;
                    DateTime endTime = DateTime.Now;

                    using (SqlCommand cmd = new SqlCommand(resultQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ResultId", resultId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                qcmId = (int)reader["IdQCM"];
                                userId = (int)reader["IdUser"];
                                score = (decimal)reader["Score"];
                                startTime = (DateTime)reader["StartTime"];
                                endTime = reader["EndTime"] != DBNull.Value ? (DateTime)reader["EndTime"] : startTime;
                            }
                        }
                    }

                    // Load questions
                    var questions = LoadQuestionsForResult(qcmId, conn);

                    // Load user answers
                    var userAnswers = LoadUserAnswersForResult(resultId, conn);

                    TimeSpan timeTaken = endTime - startTime;

                    // Open the same ResultDetailsForm that users see
                    ResultDetailsForm detailsForm = new ResultDetailsForm(questions, userAnswers, score, timeTaken);
                    detailsForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading result details: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private System.Collections.Generic.List<Question> LoadQuestionsForResult(int qcmId, SqlConnection conn)
        {
            var questions = new System.Collections.Generic.List<Question>();

            string query = "SELECT IdQuestion, QuestionText FROM Questions WHERE IdQCM = @QcmId ORDER BY OrderNumber";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@QcmId", qcmId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var question = new Question
                        {
                            IdQuestion = (int)reader["IdQuestion"],
                            QuestionText = reader["QuestionText"].ToString(),
                            Answers = new System.Collections.Generic.List<Answer>()
                        };

                        questions.Add(question);
                    }
                }
            }

            // Load answers for each question
            foreach (var question in questions)
            {
                string answerQuery = "SELECT IdAnswer, AnswerText, IsCorrect FROM Answers WHERE IdQuestion = @QuestionId";

                using (SqlCommand cmd = new SqlCommand(answerQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@QuestionId", question.IdQuestion);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            question.Answers.Add(new Answer
                            {
                                IdAnswer = (int)reader["IdAnswer"],
                                AnswerText = reader["AnswerText"].ToString(),
                                IsCorrect = (bool)reader["IsCorrect"]
                            });
                        }
                    }
                }
            }

            return questions;
        }

        private System.Collections.Generic.Dictionary<int, int> LoadUserAnswersForResult(int resultId, SqlConnection conn)
        {
            var userAnswers = new System.Collections.Generic.Dictionary<int, int>();

            string query = "SELECT IdQuestion, IdAnswer FROM UserResponses WHERE IdResult = @ResultId AND IdAnswer IS NOT NULL";  // ← Added check for NULL

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ResultId", resultId);

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}