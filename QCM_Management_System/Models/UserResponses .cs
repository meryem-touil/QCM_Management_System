using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCM_Management_System.Models
{
    public class UserResponse
    {
        public int IdResponse { get; set; }
        public int IdResult { get; set; }
        public int IdQuestion { get; set; }
        public int? IdAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
