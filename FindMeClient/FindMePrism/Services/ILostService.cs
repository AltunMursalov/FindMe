using FindMePrism.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindMePrism.Services
{
    public interface ILostService
    {
        Task<IEnumerable<Lost>> GetLosts(Institution institution);
        Task<Lost> AddLostAsync(Institution institution, Lost lost);
        Task<bool> RemoveLost(Lost lost);
        Task<bool> EditLost(Lost lost);
        IEnumerable<string> GetEyeColors();
        IEnumerable<string> GetHairColors();
        IEnumerable<string> GetGenders();
        IEnumerable<string> GetBodyTypes();
    }
}
