using Petbook.Tablas;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace Petbook.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        private SQLiteAsyncConnection conn; //Variable para guardar la ruta de conexion con la DB

        List<string> guardado = new List<string> { }; //Lista para almacenar las busquedas realizadas (Seteo inicial)
        public login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Sentencia para eliminar la barra de herramientas superior predeterminada por Android
            conn = DependencyService.Get<ISQLiteDB>().GetConnection(); //Sentencia para realziar la conexcion con la DB
        }
        public static IEnumerable<T_Registro> SELECT_WHERE(SQLiteConnection db, string user, string password) //Funcion para realizar la query de busqueda de un usuario por medio de su nombre de usuario y contraseña
        {
            return db.Query<T_Registro>("SELECT * FROM T_Registro where user = ? and password = ?", user, password);
        }
        private void btnLogin(object sender, EventArgs e) //Funcion evento para iniciar sesion
        {
            var dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MySQLite.db3"); //Obtiene la ruta de la DB 
            var db = new SQLiteConnection(dataBasePath); //Establece la conexion con la DB 
            db.CreateTable<T_Registro>(); //Trae la tabla donde esten los usuarios registrados
            IEnumerable<T_Registro> resultado = SELECT_WHERE(db, user.Text, password.Text); //Realiza el llamado de la funcion para buscar por los datos en el DB
            if (resultado.Count() > 0) //Comprueba si la cantidad de elementos encontrados en la DB con esos datos es mayor que 0 y redirecciona a la pag principal de noticias
            {
                var user1 = new UserModel { name = user.Text }; 
                LimpiarCampos();
                Navigation.PushAsync(new principal(user1,guardado)); 
            }
            else
            {   //En caso de que no se encuentre manda una alerta
                LimpiarCampos();
                DisplayAlert("Datos incorrectos.", "Verifique e intente nuevamente.", "OK");
            }
        }

        private void LimpiarCampos() //Funcion para limpiar los campos de los entry
        {
            user.Text = "";
            password.Text = "";
        }
        private void btnRegister(object sender, EventArgs e) //Funcion evento para ir a la seccion de registrarse
        {
            LimpiarCampos();
            ((NavigationPage)this.Parent).PushAsync(new registro());
        }
    }
}