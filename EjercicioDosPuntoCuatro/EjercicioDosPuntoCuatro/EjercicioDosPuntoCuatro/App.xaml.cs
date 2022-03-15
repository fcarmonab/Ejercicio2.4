using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EjercicioDosPuntoCuatro.Controller;
using System.IO;

namespace EjercicioDosPuntoCuatro
{
    public partial class App : Application
    {
        static VideosDB basedatos;

        public static VideosDB BaseDatos 
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new VideosDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VideosDB.db3"));
                }
                return basedatos;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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
