using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xam.Forms.VideoPlayer;
using EjercicioDosPuntoCuatro.Models;

namespace EjercicioDosPuntoCuatro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordVideoPage : ContentPage
    {
        public RecordVideoPage(Videos datos)
        {
            InitializeComponent();
            descripcion.Text = datos.Descripcion;
            UriVideoSource uriVideoSurce = new UriVideoSource()
            {
                Uri = datos.Url_video
            };
            videoPlayer.Source = uriVideoSurce;
        }

        private void videoPlayer_PlayCompletion(object sender, EventArgs e)
        {
        }

    }
}