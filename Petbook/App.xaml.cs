using Petbook.Paginas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petbook
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Se cambio la configuracion a un tipo de la clase NavigationPage, para permitir la navegacion entre pags 
            //y se enlaza la pagina principal (login).
            MainPage = new NavigationPage(new login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
