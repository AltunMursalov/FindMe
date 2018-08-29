using FindMePrism.Models;
using FindMePrism.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMePrism.Services
{
    class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository Repository;

        public AuthenticationService(IAuthenticationRepository repository)
        {
            Repository = repository;
        }

        public Institution Validate(string login, string password)
        {
            return Repository.Validate(login, password);
        }
    }
}
