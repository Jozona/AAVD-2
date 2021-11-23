using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAVD.Entidades
{
    class Users
    {
        public Guid user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public int user_type { get; set; }
        public bool active { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
    }
}
