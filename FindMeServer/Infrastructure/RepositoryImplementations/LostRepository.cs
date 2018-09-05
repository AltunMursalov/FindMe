using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementations
{
    public class LostRepository : ILostRepository
    {
        private readonly FindMeDbContext context;

        public LostRepository(FindMeDbContext context)
        {
            this.context = context;
        }

        public async Task<Lost> CreateLost(Lost newLost)
        {
            var isAlreadyExist = await this.context.Losts.FirstOrDefaultAsync(l => l.FirstName == newLost.FirstName &&
                                                                            l.MiddleName == newLost.MiddleName &&
                                                                            l.LastName == newLost.LastName);
            if (isAlreadyExist != null)
            {
                return null;
            }
            else
            {
                var result = await this.context.Losts.AddAsync(newLost);
                await this.context.SaveChangesAsync();
                return await this.GetLostById(result.Entity.Id);
            }
        }

        public async Task<Lost> GetLostById(int id)
        {
            return await this.context.Losts.
                                  Include(l => l.Institution).
                                  Include(l => l.Institution.City).
                                  Include(l => l.Institution.InstitutionType).
                                  FirstOrDefaultAsync(l => l.Id == id);
        }

        public IEnumerable<Lost> GetLosts()
        {
            return this.context.Losts.
                Include(l => l.Institution).
                Include(l => l.Institution.City).
                Include(l => l.Institution.InstitutionType).
                ToList();
        }
    }
}