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
        public UserModel userAct { get; set; } //Variable para preservar el valor del usuario que inicio sesion

        List<string> guardado = new List<string> { }; //Lista para almacenar las busquedas realizadas 
        public publicacion(UserModel temp, List<string> temp2)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Sentencia para eliminar la barra de herramientas superior predeterminada por Android
            userAct = temp;
            guardado = temp2;
        }
        private void LimpiarCampo() //Funcion para limpiar el campo de escirtura del editor
        {
            editor.Text = "";
        }
        private void btnPublicar(object sender, EventArgs e) //Funcion evento para el boton publicar
        {
            LimpiarCampo();
            ((NavigationPage)this.Parent).PushAsync(new principal(userAct,guardado));
        }

        //Funciones para la navegacion y funcionamiento entre las paginas correspondientes a la barra inferior de herramientas de la App
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