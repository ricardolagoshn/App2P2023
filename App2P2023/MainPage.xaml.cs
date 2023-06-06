using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2P2023
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btn_guardar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", String.Format("{0} {1}", nombres.Text, apellidos.Text)  , "OK");
        }
    }
}
