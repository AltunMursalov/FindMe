using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Database
{
    public class FindMeDbContextFactory : IDesignTimeDbContextFactory<FindMeDbContext>
    {
        public FindMeDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FindMeDbContext>();
            builder.UseSqlServer(
                "Data Source=.;Initial Catalog=FindMe;Trusted_Connection=true;");
            return new FindMeDbContext(builder.Options);
        }
    }
}