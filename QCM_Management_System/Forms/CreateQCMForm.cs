using QCM_Management_System.Models;
using QCM_ManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QCM_Management_System.Forms
{
    public partial class CreateQCMForm : Form
    {
        private User currentUser;
        private List<Question> questions = new List<Question>();

        public CreateQCMForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            AddQuestionForm questionForm = new AddQuestionForm();

            if (questionForm.ShowDialog() == DialogResult.OK)
            {
                questions.Add(questionForm.Question);
                UpdateQuestionsList();
            }
        }

        private void UpdateQuestionsList()
        {
            lstQuestions.Items.Clear();

            for (int i = 0; i < questions.Count; i++)
            {
                lstQuestions.Items.Add($"Q{i + 1}: {questions[i].QuestionText}");
            }
        }

        private void btnRemoveQuestion_Click(object sender, EventArgs e)
        {
            if (lstQuestions.SelectedIndex >= 0)
            {
                questions.RemoveAt(lstQuestions.SelectedIndex);
                UpdateQuestionsList();
            }
            else
            {
                MessageBox.Show("Please select a question to remove", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter QCM title", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            if (questions.Count == 0)
            {
                MessageBox.Show("Please add at least one question", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if all questions have answers
            foreach (var question in questions)
            {
                if (question.Answers.Count == 0)
                {
                    MessageBox.Show("All questions must have answers", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool hasCorrectAnswer = false;
                foreach (var answer in question.Answers)
                {
                    if (answer.IsCorrect)
                    {
                        hasCorrectAnswer = true;
                        break;
                    }
                }

                if (!hasCorrectAnswer)
                {
                    MessageBox.Show("Each question must have at least one correct answer", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            SaveQCM();
        }

        private void SaveQCM()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Insert QCM
                        string qcmQuery = @"INSERT INTO QCM (Title, Description, Duration, CreatedBy) 
                                           OUTPUT INSERTED.IdQCM
                                           VALUES (@Title, @Description, @Duration, @CreatedBy)";

                        int qcmId;
                        using (SqlCommand cmd = new SqlCommand(qcmQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@Description",
                                string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@Duration", numDuration.Value);
                            cmd.Parameters.AddWithValue("@CreatedBy", currentUser.IdUser);

                            qcmId = (int)cmd.ExecuteScalar();
                        }

                        // 2. Insert Questions and Answers
                        int orderNumber = 1;
                        foreach (var question in questions)
                        {
                            // Insert question
                            string questionQuery = @"INSERT INTO Questions (QuestionText, IdQCM, OrderNumber) 
                                                    OUTPUT INSERTED.IdQuestion
                                                    VALUES (@QuestionText, @IdQCM, @OrderNumber)";

                            int questionId;
                            using (SqlCommand cmd = new SqlCommand(questionQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                                cmd.Parameters.AddWithValue("@IdQCM", qcmId);
                                cmd.Parameters.AddWithValue("@OrderNumber", orderNumber++);

                                questionId = (int)cmd.ExecuteScalar();
                            }

                            // Insert answers
                            foreach (var answer in question.Answers)
                            {
                                string answerQuery = @"INSERT INTO Answers (AnswerText, IsCorrect, IdQuestion) 
                                                      VALUES (@AnswerText, @IsCorrect, @IdQuestion)";

                                using (SqlCommand cmd = new SqlCommand(answerQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@AnswerText", answer.AnswerText);
                                    cmd.Parameters.AddWithValue("@IsCorrect", answer.IsCorrect);
                                    cmd.Parameters.AddWithValue("@IdQuestion", questionId);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();

                        MessageBox.Show("QCM created successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Error creating QCM: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel? All unsaved data will be lost.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}