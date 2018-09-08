using FindMeMobileClient.Models;
using System.Collections.Generic;

namespace FindMeMobileClient.Services.Interfaces
{
    public interface IDataService
    {
        IEnumerable<Lost> GetLosts();
        IEnumerable<Institution> GetInstitutions();
        void Subscribe(Filter filter);
        void Unsubscribe(Filter filter);
    }
}