using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface ILostRepository
    {
        Task<Lost> CreateLost(Lost newLost);
        Task<Lost> GetLostById(int id);
        IEnumerable<Lost> GetLosts();
    }
}