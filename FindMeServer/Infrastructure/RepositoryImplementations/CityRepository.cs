using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Database;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementations
{
    public class CityRepository : ICityRepository
    {
        private readonly FindMeDbContext context;

        public CityRepository(FindMeDbContext context)
        {
            this.context = context;
        }

        public async Task<City> CreateCity(City newCity)
        {
            try
            {
                var result = await this.context.Cities.AddAsync(newCity);
                await this.context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public City GetCityById(int id)
        {
            return this.context.Cities.FirstOrDefault(c => c.Id == id);
        }

        public City GetCityByName(string name)
        {
            return this.context.Cities.FirstOrDefault(c => c.Name == name);
        }

        public void RemoveCity(City city)
        {
            this.context.Cities.Remove(city);
        }
    }
}
