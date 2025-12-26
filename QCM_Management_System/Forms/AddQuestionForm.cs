using QCM_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QCM_Management_System.Forms
{
    public partial class AddQuestionForm : Form
    {
        public Question Question { get; private set; }

        public AddQuestionForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
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

            // Create Question object
            Question = new Question
            {
                QuestionText = txtQuestion.Text.Trim(),
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        AnswerText = txtAnswer1.Text.Trim(),
                        IsCorrect = radioAnswer1.Checked
                    },
                    new Answer
                    {
                        AnswerText = txtAnswer2.Text.Trim(),
                        IsCorrect = radioAnswer2.Checked
                    },
                    new Answer
                    {
                        AnswerText = txtAnswer3.Text.Trim(),
                        IsCorrect = radioAnswer3.Checked
                    },
                    new Answer
                    {
                        AnswerText = txtAnswer4.Text.Trim(),
                        IsCorrect = radioAnswer4.Checked
                    }
                }
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}