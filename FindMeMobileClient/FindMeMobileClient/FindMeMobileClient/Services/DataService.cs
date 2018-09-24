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

        public async Task<IEnumerable<Lost>> GetLosts()
        {
            var response = await client.GetAsync($"{App.MobileServiceUrl}/api/losts/getlosts");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Lost>>(data);
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