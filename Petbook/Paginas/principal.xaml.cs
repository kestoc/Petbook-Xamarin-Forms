﻿using Petbook.ClasesAux;
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
        public UserModel userAct { get; set; } //Variable para buscar el usuari actual que inicio sesion
        public IList<Publicacion> Publicaciones { get; private set; } //Listado donde se guardan las publicaciones

        List<string> guardado = new List<string> { }; //Lista donde se guarda lo buscado
        public principal(UserModel temp, List<string> temp2)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //Sentencia para eliminar la barra superior de herramientas por defecto de Android
            userAct = temp;
            guardado = temp2;

            //Agregando publicaciones a la lista
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

            BindingContext = this; //Crear la relacion con la clase y el XAML para mostrar la informacion (patron MVVM)
        }

        private void OnButtonClickedUp(object sender, EventArgs e) //Funcion evento para cambiar el color de like
        {
            ImageButton btn = (ImageButton)sender;
            if (btn.BackgroundColor.Equals(Color.FromHex("#808080")))
                btn.BackgroundColor = Color.FromHex("#52BE80");
            else
                btn.BackgroundColor = Color.FromHex("#808080");
        }

        private void OnButtonClickedDown(object sender, EventArgs e) //Funcion evento para cambiar el color de dislike
        {
            ImageButton btn = (ImageButton)sender;
            if (btn.BackgroundColor.Equals(Color.FromHex("#808080")))
                btn.BackgroundColor = Color.FromHex("#E40000");
            else
                btn.BackgroundColor = Color.FromHex("#808080");
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