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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LineaSupermercadoContext _db;
        public MainWindow()
        {
            InitializeComponent();
            CenterWindowOnScreen();
            RefreshDatagrid(); 
        }
        //Centrar en Pantalla
        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }


        //Dialog para caja
        private void btnAgregarCaja_Click(object sender, RoutedEventArgs e)
        {
            var dialogAC = new AgregarCaja();
            if (dialogAC.ShowDialog() == true)
            {
                RefreshDatagrid();
                MessageBox.Show("Caja agregada con exito");
            }
        }

        //Dialog para cliente
        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            var dialogAC = new AgregarCliente();
            if (dialogAC.ShowDialog() == true)
            {
                RefreshDatagrid();
                MessageBox.Show("Cliente agregado con exito");
            }
        }

        //Actualiza datagrid cajas
        private void RefreshDatagrid()
        {
            using (_db = new LineaSupermercadoContext())
            {
                var cajas = _db.Cajas.Include("Clientes").ToList();
                dgCajas.ItemsSource = cajas;
            }

            
        }

        //Desplaza clientes desde una caja hacia otra
        private void DesplazarClientes(int NumeroCajaAnt, int NumeroCajaNueva)
        {
            _db = new LineaSupermercadoContext();
            List<CajaCliente> clientes = _db.Cajas.Include("Clientes").First(x => x.ID == NumeroCajaAnt).Clientes.Where(x => x.Estado == 0).OrderBy(x => x.Orden).ToList();

            if (clientes.Count() > 0)
            {
                foreach (CajaCliente cajaCli in clientes)
                {
                    cajaCli.IDCaja = NumeroCajaNueva;
                    cajaCli.Orden = _db.CajaCliente.Where(x => x.IDCaja == cajaCli.IDCaja).Select(x => x.Orden).DefaultIfEmpty(0).Max() + 1;
                    _db.Entry<CajaCliente>(cajaCli).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
           
        }

        //Ordena los clientes de una caja
        private void OrdernarCaja(int NumeroCaja)
        {
            _db = new LineaSupermercadoContext();
            List<CajaCliente> clientes = _db.Cajas.Include("Clientes").First(x => x.ID == NumeroCaja).Clientes.Where(x => x.Estado == 0).OrderBy(x => x.Orden).ToList();

            foreach (CajaCliente cajaCli in clientes)
            {
                cajaCli.Orden = cajaCli.Orden - 1;
                _db.Entry(cajaCli).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }


        //Cierra una caja
        private void btnCerrarCaja_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _db = new LineaSupermercadoContext();
                Caja caja = (Caja)((Button)e.Source).DataContext;
                bool puedeCerrarCaja = false;

                //Objengo total de cajas abiertas
                int cajasAbiertas = _db.Cajas.Count();

               
                if (cajasAbiertas > 1)
                {
                    puedeCerrarCaja = true;
                }
                else
                {
                        Caja cajaAbierta = _db.Cajas.Include("Clientes").First();
                        if (cajaAbierta.ClientesPorAtender == 0)
                        {
                            puedeCerrarCaja = true;
                        }
                        else
                        {
                            MessageBox.Show("No se puede cerrar la unica caja abierta si posee clientes pendientes, debe atenderlos primero");
                        }
                }


                if (puedeCerrarCaja)
                {
                    //Si existe mas de una caja abierta debo desplazar clientes, sino es una unica caja sin clientes por atender
                    if (cajasAbiertas > 1)
                    {
                        //Obtengo la caja con menos clientes exceptuando la que voy a cerrar
                        var cajaConMenosClientes = (from caj in _db.Cajas
                                                    join ccli in _db.CajaCliente on caj.ID equals ccli.IDCaja into cli
                                                    from ccli in cli.DefaultIfEmpty()
                                                    where caj.ID != caja.ID
                                                    select new { IDCaja = caj.ID, NumeroCaja = caj.NumeroCaja, ClientesSinAtender = (ccli == null) ? 0 : cli.Where(x => x.Estado == 0).Count() }

                                               ).GroupBy(x => new { x.IDCaja, x.NumeroCaja, x.ClientesSinAtender }).OrderBy(x => new { x.Key.ClientesSinAtender, x.Key.NumeroCaja }).First();

                        //Paso todos los clientes a la caja con menos clientes
                        DesplazarClientes(caja.ID, cajaConMenosClientes.Key.IDCaja);
                    }


                    //Borro la caja
                    Caja cajaDeleted = _db.Cajas.Find(caja.ID);
                    _db.Cajas.Remove(cajaDeleted);
                    _db.SaveChanges();

                    //Refresco datagrid
                    RefreshDatagrid();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Atiendo a un cliente
        private void btnAtenderCliente_Click(object sender, RoutedEventArgs e)
        {
            _db = new LineaSupermercadoContext();
            Caja c = (Caja)((Button)e.Source).DataContext;
            Caja caja = _db.Cajas.Where(x => x.ID == c.ID).Include("Clientes").First();

            CajaCliente clienteAtendido = caja.Clientes.Where(x => x.Estado == 0).OrderBy(x => x.Orden).First();
            clienteAtendido.Estado = 1;
            _db.Entry(clienteAtendido).State = EntityState.Modified;
            _db.SaveChanges();

            Cliente cliente = _db.Clientes.Find(clienteAtendido.IDCliente);

            MessageBox.Show("Atendiendo al cliente: " + cliente.Nombre);

            //Ordeno nuevamente el conjunto de clientes
            OrdernarCaja(caja.ID);

            //Actualizo cajas
            RefreshDatagrid();
        }

        

            
        
    }
}
