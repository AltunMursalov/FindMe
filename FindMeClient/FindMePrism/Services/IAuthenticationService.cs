using FindMePrism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMePrism.Services
{
    interface IAuthenticationService
    {
        Institution Validate(string login, string password);
    }
}
