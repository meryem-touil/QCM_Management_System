using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCM_Management_System.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
