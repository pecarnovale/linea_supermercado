using LineaSupermercado.DAL;
using LineaSupermercado.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LineaSupermercado
{
    /// <summary>
    /// Lógica de interacción para AgregarCliente.xaml
    /// </summary>
    public partial class AgregarCliente : Window
    {
       
        public AgregarCliente()
        {
            InitializeComponent();
        }



        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreCliente.Text.Trim() != "")
            { 
                var _db = new LineaSupermercadoContext();

                var cajaConMenosClientes = (from caj in _db.Cajas
                                            join ccli in _db.CajaCliente on caj.ID equals ccli.IDCaja into cli
                                            from ccli in cli.DefaultIfEmpty()
                                            select new { IDCaja = caj.ID, NumeroCaja = caj.NumeroCaja, ClientesSinAtender = (ccli == null) ? 0 : cli.Where(x => x.Estado == 0).Count() }

                                           ).GroupBy(x => new { x.IDCaja, x.NumeroCaja, x.ClientesSinAtender }).OrderBy(x => new { x.Key.ClientesSinAtender, x.Key.NumeroCaja }).First();
                //Creo el cliente
                Cliente cliente = new Cliente();
                cliente.Nombre = txtNombreCliente.Text;
                _db.Clientes.Add(cliente);
            
                //Lo agrego a la caja con menos clientes
                CajaCliente cajaCliente = new CajaCliente();
                cajaCliente.IDCliente = cliente.ID;
                cajaCliente.IDCaja = cajaConMenosClientes.Key.IDCaja;
                cajaCliente.Orden = _db.CajaCliente.Where(x => x.IDCaja == cajaConMenosClientes.Key.IDCaja).Select(x => x.Orden).DefaultIfEmpty(0).Max() + 1;
                _db.CajaCliente.Add(cajaCliente);
                _db.SaveChanges();
            
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("El nombre del cliente no puede estar vacio");
            }

        }


        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
