using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2P2023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListEmple : ContentPage
    {
        public PageListEmple()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            list.ItemsSource = await App.Instancia.GetAll();
        }
        private async void tooladd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageEmple());
        }

        private async void toolist_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageListEmple());
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}