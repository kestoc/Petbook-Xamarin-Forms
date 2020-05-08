using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Petbook.ClasesAux;
using Petbook.Paginas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petbook.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class menu : ContentPage
    {
        public UserModel userAct { get; set; }
        List<string> guardado = new List<string> { };
        public IList<Options> Options { get; private set; }
        public menu(UserModel temp, List<string> temp2)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            userAct = temp;
            guardado = temp2;

            DisplayAlert("Hola", userAct.name.ToString(), "Ok");

            Options = new List<Options>();
            Options.Add(new Options
            {
                Texto = "EDITAR PERFIL",
                Imagen = "personAdd.png"
            });

            Options.Add(new Options
            {
                Texto = "NOTIFICACIONES",
                Imagen = "notify.png"
            });

            Options.Add(new Options
            {
                Texto = "MENSAJES",
                Imagen = "message.png"
            });

            Options.Add(new Options
            {
                Texto = "CONFIGURACIÓN",
                Imagen = "settings.png"
            });

            Options.Add(new Options
            {
                Texto = "ACERCA DE NOSOTROS",
                Imagen = "alert.png"
            });

            Options.Add(new Options
            {
                Texto = "TERMINOS Y CONDICIONES",
                Imagen = "lock.png"
            });

            BindingContext = this;
        }

        private void salir(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new login());
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