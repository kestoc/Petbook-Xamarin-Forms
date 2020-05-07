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
    public partial class menu : ContentPage
    {
        public menu()
        {
            InitializeComponent();
        }
        private void btnComunity(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new comunidad());
        }
        private void btnWrite(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new publicacion());
        }
        private void btnLogo(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new principal());
        }
        private void btnSearch(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new busqueda());
        }
        private void btnMenu(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new menu());
        }
    }
}