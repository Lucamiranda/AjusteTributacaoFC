using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjusteTributario.Modelos
{
    public class Produtos
    {
        public string codigo { get; set; }
        public string produto { get; set; }
        public string grupo { get; set; }
        public string cst { get; set; }
        public string aliquotaICMS { get; set; }
        public string pis { get; set; }
        public string aliquotaPIS { get; set; }
        public string cofins { get; set; }
        public string aliquotaCOFINS { get; set; }
        public string ipi { get; set; }
        public string aliquotaIPI { get; set; }
        public string ncm { get; set; }
        public string cfop { get; set; }
        public string listaPisCofins { get; set; }
    }
}
