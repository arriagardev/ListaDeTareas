using ListaDeTareas.Data;
using ListaDeTareas.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaDeTareas
{
    public partial class App : Application
    {
        public static ListaDeTareasRepository TareasRepository = new ListaDeTareasRepository();

        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new NavigationPage(new ListaDeTareasView());
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
