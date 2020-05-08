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

            MainPage = new NavigationPage(new login()); //Se establece la forma de navegacion entre paginas con la clase NavigationPage
                                                        //y donde se iniciara la App (login)
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
