using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAVD.Entidades
{
    class Consumos
    {
        public int num_medidor { get; set; }
        public double consumo { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public double kw_basico { get; set; }
        public double kw_intermedio { get; set; }
        public double kw_excedente { get; set; }
        public double importe { get; set; }
        public double pagar_total_iva { get; set; }
        public double pendiente_pago { get; set; }
        public double num_servicio { get; set; }
    }
}
