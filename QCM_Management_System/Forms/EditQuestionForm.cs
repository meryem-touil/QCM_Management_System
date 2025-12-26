using QCM_ManagementSystem.DataAccess;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QCM_Management_System.Forms
{
    public partial class EditQuestionForm : Form
    {
        private int questionId;
        private int[] answerIds = new int[4];

        public EditQuestionForm(int questionId)
        {
            InitializeComponent();
            this.questionId = questionId;
            LoadQuestionData();
        }

        private void LoadQuestionData()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Load question text
                    string questionQuery = "SELECT QuestionText FROM Questions WHERE IdQuestion = @QuestionId";
                    using (SqlCommand cmd = new SqlCommand(questionQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@QuestionId", questionId);
                        txtQuestion.Text = cmd.ExecuteScalar()?.ToString();
                    }

                    // Load answers
                    string answersQuery = "SELECT IdAnswer, AnswerText, IsCorrect FROM Answers WHERE IdQuestion = @QuestionId ORDER BY IdAnswer";
                    using (SqlCommand cmd = new SqlCommand(answersQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@QuestionId", questionId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int index = 0;
                            while (reader.Read() && index < 4)
                            {
                                answerIds[index] = (int)reader["IdAnswer"];
                                string answerText = reader["AnswerText"].ToString();
                                bool isCorrect = (bool)reader["IsCorrect"];

                                switch (index)
                                {
                                    case 0:
                                        txtAnswer1.Text = answerText;
                                        radioAnswer1.Checked = isCorrect;
                                        break;
                                    case 1:
                                        txtAnswer2.Text = answerText;
                                        radioAnswer2.Checked = isCorrect;
                                        break;
                                    case 2:
                                        txtAnswer3.Text = answerText;
                                        radioAnswer3.Checked = isCorrect;
                                        break;
                                    case 3:
                                        txtAnswer4.Text = answerText;
                                        radioAnswer4.Checked = isCorrect;
                                        break;
                                }
                                index++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading question: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Please enter the question text", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuestion.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAnswer1.Text) ||
                string.IsNullOrWhiteSpace(txtAnswer2.Text) ||
                string.IsNullOrWhiteSpace(txtAnswer3.Text) ||
                string.IsNullOrWhiteSpace(txtAnswer4.Text))
            {
                MessageBox.Show("Please fill in all four answers", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!radioAnswer1.Checked && !radioAnswer2.Checked &&
                !radioAnswer3.Checked && !radioAnswer4.Checked)
            {
                MessageBox.Show("Please select the correct answer", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Update question text
                        string questionQuery = "UPDATE Questions SET QuestionText = @QuestionText WHERE IdQuestion = @QuestionId";
                        using (SqlCommand cmd = new SqlCommand(questionQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@QuestionText", txtQuestion.Text.Trim());
                            cmd.Parameters.AddWithValue("@QuestionId", questionId);
                            cmd.ExecuteNonQuery();
                        }

                        // Update answers
                        UpdateAnswer(conn, transaction, answerIds[0], txtAnswer1.Text.Trim(), radioAnswer1.Checked);
                        UpdateAnswer(conn, transaction, answerIds[1], txtAnswer2.Text.Trim(), radioAnswer2.Checked);
                        UpdateAnswer(conn, transaction, answerIds[2], txtAnswer3.Text.Trim(), radioAnswer3.Checked);
                        UpdateAnswer(conn, transaction, answerIds[3], txtAnswer4.Text.Trim(), radioAnswer4.Checked);

                        transaction.Commit();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Transaction failed: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAnswer(SqlConnection conn, SqlTransaction transaction, int answerId, string answerText, bool isCorrect)
        {
            string query = "UPDATE Answers SET AnswerText = @AnswerText, IsCorrect = @IsCorrect WHERE IdAnswer = @AnswerId";
            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@AnswerText", answerText);
                cmd.Parameters.AddWithValue("@IsCorrect", isCorrect);
                cmd.Parameters.AddWithValue("@AnswerId", answerId);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}