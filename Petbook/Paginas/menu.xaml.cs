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
        public UserModel userAct { get; set; } //Variable para buscar el usuari actual que inicio sesion

        List<string> guardado = new List<string> { }; //Lista donde se guarda lo buscado
        public IList<Options> Options { get; private set; } //Lista donde se guardaran las opciones 
        public menu(UserModel temp, List<string> temp2)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Sentencia para eliminar la barra superior de herramientas por defecto de Android
            userAct = temp;
            guardado = temp2;
            //BindingContext = userAct;

            DisplayAlert("Hola", userAct.name.ToString(), "Ok"); //Por problemas con el BindingContext se decidio mostrar el nombre del usuario por medio de una alerta
            
            //Agregando elementos a la lista de opciones
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

            BindingContext = this; //Crear la relacion con la clase y el XAML para mostrar la informacion (patron MVVM)
        }

        private void salir(object sender, EventArgs e) //Funcion evento para el boton salir para volver a la seccion de login
        {
            ((NavigationPage)this.Parent).PushAsync(new login());
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