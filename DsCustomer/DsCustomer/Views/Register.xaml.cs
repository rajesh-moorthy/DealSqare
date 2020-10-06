using Notes.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DsCustomer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

   

        private async void Register_Clicked(object sender, EventArgs e)
        {

            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://localhost:56103/api/Registrations ");

            if (response==null)
            {
                Registration Registration = new Registration
                {
                    Name = Name1.Text,
                    Email = Email1.Text
                Password = Pass.Text

                };
                var httpClient = new HttpClient();
                var Json = JsonConvert.SerializeObject(employee);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                httpClient.PostAsync("http://localhost:56103/Api/Registration", httpContent);
                DisplayAlert("Added", "Your Data has been added", "OK");
            }
            else
            {

            }
            //var employee = JsonConvert.DeserializeObject<List<employee>>(response);
            //LV.ItemsSource = employee;
        }
    }
}