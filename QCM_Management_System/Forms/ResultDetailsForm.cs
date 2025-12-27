using QCM_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QCM_Management_System.Forms
{
    public partial class ResultDetailsForm : Form
    {
        private List<Question> questions;
        private Dictionary<int, int> userAnswers;
        private decimal score;
        private TimeSpan timeTaken;

        public ResultDetailsForm(List<Question> questions, Dictionary<int, int> userAnswers, decimal score, TimeSpan timeTaken)
        {
            InitializeComponent();
            this.questions = questions;
            this.userAnswers = userAnswers;
            this.score = score;
            this.timeTaken = timeTaken;

            DisplayResults();
        }

        private void DisplayResults()
        {
            // Afficher le résumé en haut
            int correctCount = 0;
            foreach (var q in questions)
            {
                if (userAnswers.TryGetValue(q.IdQuestion, out int ansId))
                {
                    if (q.Answers.Any(a => a.IdAnswer == ansId && a.IsCorrect))
                        correctCount++;
                }
            }

            lblSummary.Text = $"Score: {correctCount}/{questions.Count} ({score:F1}%) - Time: {timeTaken:mm\\:ss}";

            // Afficher toutes les questions avec réponses
            int yPos = 10;
            foreach (var q in questions)
            {
                // Panel pour chaque question
                Panel questionPanel = new Panel
                {
                    Location = new Point(10, yPos),
                    Width = panelResults.Width - 30,
                    AutoSize = true,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10)
                };

                // Vérifier si l'utilisateur a répondu et si c'est correct
                bool answered = userAnswers.TryGetValue(q.IdQuestion, out int userAnswerId);
                bool isCorrect = answered && q.Answers.Any(a => a.IdAnswer == userAnswerId && a.IsCorrect);

                // Numéro et texte de la question
                Label lblQuestion = new Label
                {
                    Text = $"Q{questions.IndexOf(q) + 1}: {q.QuestionText}",
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Location = new Point(10, 10),
                    Width = questionPanel.Width - 40,
                    AutoSize = true,
                    ForeColor = isCorrect ? Color.Green : (answered ? Color.Red : Color.Orange)
                };
                questionPanel.Controls.Add(lblQuestion);

                int answerY = lblQuestion.Bottom + 10;

                // Afficher toutes les réponses
                foreach (var ans in q.Answers)
                {
                    Label lblAnswer = new Label
                    {
                        Location = new Point(30, answerY),
                        Width = questionPanel.Width - 60,
                        AutoSize = true,
                        Font = new Font("Segoe UI", 10)
                    };

                    bool isUserAnswer = answered && userAnswerId == ans.IdAnswer;
                    bool isCorrectAnswer = ans.IsCorrect;

                    // Définir le texte et la couleur
                    string prefix = "";
                    if (isCorrectAnswer && isUserAnswer)
                    {
                        prefix = "✓ "; // Bonne réponse sélectionnée
                        lblAnswer.ForeColor = Color.Green;
                        lblAnswer.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    }
                    else if (isCorrectAnswer)
                    {
                        prefix = "✓ "; // Bonne réponse (non sélectionnée)
                        lblAnswer.ForeColor = Color.Green;
                        lblAnswer.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    }
                    else if (isUserAnswer)
                    {
                        prefix = "✗ "; // Mauvaise réponse sélectionnée
                        lblAnswer.ForeColor = Color.Red;
                        lblAnswer.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    }
                    else
                    {
                        prefix = "○ "; // Non sélectionnée
                        lblAnswer.ForeColor = Color.Gray;
                    }

                    lblAnswer.Text = prefix + ans.AnswerText;
                    questionPanel.Controls.Add(lblAnswer);
                    answerY += lblAnswer.Height + 5;
                }

                // Ajouter un label pour indiquer le statut
                Label lblStatus = new Label
                {
                    Location = new Point(30, answerY + 5),
                    Width = questionPanel.Width - 60,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Italic)
                };

                if (!answered)
                {
                    lblStatus.Text = "⚠ Non répondue";
                    lblStatus.ForeColor = Color.Orange;
                }
                else if (isCorrect)
                {
                    lblStatus.Text = "✓ Correct";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblStatus.Text = "✗ Incorrect";
                    lblStatus.ForeColor = Color.Red;
                }

                questionPanel.Controls.Add(lblStatus);
                questionPanel.Height = answerY + lblStatus.Height + 20;

                panelResults.Controls.Add(questionPanel);
                yPos += questionPanel.Height + 15;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResultDetailsForm_Load(object sender, EventArgs e)
        {
        }
    }
}