using QCM_ManagementSystem.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QCM_Management_System.Forms
{
    public partial class ViewQuestionsForm : Form
    {
        private int qcmId;
        private int selectedQuestionId = -1;

        public ViewQuestionsForm(int qcmId, string qcmTitle)
        {
            InitializeComponent();
            this.qcmId = qcmId;
            lblTitle.Text = $"📋 Questions for: {qcmTitle}";
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            // Defensive: ensure control is initialized
            if (dgvQuestions == null)
            {
                MessageBox.Show("Internal error: dgvQuestions is not initialized.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Unable to obtain a database connection.", "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    conn.Open();

                    string query = @"SELECT 
                                        q.IdQuestion,
                                        q.OrderNumber as '#',
                                        q.QuestionText as 'Question',
                                        (SELECT COUNT(*) FROM Answers WHERE IdQuestion = q.IdQuestion) as 'Total Answers',
                                        (SELECT COUNT(*) FROM Answers WHERE IdQuestion = q.IdQuestion AND IsCorrect = 1) as 'Correct Answers'
                                    FROM Questions q
                                    WHERE q.IdQCM = @QcmId
                                    ORDER BY q.OrderNumber";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@QcmId", qcmId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                // Ensure handle is created before touching column widths (prevents internal NREs)
                var _ = dgvQuestions.Handle;

                dgvQuestions.DataSource = dt;

                // Temporarily disable autosize mode to safely set explicit widths
                var previousMode = dgvQuestions.AutoSizeColumnsMode;
                try
                {
                    dgvQuestions.SuspendLayout();
                    dgvQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    if (dgvQuestions.Columns != null && dgvQuestions.Columns.Count > 0)
                    {
                        DataGridViewColumn col;

                        if (dgvQuestions.Columns.Contains("IdQuestion"))
                        {
                            col = dgvQuestions.Columns["IdQuestion"];
                            if (col != null && col.DataGridView != null)
                                col.Visible = false;
                        }

                        if (dgvQuestions.Columns.Contains("#"))
                        {
                            col = dgvQuestions.Columns["#"];
                            if (col != null && col.DataGridView != null)
                                col.Width = 50;
                        }

                        if (dgvQuestions.Columns.Contains("Question"))
                        {
                            col = dgvQuestions.Columns["Question"];
                            if (col != null && col.DataGridView != null)
                                col.Width = 300;
                        }
                    }
                }
                finally
                {
                    dgvQuestions.AutoSizeColumnsMode = previousMode;
                    dgvQuestions.ResumeLayout();
                }

                lblTotalQuestions.Text = $"Total Questions: {dgvQuestions.Rows.Count} | Select a question to view details";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading questions: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvQuestions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count > 0)
            {
                selectedQuestionId = (int)dgvQuestions.SelectedRows[0].Cells["IdQuestion"].Value;
                string questionText = dgvQuestions.SelectedRows[0].Cells["Question"].Value.ToString();

                // Display question text
                txtQuestionDetail.Text = questionText;

                // Load answers for this question
                LoadAnswers(selectedQuestionId);
            }
        }

        private void LoadAnswers(int questionId)
        {
            // Defensive: ensure control is initialized
            if (dgvAnswers == null)
            {
                MessageBox.Show("Internal error: dgvAnswers is not initialized.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Unable to obtain a database connection.", "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    conn.Open();

                    string query = @"SELECT 
                                        IdAnswer,
                                        AnswerText as 'Answer',
                                        CASE WHEN IsCorrect = 1 THEN 'Yes ✓' ELSE 'No' END as 'Correct?'
                                    FROM Answers
                                    WHERE IdQuestion = @QuestionId
                                    ORDER BY IdAnswer";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@QuestionId", questionId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                // Ensure handle exists before modifying columns
                var _ = dgvAnswers.Handle;

                dgvAnswers.DataSource = dt;

                // Temporarily disable autosize mode to safely set explicit widths
                var previousMode = dgvAnswers.AutoSizeColumnsMode;
                try
                {
                    dgvAnswers.SuspendLayout();
                    dgvAnswers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    if (dgvAnswers.Columns != null && dgvAnswers.Columns.Count > 0)
                    {
                        DataGridViewColumn col;

                        if (dgvAnswers.Columns.Contains("IdAnswer"))
                        {
                            col = dgvAnswers.Columns["IdAnswer"];
                            if (col != null && col.DataGridView != null)
                                col.Visible = false;
                        }

                        if (dgvAnswers.Columns.Contains("Answer"))
                        {
                            col = dgvAnswers.Columns["Answer"];
                            if (col != null && col.DataGridView != null)
                                col.Width = 400;
                        }

                        if (dgvAnswers.Columns.Contains("Correct?"))
                        {
                            col = dgvAnswers.Columns["Correct?"];
                            if (col != null && col.DataGridView != null)
                                col.Width = 100;
                        }
                    }
                }
                finally
                {
                    dgvAnswers.AutoSizeColumnsMode = previousMode;
                    dgvAnswers.ResumeLayout();
                }

                // Highlight correct answers in green (guard against null cell values)
                foreach (DataGridViewRow row in dgvAnswers.Rows)
                {
                    var cell = row.Cells["Correct?"];
                    if (cell != null && cell.Value != null && cell.Value.ToString().Contains("✓"))
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkGreen;
                        row.DefaultCellStyle.Font = new System.Drawing.Font(dgvAnswers.Font, System.Drawing.FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading answers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            if (selectedQuestionId == -1)
            {
                MessageBox.Show("Please select a question to edit", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EditQuestionForm editForm = new EditQuestionForm(selectedQuestionId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadQuestions();
                MessageBox.Show("Question updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (selectedQuestionId == -1)
            {
                MessageBox.Show("Please select a question to delete", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string questionText = txtQuestionDetail.Text;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete this question?\n\n\"{questionText}\"\n\nThis will also delete all its answers!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteQuestion();
            }
        }

        private void DeleteQuestion()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = "DELETE FROM Questions WHERE IdQuestion = @QuestionId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@QuestionId", selectedQuestionId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Question deleted successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            selectedQuestionId = -1;
                            txtQuestionDetail.Clear();
                            dgvAnswers.DataSource = null;
                            LoadQuestions();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting question: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}