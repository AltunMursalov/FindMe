using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FindMePrism.Models;
using Newtonsoft.Json;

namespace FindMePrism.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly HttpClient client;

        public InstitutionService()
        {
            this.client = new HttpClient();
        }

        public async Task<Institution> AddInstitution(Institution institution)
        {
            var data = JsonConvert.SerializeObject(institution);
            var content = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var response = await this.client.PostAsync("http://localhost:51662/api/institutions/registerinstitution", content);
            if (response.IsSuccessStatusCode)
            {
                var answer = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Institution>(answer);
            }
            else
                return null;
        }

        public async Task<bool> EditInstitution(Institution institution)
        {
            var data = JsonConvert.SerializeObject(institution);
            var content = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var response = await this.client.PutAsync("http://localhost:51662/api/institutions/editinstitution", content);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<Institution>> GetInstitutions()
        {

            var response = await this.client.GetAsync("http://localhost:51662/api/institutions/getinstitutionsadmin");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Institution>>(data);
            }
            else
                return null;
        }


        public async Task<bool> RemoveInstitution(Institution institution)
        {
            var response = await client.DeleteAsync($"/api/losts/deleteinstitution/{institution.Id}");
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public IEnumerable<InstitutionType> GetInstitutionTypes()
        {
            List<InstitutionType> Types = new List<InstitutionType>() {
                new InstitutionType{ Id = 1, Type = "Medical"}
            };
            return Types;
        }
    }
}