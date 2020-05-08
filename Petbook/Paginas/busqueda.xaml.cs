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
    public partial class busqueda : ContentPage
    {
        List<string> guardado = new List<string> {};
        public UserModel userAct { get; set; }
        public busqueda(UserModel temp)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            userAct = temp;
            BindingContext = userAct;
        }
        void guardarLog(object sender, EventArgs e)
        {
            guardado.Add(busq.Text);
            LimpiarCampo();
        }
        void mostrarLog(object sender, EventArgs e)
        {
            var countriesSearched = guardado.Where(c => c.Contains(busq.Text));
            logBuscado.ItemsSource = countriesSearched;
        }
        private void LimpiarCampo()
        {
            busq.Text = "";
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