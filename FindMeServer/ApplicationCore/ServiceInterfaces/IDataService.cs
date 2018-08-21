using ApplicationCore.DataTransferObjects;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IDataService
    {
        IEnumerable<Lost> GetLosts();
        IEnumerable<Institution> GetInstitutions();
        Task<LostDTO> RegisterLost(Lost lost);
    }
}