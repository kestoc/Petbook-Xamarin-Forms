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
        public UserModel userAct { get; set; } //Variable para preservar el valor del usuario que inicio sesion
        public IList<Comunidad> Comuni { get; private set; } //Lista para almacenar las comunidades que se creen

        List<string> guardado = new List<string> { }; //Lista para almacenar las busquedas realizadas 
        public comunidad(UserModel temp, List<string> temp2)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Sentencia para eliminar la barra de herramientas superior predeterminada por Android
            userAct = temp;
            guardado = temp2;

            //Añadiendo elementos a la lista de comunidades
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

            BindingContext = this; //Construir el contexto para hacer el linkeamiento de la clase y sus elementos y la parte grafica del XAML (patron MVVM)
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