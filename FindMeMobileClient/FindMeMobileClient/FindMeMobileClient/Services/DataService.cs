using FindMeMobileClient.Models;
using FindMeMobileClient.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FindMeMobileClient.Services {
    public class DataService : IDataService {
        private readonly HttpClient client;
        public DataService() {
            this.client = new HttpClient {
                Timeout = TimeSpan.FromSeconds(15),
                BaseAddress = new Uri(App.MobileServiceUrl)
            };
        }

        public async Task<IEnumerable<Lost>> GetLosts() {
            var response = await this.client.GetAsync("/api/losts/getlosts");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Lost>>(data);
            }
            return null;
        }

        public async Task<IEnumerable<Institution>> GetInstitutions() {
            var response = await this.client.GetAsync("/api/institutions/getinstitutions");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Institution>>(data);
            }
            return null;
        }
    }
}