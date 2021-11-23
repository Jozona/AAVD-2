using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace AAVD.Entidades
{
    class Employees
    {
        public Guid employee_id { get; set; }
        public Guid user_id { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string mother_last_name { get; set; }
        public IDictionary<string, string> claves_unicas { get; set; }
        public TimeUuid creation_date { get; set; }
        public DateTimeOffset date_of_birth { get; set; }
        public IEnumerable<LocalDate> modification_date { get; set; }
        public string question { get; set; }
        public string answer { get; set; }


    }
}
