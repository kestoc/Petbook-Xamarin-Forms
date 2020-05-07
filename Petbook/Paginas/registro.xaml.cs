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
        private SQLiteAsyncConnection conn;

        public registro()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            conn = DependencyService.Get<ISQLiteDB>().GetConnection();
        }

        private void btnEnviar(object sender, EventArgs e)
        {
            conn.InsertAsync(new T_Registro { user = user.Text, correo = correo.Text, password = password.Text, fecha = fecha.Date });
            LimpiarCampos();
            ((NavigationPage)this.Parent).PushAsync(new login());
        }

        private void LimpiarCampos()
        {
            user.Text = "";
            password.Text = "";
            correo.Text = "";
        }
    }
}