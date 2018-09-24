using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Database;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementations
{
    public class InstitutionRepository : IInstitutionRepository
    {
        private readonly FindMeDbContext context;

        public InstitutionRepository(FindMeDbContext context)
        {
            this.context = context;
        }

        public async Task<Institution> CreateInstitution(Institution newInstitution)
        {
            var result = await this.context.Institutions.AddAsync(newInstitution);
            await this.context.SaveChangesAsync();
            return await this.GetInstitutionById(result.Entity.Id);
        }



        public async Task<Institution> GetInstitutionById(int id)
        {
            return await this.context.Institutions.
                                      Include(i => i.City).
                                      Include(i => i.InstitutionType).
                                      FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Institution> GetInstitutionByName(string name)
        {
            return await this.context.Institutions.
                                      Include(i => i.City).
                                      Include(i => i.InstitutionType).
                                      FirstOrDefaultAsync(i => i.Name == name);
        }

        public IEnumerable<Institution> GetInstitutions()
        {
            return this.context.Institutions.
                                Include(i => i.City).
                                Include(i => i.InstitutionType).
                                Where(i => !i.IsAdmin).
                                ToList();
        }

        public async Task<Institution> GetInstitutionByNameAndPassword(string name, string password)
        {
            return await this.context.Institutions.
                                      Include(i => i.City).
                                      Include(i => i.InstitutionType).
                                      FirstOrDefaultAsync(i => i.Name == name && i.Password == password);
        }

        public async Task<Institution> GetInstitutionByLogin(string login)
        {
            return await this.context.Institutions.
                                      Include(i => i.City).
                                      Include(i => i.InstitutionType).
                                      FirstOrDefaultAsync(i => i.Login == login);
        }

        public async Task<bool> UpdateInstitution(Institution institution)
        {
            this.context.Institutions.Update(institution);
            var res = await this.context.SaveChangesAsync();
            if (res > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> RemoveInstitution(Institution institution)
        {
            this.context.Institutions.Remove(institution);
            var res = await this.context.SaveChangesAsync();
            if (res > 0)
                return true;
            else
                return false;
        }
    }
}