using Petbook.Tablas;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petbook.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registro : ContentPage
    {
        private SQLiteAsyncConnection conn; //Variable para establecer la conexion con la DB

        public registro()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Sentencia para eliminar la barra superior de herramientas por defecto de Android
            conn = DependencyService.Get<ISQLiteDB>().GetConnection(); //Estableciendo la conexion con la DB
        }

        private void btnEnviar(object sender, EventArgs e) //Funcion evento para mandar los datos del usuario a la tabla y se guarde en la DB
        {
            conn.InsertAsync(new T_Registro { user = user.Text, correo = correo.Text, password = password.Text, fecha = fecha.Date });
            LimpiarCampos();
            ((NavigationPage)this.Parent).PushAsync(new login());
        }

        private void LimpiarCampos() //Funcion para limpiar los campos de texto
        {
            user.Text = "";
            password.Text = "";
            correo.Text = "";
        }
    }
}