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
        private SQLiteAsyncConnection conn;
        public login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            conn = DependencyService.Get<ISQLiteDB>().GetConnection();
        }
        public static IEnumerable<T_Registro> SELECT_WHERE(SQLiteConnection db, string user, string password)
        {
            return db.Query<T_Registro>("SELECT * FROM T_Registro where user = ? and password = ?", user, password);
        }
        private void btnLogin(object sender, EventArgs e)
        {
            var dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MySQLite.db3");
            var db = new SQLiteConnection(dataBasePath);
            db.CreateTable<T_Registro>();
            IEnumerable<T_Registro> resultado = SELECT_WHERE(db, user.Text, password.Text);
            if (resultado.Count() > 0)
            {
                var user1 = new UserModel { name = user.Text };
                LimpiarCampos();
                Navigation.PushAsync(new principal(user1)); 
            }
            else
            {
                LimpiarCampos();
                DisplayAlert("Datos incorrectos.", "Verifique e intente nuevamente.", "OK");
            }
        }

        private void LimpiarCampos()
        {
            user.Text = "";
            password.Text = "";
        }
        private void btnRegister(object sender, EventArgs e)
        {
            LimpiarCampos();
            ((NavigationPage)this.Parent).PushAsync(new registro());
        }
    }
}