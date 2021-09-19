using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5HW1.Models
{
    public class RegisterResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
    }
}
