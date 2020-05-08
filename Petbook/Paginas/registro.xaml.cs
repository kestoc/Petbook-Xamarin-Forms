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
        private SQLiteAsyncConnection conn; //Variable para guardar la ruta de conexion con la DB

        public registro()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Sentencia para eliminar la barra de herramientas superior predeterminada por Android
            conn = DependencyService.Get<ISQLiteDB>().GetConnection(); //Sentencia para realziar la conexcion con la DB
        }

        private void btnEnviar(object sender, EventArgs e) //Realizando una insersion en la tabla que almacena los usuarios en la base de datos, limpiando los campos y redireccionando a la parte del login
        {
            conn.InsertAsync(new T_Registro { user = user.Text, correo = correo.Text, password = password.Text, fecha = fecha.Date });
            LimpiarCampos();
            ((NavigationPage)this.Parent).PushAsync(new login());
        }

        private void LimpiarCampos() //Funcion para limpiar los campos de entry
        {
            user.Text = "";
            password.Text = "";
            correo.Text = "";
        }
    }
}