using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCM_Management_System.Models
{
    public class Question
    {
        public int IdQuestion { get; set; }
        public string QuestionText { get; set; }
        public int IdQCM { get; set; }
        public int? OrderNumber { get; set; }
    }
}
