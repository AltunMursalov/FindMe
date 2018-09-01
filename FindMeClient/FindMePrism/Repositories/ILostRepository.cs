using FindMePrism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMePrism.Repositories
{
    interface ILostRepository
    {
        IEnumerable<Lost> GetLosts(Institution institution);
        Lost AddLost(Institution institution, Lost lost);
        bool RemoveLost(Institution institution, Lost lost);
        bool EditLost(Institution institution, Lost lost);
        IEnumerable<string> GetEyeColors();
        IEnumerable<string> GetHairColors();
        IEnumerable<string> GetGenders();
        IEnumerable<string> GetBodyTypes();
    }
}
