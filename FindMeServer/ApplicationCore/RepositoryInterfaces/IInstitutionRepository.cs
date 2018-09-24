using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IInstitutionRepository
    {
        Task<Institution> CreateInstitution(Institution newInstitution);
        Task<Institution> GetInstitutionByName(string name);
        Task<Institution> GetInstitutionByLogin(string login);
        Task<Institution> GetInstitutionById(int id);
        Task<bool> UpdateInstitution(Institution institution);
        Task<bool> RemoveInstitution(Institution institution);
        IEnumerable<Institution> GetInstitutions();
        Task<Institution> GetInstitutionByNameAndPassword(string name, string password);
    }
}