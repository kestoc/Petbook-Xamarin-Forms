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
        public UserModel userAct { get; set; } //Variable para buscar el usuari actual que inicio sesion
        public IList<Comunidad> Comuni { get; private set; } //Lista para guardar las comunidades

        List<string> guardado = new List<string> { }; //Lista donde se guarda lo buscado
        public comunidad(UserModel temp, List<string> temp2)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Sentencia para eliminar la barra superior de herramientas por defecto de Android
            userAct = temp;
            guardado = temp2;

            //Agregando elementos a la lista de comunidades
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

            BindingContext = this; //Crear la relacion con la clase y el XAML para mostrar la informacion (patron MVVM)
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