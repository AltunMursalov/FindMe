using FindMePrism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMePrism.Repositories
{
    interface IAuthenticationRepository
    {
        Institution Validate(string login, string password);
    }
}
