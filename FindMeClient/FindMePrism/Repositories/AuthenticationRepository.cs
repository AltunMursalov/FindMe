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
            var i = new Institution();
            return i;
        }
    }
}
