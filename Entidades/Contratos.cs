using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAVD.Entidades
{
    class Contratos
    {
        public double num_servicio { get; set; }
        public Guid id_cliente { get; set; }
        public string tipo { get; set; }
        public double num_medidor { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public double num_cliente { get; set; }
        public string creation_day { get; set; }
        public string creation_month { get; set; }
        public string creation_year { get; set; }

    }
}
