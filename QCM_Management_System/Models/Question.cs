using System.Collections.Generic;

namespace QCM_Management_System.Models
{
    public class Question
    {
        public int IdQuestion { get; set; }
        public string QuestionText { get; set; }
        public int IdQCM { get; set; }
        public int OrderNumber { get; set; }
        public List<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}