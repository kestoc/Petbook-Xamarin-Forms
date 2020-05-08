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
        public UserModel userAct { get; set; } //Variable para buscar el usuari actual que inicio sesion

        List<string> guardado = new List<string> { }; //Lista donde se guarda lo buscado
        public publicacion(UserModel temp, List<string> temp2)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Sentencia para eliminar la barra superior de herramientas por defecto de Android
            userAct = temp;
            guardado = temp2;
        }
        private void LimpiarCampo() //Funcion para limpiar el campo de texto
        {
            editor.Text = "";
        }
        private void btnPublicar(object sender, EventArgs e) //Funcion evento para "publicar" lo escrito
        {
            LimpiarCampo();
            ((NavigationPage)this.Parent).PushAsync(new principal(userAct,guardado));
        }

        //Funciones para direccionar a las respectivas paginas con los botenes de la barra de herramientas inferior de la App
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