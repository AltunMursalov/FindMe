﻿using FindMePrism.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FindMePrism.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient client;

        public AuthenticationService()
        {
            this.client = new HttpClient();
        }


        public async Task<Institution> Validate(Institution institution)
        {
            var data = JsonConvert.SerializeObject(institution);
            var content = new StringContent(data, UnicodeEncoding.UTF8, "application/json");

            var response = await this.client.PostAsync("http://localhost:51662/api/institutions/login", content);
            if (response.IsSuccessStatusCode)
            {
                var answer = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Institution>(answer);
            }
            else
                return null;
        }
    }
}
