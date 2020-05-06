using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaSupermercado.Entities
{
    class Cliente
    {

        public int ID { get; set; }
        public string Nombre { get; set; }


        public virtual ICollection<CajaCliente> CajasCliente { get; set; }

        
    }
}
