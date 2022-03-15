using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EjercicioDosPuntoCuatro.Models;

namespace EjercicioDosPuntoCuatro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListVideoPage : ContentPage
    {
        public ListVideoPage()
        {
            InitializeComponent();
            cargarListado();
        }

        public async void cargarListado()
        {
            var lista = await App.BaseDatos.ObtenerListaVideos();
            lstvideos.ItemsSource = lista;
        }

        private async void lstvideos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            lstvideos.SelectedItem = null;
            try 
            {
                Models.Videos item = (Models.Videos)e.Item;
                var newpage = new RecordVideoPage(item);
                newpage.BindingContext = item;
                await Navigation.PushAsync(newpage);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }

        private void lstvideos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }

        private async void VerDetalles(object sender, EventArgs e)
        {
            SwipeItem item = sender as SwipeItem;
            Videos model = item.BindingContext as Videos;
            await Navigation.PushAsync(new RecordVideoPage(model));
        }
    }
}