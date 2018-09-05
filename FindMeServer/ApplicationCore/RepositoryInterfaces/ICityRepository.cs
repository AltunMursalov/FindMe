using ApplicationCore.Models;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface ICityRepository
    {
        Task<City> CreateCity(City newCity);
        void RemoveCity(City city);
        City GetCityByName(string name);
        City GetCityById(int id);
    }
}