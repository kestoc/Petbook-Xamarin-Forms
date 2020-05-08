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
        List<string> guardado = new List<string> {}; //Lista donde se guarda lo buscado
        public UserModel userAct { get; set; } //Variable para buscar el usuari actual que inicio sesion
        public busqueda(UserModel temp, List<string> temp2)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);  //Sentencia para eliminar la barra superior de herramientas por defecto de Android
            userAct = temp;
            guardado = temp2;
        }
        void guardarLog(object sender, EventArgs e) //Funcion para guardar las palabras buscadas
        {
            guardado.Add(busq.Text);
            LimpiarCampo();
        }
        void mostrarLog(object sender, EventArgs e) //Funcion para mostrar las palabras buscadas
        {
            var countriesSearched = guardado.Where(c => c.Contains(busq.Text));
            logBuscado.ItemsSource = countriesSearched;
        }
        private void LimpiarCampo() //Funcion para limpiar texto
        {
            busq.Text = "";
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