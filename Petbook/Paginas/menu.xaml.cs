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
        public UserModel userAct { get; set; } //Variable para preservar el valor del usuario que inicio sesion

        List<string> guardado = new List<string> { }; //Lista para almacenar las busquedas realizadas 
        public IList<Options> Options { get; private set; } //Lista para almacenar las opciones que se tienen en el menu
        public menu(UserModel temp, List<string> temp2)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Sentencia para eliminar la barra de herramientas superior predeterminada por Android
            userAct = temp;
            guardado = temp2;
            //BindingContext = userAct; 

            DisplayAlert("HOLA!", userAct.name.ToString(), "Ok"); //Debido al problema con los bindingContext a la hora de usarlo para la label y para la listView, se opto por mandar un cuadro
                                                                 //de alerta que permita evidenciar el correcto guardado del usuario que inicio sesion
            
            //Añadiendo elementos a la lista de opciones
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

            BindingContext = this;  //Construir el contexto para hacer el linkeamiento de la clase y sus elementos y la parte grafica del XAML (patron MVVM)
        }

        private void salir(object sender, EventArgs e) //Funcion para permitir que el boton de logOut redireccione a la pagina de login
        {
            ((NavigationPage)this.Parent).PushAsync(new login());
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