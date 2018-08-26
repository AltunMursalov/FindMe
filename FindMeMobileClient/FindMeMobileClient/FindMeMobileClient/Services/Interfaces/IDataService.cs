using FindMeMobileClient.Models;
using System.Collections.Generic;

namespace FindMeMobileClient.Services.Interfaces
{
    public interface IDataService
    {
        IEnumerable<Lost> GetLosts();
        IEnumerable<Institution> GetInstitutions();
    }
}