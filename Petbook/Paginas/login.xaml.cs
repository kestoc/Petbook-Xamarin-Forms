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
        private SQLiteAsyncConnection conn; //Variable para establecer la conexion con la DB

        List<string> guardado = new List<string> { }; //Lista donde se guarda lo buscado
        public login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Sentencia para eliminar la barra superior de herramientas por defecto de Android
            conn = DependencyService.Get<ISQLiteDB>().GetConnection(); //Estableciendo la conexion con la DB
        }
        public static IEnumerable<T_Registro> SELECT_WHERE(SQLiteConnection db, string user, string password) //Funcion para realziar la peticion a la DB y buscar elementos en ella
        {
            return db.Query<T_Registro>("SELECT * FROM T_Registro where user = ? and password = ?", user, password);
        }
        private void btnLogin(object sender, EventArgs e) //Funcion para iniciar sesion
        {
            var dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MySQLite.db3"); //Se establece la direccion de la DB
            var db = new SQLiteConnection(dataBasePath); //Se establece la conexion con la DB
            db.CreateTable<T_Registro>(); //Se crea la tabla donde se guardan los datos
            IEnumerable<T_Registro> resultado = SELECT_WHERE(db, user.Text, password.Text); //Se realiza la peticion 
            if (resultado.Count() > 0) //Si encontro el elemento en la DB lo deja continuar a la pag principal de noticias
            {
                var user1 = new UserModel { name = user.Text };
                LimpiarCampos();
                Navigation.PushAsync(new principal(user1,guardado)); 
            }
            else
            {
                LimpiarCampos();
                DisplayAlert("Datos incorrectos.", "Verifique e intente nuevamente.", "OK"); //Si el elemento no se encuentra en la DB, se manda un alert
            }
        }

        private void LimpiarCampos() //Funcion para limpiar el texto
        {
            user.Text = "";
            password.Text = "";
        }
        private void btnRegister(object sender, EventArgs e) //Funcnion para redireccionar a la pagina de registro de la App
        {
            LimpiarCampos();
            ((NavigationPage)this.Parent).PushAsync(new registro());
        }
    }
}