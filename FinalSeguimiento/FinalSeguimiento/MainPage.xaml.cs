using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FinalSeguimiento.Models;

namespace FinalSeguimiento
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Clicked(object sender, EventArgs e)
        {
            var allMovimientos = Conexion.Instancia.GetAllReg();
            RegistroMov.ItemsSource = allMovimientos;
            Estado.Text = Conexion.Instancia.EstadoDeMensaje;
        }

        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            Estado.Text = string.Empty;
            Conexion.Instancia.addNew(mov.Text, con.Text, Convert.ToDouble(val.Text), det.Text, Convert.ToDateTime(fec.Text), rec.Text);
            Estado.Text = Conexion.Instancia.EstadoDeMensaje;
        }

        private void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            Conexion.Instancia.Delete();
        }

        private void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
