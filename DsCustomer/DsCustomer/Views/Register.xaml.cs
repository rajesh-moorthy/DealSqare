﻿using DsCustomer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DsCustomer.Models;
using System.Net.Http.Headers;
using DsCustomer.ViewModel;
using System.Net;
using DsCustomer;

namespace DsCustomer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        AppConstants Ac = new AppConstants();
        
        public Register()
        {
            InitializeComponent();
            CustomerType.SelectedIndexChanged += (sender, args) =>
              {
                  if (CustomerType.SelectedIndex == 0)
                  {
                      GST.IsVisible = false;
                  }
                  else
                  {
                      GST.IsVisible = true;
                  }
              };
            
             GetCountry();
            
            pkrCountry.SelectedIndexChanged += (sender, args) =>
              {
                  GetStateByCountry(Convert.ToInt32(pkrCountry.SelectedItem));
              };
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }



        private async void Register_Clicked(object sender, EventArgs e)
        {
            var baseUrl = "http://192.168.0.106:8080";
            if (CustomerType.SelectedIndex == 0)
            {
                baseUrl += "/api/GetUsersByMobile/" + Mobile.Text;
            }
            else
            {
                baseUrl += "api/GetVendorsByMobile/" + Mobile.Text;
            }
            // check if the mobile number exists
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(baseUrl);
            // If there is no record add the record to the web as well as local
            if (response == null)
            {

                User user = new User
                {
                    Name = Name.Text,
                    Mobile = Mobile.Text,
                    Email = Email.Text,
                    Password = Password.Text,
                    UserType = CustomerType.SelectedIndex,
                    Created = DateTime.UtcNow

                };
                var Json = JsonConvert.SerializeObject(user);


                if (CustomerType.SelectedIndex == 0)
                {
                    Customer cust = new Customer
                    {
                        CustomerName = Name.Text,
                        MobileNumber = Mobile.Text,
                        EmailId = Email.Text,
                        Password = Password.Text,
                        Created = DateTime.UtcNow
                    };
                    Json = JsonConvert.SerializeObject(cust);
                    baseUrl += "api/CreateCustomer/" + Json;
                }
                else
                {
                    Vendors vend = new Vendors
                    {
                        VendorName = Name.Text,
                        MobileNumber = Mobile.Text,
                        EmailId = Email.Text,
                        Password = Password.Text,
                        Active = 1
                    };
                    Json = JsonConvert.SerializeObject(vend);
                    baseUrl += "api/CreateCustomer/" + Json;
                }

                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                await httpClient.PostAsync("http://localhost:56103/Api/Registration", httpContent);
                await DisplayAlert("Added", "Your Data has been added", "OK");
            }
            else
            {
                await DisplayAlert("Added", "You are already registered.  Please Login", "OK");
            }
            //var employee = JsonConvert.DeserializeObject<List<employee>>(response);
            //LV.ItemsSource = employee;
        }

        private async void GetCountry()
        {
            try
            {
                HttpClient client = new HttpClient();
                var baseUrl = Ac.BaseURL;
                baseUrl += "/api/GetCountries";
                var response = await client.GetStringAsync(baseUrl);
                var ctry = JsonConvert.DeserializeObject<List<Country>>(response);
                pkrCountry.ItemsSource = ctry;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async void GetStateByCountry(int CountryId)
        {
            try
            {
                HttpClient client = new HttpClient();
                var baseUrl = Ac.BaseURL;
                baseUrl += "/api/GetActiveStatesByCountry/" + CountryId;
                var response = await client.GetStringAsync(baseUrl);
                var ctry = JsonConvert.DeserializeObject<List<Country>>(response);
                pkrCountry.ItemsSource = ctry;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void pkrCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
///9994221429 - Muthu
