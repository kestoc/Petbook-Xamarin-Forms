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
    public partial class publicacion : ContentPage
    {
        public UserModel userAct { get; set; }
        public publicacion(UserModel temp)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            userAct = temp;
            BindingContext = userAct;
        }
        private void LimpiarCampo()
        {
            editor.Text = "";
        }
        private void btnPublicar(object sender, EventArgs e)
        {
            LimpiarCampo();
            ((NavigationPage)this.Parent).PushAsync(new principal(userAct));
        }
        private void btnComunity(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new comunidad(userAct));
        }
        private void btnWrite(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new publicacion(userAct));
        }
        private void btnLogo(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new principal(userAct));
        }
        private void btnSearch(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new busqueda(userAct));
        }
        private void btnMenu(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new menu(userAct));
        }
    }
}