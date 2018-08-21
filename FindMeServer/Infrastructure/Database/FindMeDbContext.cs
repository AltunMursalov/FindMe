using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class FindMeDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Lost> Losts { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<InstitutionType> InstitutionTypes { get; set; }

        public FindMeDbContext(DbContextOptions<FindMeDbContext> options) : base(options)
        {

        }
    }
}