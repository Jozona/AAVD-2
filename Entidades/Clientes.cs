using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace AAVD.Entidades
{
    class Clientes
    {
        public Guid client_id { get; set; }
        public Guid user_id { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string mother_last_name { get; set; }
        public string contract_type { get; set; }
        public TimeUuid creation_date { get; set; }
        public IEnumerable<LocalDate> modification_times { get; set; }
        public IDictionary<string, double> monthly_payments { get; set; }
        public string curp { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public IEnumerable<double> measurers { get; set; }
        public int service_number { get; set; }
        public IEnumerable<double> contracts { get; set; }
        public string street { get; set; }
        public string colony { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public Guid author { get; set; }
        public DateTimeOffset date_of_birth { get; set; }
        public double num_cliente { get; set; }

    }
}
