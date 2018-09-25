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

        public async Task<IEnumerable<Institution>> GetInstitutions()
        {
            return await this.context.Institutions.
                                Include(i => i.City).
                                Include(i => i.InstitutionType).
                                Where(i => !i.IsAdmin).
                                ToListAsync();
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

        public async Task<int> UpdateInstitution(Institution institution)
        {
            this.context.Institutions.Update(institution);
            return await this.context.SaveChangesAsync();
        }

        public async Task<int> RemoveInstitution(int id)
        {
            this.context.Institutions.Remove(await this.context.Institutions.FirstOrDefaultAsync(i => i.Id == id));
            return await this.context.SaveChangesAsync();
        }
    }
}