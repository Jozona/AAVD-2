using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAVD.Entidades
{
    class ClientesDTG
    {
        public Guid user_id { get; set; }
        public Guid client_id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string mother_last_name { get; set; }
        public string date_of_birth { get; set; }
        public string gender { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string colony { get; set; }
        public string state { get; set; }
        public string contract_type { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string curp { get; set; }
        public string num_cliente { get; set; }

    }
}
