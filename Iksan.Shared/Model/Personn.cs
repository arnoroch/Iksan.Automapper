using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aksan.Automapper.Model
{
    public sealed class Personn
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
