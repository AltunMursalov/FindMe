using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMePrism.Models;

namespace FindMePrism.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public Institution Validate(string login, string password)
        {
            //server
            City c = new City { Id = 1, Name = "Baku" };
            var i = new Institution {
                Id = 1,
                Name = "Instutution",
                Address = "Address",
                Number = "9379992",
                OpeningHours = "09.00 - 23.00",
                Website = "www.findme.az",
                InstitutionCity = c
            };
            return i;
        }
    }
}
