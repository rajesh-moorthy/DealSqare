using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DsCustomer.Models;
using Newtonsoft.Json;

namespace DsCustomer.ViewModel
{
    class CountryViewModel
    {
        public ObservableCollection<Country> country { get; set; }

        public CountryViewModel()
        {
            Task<List<Country>> task = ApiService.GetCountry();

            country = new ObservableCollection<Country>(task.Result);
        }

        public class ApiService
        {
            public const string Url = "http://192.168.0.106:8080";
            public static async Task<List<Country>> GetCountry()
            {
                try
                {
                    HttpClient client = new HttpClient();
                    string url = Url + "/api/GetCountries";
                    string response = await client.GetStringAsync(url);
                    List<Country> ctry = JsonConvert.DeserializeObject<List<Country>>(response);
                    return ctry;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
