using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EjercicioDosPuntoCuatro.Views;
using Xam.Forms.VideoPlayer;
using Xamarin.Essentials;
using System.IO;


namespace EjercicioDosPuntoCuatro
{
    public partial class MainPage : ContentPage
    {
        public string PhotoPath;

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnVideo_Clicked(object sender, EventArgs e)
        {
            TomarVideoDeGaleria();
        }

        public async void TomarVideoDeGaleria()
        {
            try
            {
                var photo = await MediaPicker.PickVideoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
                //await DisplayAlert("as", PhotoPath, "ok");

                UriVideoSource uriVideoSurce = new UriVideoSource()
                {
                    Uri = PhotoPath
                };
                videoPlayer.Source = uriVideoSurce;
            }

            catch (FeatureNotSupportedException)
            {
            }
            catch (PermissionException)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        public async void TomarVideoTiempoReal()
        {
            try
            {
                var photo = await MediaPicker.CaptureVideoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
                //await DisplayAlert("as", PhotoPath, "ok");

                UriVideoSource uriVideoSurce = new UriVideoSource()
                {
                    Uri = PhotoPath
                };

                videoPlayer.Source = uriVideoSurce;
            }
            catch (FeatureNotSupportedException)
            {
            }
            catch (PermissionException)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
            await stream.CopyToAsync(newStream);
            PhotoPath = newFile;
        }

        private void videoPlayer_PlayCompletion(object sender, EventArgs e)
        {
        }

        private void btnreproducir_Clicked(object sender, EventArgs e)
        {
            TomarVideoTiempoReal();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Guardar_Datos();
        }

        public async void Guardar_Datos()
        {
            var videos = new Models.Videos
            {
                Url_video = PhotoPath,
                Descripcion = txtPineda.Text
            };

            var resultado = await App.BaseDatos.GrabarVideos(videos);

            if (resultado == 1)
            {
                await DisplayAlert("Mensaje", "Video Registrado.", "ok");               
            }
            else
            {
                await DisplayAlert("Error", "No se pudo Guardar", "ok");
            }
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListVideoPage());
        }
    }
}
