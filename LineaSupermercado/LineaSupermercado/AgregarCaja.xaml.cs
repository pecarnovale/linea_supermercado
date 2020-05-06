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
    public partial class AgregarCaja : Window
    {

        public AgregarCaja()
        {
            InitializeComponent();
        }

        public static bool IsInteger(string theValue)
        {
            try
            {
                Convert.ToInt32(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
           

            
            if(IsInteger(txtNumeroCaja.Text))
            {
                 if (txtNombreCajero.Text.Trim() != "")
                 {
                    //Agrego la caja en cuestion
                    var _db = new LineaSupermercadoContext();
                    int numeroCaja = Convert.ToInt32(txtNumeroCaja.Text.ToString());

                    int cantCajas = _db.Cajas.Where(x => x.NumeroCaja == numeroCaja).Count();
                    if (cantCajas == 0)
                    {
                        Caja caja = new Caja();
                        caja.NumeroCaja = Convert.ToInt32(txtNumeroCaja.Text.ToString());
                        caja.Cajero = txtNombreCajero.Text;
                        _db.Cajas.Add(caja);
                        _db.SaveChanges();
                        DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("El numero de caja ya existe");
                    }
                }
                else
                {
                    MessageBox.Show("El nombre del cajero no puede estar vacio");
                }
               
            }
            else
            {
                MessageBox.Show("El numero de caja es incorrecto");
            }
         

        }


        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
