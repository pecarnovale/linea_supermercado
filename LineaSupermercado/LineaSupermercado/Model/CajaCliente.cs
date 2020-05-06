using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaSupermercado.Entities
{
    class CajaCliente
    {
        public int ID { get; set; }
        public int IDCaja { get; set; }
        public int IDCliente { get; set; }
        public int Estado { get; set; }
        public int Orden { get; set; }

        [ForeignKey("IDCaja")]
        public virtual Caja Caja { get; set; }

        [ForeignKey("IDCliente")]
        public virtual Cliente Cliente { get; set; }
    }
}
