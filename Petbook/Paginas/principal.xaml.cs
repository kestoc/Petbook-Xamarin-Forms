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
    public partial class principal : ContentPage
    {
        public UserModel userAct { get; set; } //Variable para preservar el valor del usuario que inicio sesion
        public IList<Publicacion> Publicaciones { get; private set; } //Lista para almacenar las publicaciones que se creen

        List<string> guardado = new List<string> { }; //Lista para almacenar las busquedas realizadas
        public principal(UserModel temp, List<string> temp2)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Sentencia para eliminar la barra de herramientas superior predeterminada por Android
            userAct = temp;
            guardado = temp2;

            //Añadiendo elementos a la lista de publicaciones
            Publicaciones = new List<Publicacion>();
            Publicaciones.Add(new Publicacion
            {
                Autor = "Jorgito Figueroa",
                Texto = "¿Alguna recomendación para ayudar a mi perrita a bajar de peso? XDDDD .Se ve tierna así, pero no es bueno para ella  :c",
                Imagen = "https://www.muyinteresante.com.mx/wp-content/uploads/2018/05/httpstved-prod.adobecqms.netcontentdamtbgmexicomuyinteresantemxambienteplantas-y-animales180105obesidad-mascotas.imgo_-1280x720.jpg"
            });

            Publicaciones.Add(new Publicacion
            {
                Autor = "Cata Gómez",
                Texto = "Los dos mayores tesoros de nuestra familia <3 <3 <3",
                Imagen = "https://lifestyle.americaeconomia.com/sites/lifestyle.americaeconomia.com/files/styles/gallery_image/public/mascotasbuenas1111a.jpg?itok=ckH10oKe"
            });

            Publicaciones.Add(new Publicacion
            {
                Autor = "Mauricio Ortiz",
                Texto = "Agradecido con @ClinicaVeterinariaBakaldo por el excelente progreso en la recuperación de Pola después de su accidente :)",
                Imagen = "https://www.barakaldotiendaveterinaria.es/blog/wp-content/uploads/2018/01/hidroterapia-con-animales.jpg"
            });

            Publicaciones.Add(new Publicacion
            {
                Autor = "Julian Restrepo",
                Texto = "Enseñandole a decir: No puelo toy chiquito UwU",
                Imagen = "https://mascotas.tips/wp-content/uploads/2020/04/cuidado-gato-beb%C3%A9-1024x490.jpg"
            });

            Publicaciones.Add(new Publicacion
            {
                Autor = "Octavio Luna",
                Texto = "Mirando a la nada pensando en todo #Pensativa #Reflexiva #AburridaEnCuarentena :(",
                Imagen = "https://t1.ea.ltmcdn.com/es/images/5/0/6/mi_tortuga_no_quiere_comer_24605_0_600.jpg"
            });

            Publicaciones.Add(new Publicacion
            {
                Autor = "karen Ríos",
                Texto = "Con las patas en la masa XD :D D:    Asquito....",
                Imagen = "https://img.vixdata.io/pd/jpg-large/es/sites/default/files/btg/curiosidades.batanga.com/files/Por-que-los-gatos-traen-animales-muertos-a-casa-1.jpg"
            });

            BindingContext = this;  //Construir el contexto para hacer el linkeamiento de la clase y sus elementos y la parte grafica del XAML (patron MVVM)
        }
        private void OnButtonClickedUp(object sender, EventArgs e) //Funcion de evento para cuando se pulse el boton de dar like (cambia de color)
        {
            ImageButton btn = (ImageButton)sender;
            if (btn.BackgroundColor.Equals(Color.FromHex("#808080")))
                btn.BackgroundColor = Color.FromHex("#52BE80");
            else
                btn.BackgroundColor = Color.FromHex("#808080");
        }
        private void OnButtonClickedDown(object sender, EventArgs e) //Funcion de evento para cuando se pulse el boton de dar dislike (cambia de color)
        {
            ImageButton btn = (ImageButton)sender;
            if (btn.BackgroundColor.Equals(Color.FromHex("#808080")))
                btn.BackgroundColor = Color.FromHex("#E40000");
            else
                btn.BackgroundColor = Color.FromHex("#808080");
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