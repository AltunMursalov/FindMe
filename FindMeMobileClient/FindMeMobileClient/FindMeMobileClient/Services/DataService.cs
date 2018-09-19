using FindMeMobileClient.Models;
using FindMeMobileClient.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FindMeMobileClient.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient client;
        public DataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(App.MobileServiceUrl);
        }

        public IEnumerable<Lost> GetLosts()
        {
            var response = client.GetAsync($"{App.MobileServiceUrl}/api/losts/getlosts").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Lost>>(data.Result);
            }
            else
            {
                throw new Exception("is not success status code");
            }
        }

        public IEnumerable<Institution> GetInstitutions()
        {
            throw new Exception("get institutuon");
        }
    }
}