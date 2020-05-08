using Petbook.ClasesAux;
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
    public partial class comunidad : ContentPage
    {
        public UserModel userAct { get; set; }
        public IList<Comunidad> Comuni { get; private set; }
        List<string> guardado = new List<string> { };
        public comunidad(UserModel temp, List<string> temp2)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            userAct = temp;
            guardado = temp2;

            Comuni = new List<Comunidad>();
            Comuni.Add(new Comunidad
            {
                Nombre = "DogLoversComunity",
                Miembros = "12.000 miembros"
            });


            Comuni.Add(new Comunidad
            {
                Nombre = "BirdsLoversComunity",
                Miembros = "5800 miembros"
            });


            Comuni.Add(new Comunidad
            {
                Nombre = "CatsLoversComunity",
                Miembros = "27.500 miembros"
            });

            BindingContext = this;
        }
        private void btnComunity(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new comunidad(userAct,guardado));
        }
        private void btnWrite(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new publicacion(userAct,guardado));
        }
        private void btnLogo(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new principal(userAct,guardado));
        }
        private void btnSearch(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new busqueda(userAct,guardado));
        }
        private void btnMenu(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new menu(userAct,guardado));
        }
    }
}