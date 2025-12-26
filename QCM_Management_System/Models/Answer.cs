namespace QCM_Management_System.Models
{
    public class Answer
    {
        public int IdAnswer { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int IdQuestion { get; set; }
    }
}