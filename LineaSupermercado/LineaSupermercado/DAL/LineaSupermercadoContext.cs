using LineaSupermercado.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaSupermercado.DAL
{
    class LineaSupermercadoContext : DbContext
    {
        public DbSet<Caja> Cajas { get; set;}
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CajaCliente> CajaCliente { get; set; }

        public LineaSupermercadoContext(): base("dbConnection")
        {

        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Esto se realiaa para evitar que me cree las entidades por convencion (Inscripciones, Cursoes, Estudiantes)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
