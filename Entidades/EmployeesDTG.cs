using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAVD.Entidades
{
    class EmployeesDTG
    {
        public static List<EmployeesDTG> DataSource { get; internal set; }
        public Guid employee_id { get; set; }
        public Guid user_id { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string mother_last_name { get; set; }
        public string claves_unicas { get; set; }
        public string date_of_birth { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
    }
}
