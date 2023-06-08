using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2P2023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEmple : ContentPage
    {

        Plugin.Media.Abstractions.MediaFile photo = null;



        public PageEmple()
        {
            InitializeComponent();
        }

        public String Getimage64()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[]  fotobyte = memory.ToArray();

                    String Base64 = Convert.ToBase64String(fotobyte);

                    return Base64;
                }
            }

            return null;
        }

        public byte[] GetimageBytes()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();
                    
                    return fotobyte;
                }

            }

            return null;
        }


        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            var emple = new Models.Empleados
            {
                Nombres = nombres.Text,
                Apellidos = apellidos.Text,
                Fechanac =  fecha.Date,
                Telefono = telefono.Text,
                foto = GetimageBytes()
            };

            if (await App.Instancia.AddEmple(emple) > 0)
            {
                await DisplayAlert("Aviso", "Empleado ingresado con exito", "OK");
            }
            else
                await DisplayAlert("Aviso", "a ocurrido un error", "OK");

        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MYAPP",
                Name = "Foto.jpg",
                SaveToAlbum = true
            });

            if(photo != null) 
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }
    }
}