using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaSupermercado.Entities
{
    class Caja
    {
        public int ID { get; set; }
        public int NumeroCaja { get; set; }
        public string Cajero { get; set; }

        public virtual ICollection<CajaCliente> Clientes { get; set; }
        public int ClientesAtendidos { get { return this.Clientes.Count(x => x.Estado == 1); }}
        public int ClientesPorAtender { get { return this.Clientes.Count(x => x.Estado == 0); }}

    }
}
