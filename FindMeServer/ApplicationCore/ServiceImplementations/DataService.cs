using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DataTransferObjects;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace ApplicationCore.ServiceImplementations
{
    public class DataService : IDataService
    {
        private readonly ILostRepository lostRepository;
        private readonly IInstitutionRepository institutionRepository;

        public DataService(ILostRepository lostRepository, IInstitutionRepository institutionRepository)
        {
            this.lostRepository = lostRepository;
            this.institutionRepository = institutionRepository;
        }

        public IEnumerable<Institution> GetInstitutions()
        {
            return this.institutionRepository.GetInstitutions();
        }

        public IEnumerable<Lost> GetLosts()
        {
            return this.lostRepository.GetLosts();
        }

        public async Task<LostDTO> RegisterLost(Lost lost)
        {
            var result = await this.lostRepository.CreateLost(lost);
            if (result != null)
            {
                return new LostDTO(result.FirstName, result.MiddleName, result.Clothes, result.BodyType, result.EyeColor, result.HairColor,
                    result.Signs, result.LastName, result.AgeBegin, result.AgeEnd, result.Height, result.ImagePath, result.Comment,
                    result.Description, result.DetectionDescription, result.DetectionTime, result.Gender, new InstitutionDTO(
                    result.Institution.Name, result.Institution.Address, result.Institution.Phone, result.Institution.OpeningHours,
                    result.Institution.Website, result.Institution.IsAdmin, new InstitutionTypeDTO(result.Institution.InstitutionType.Type),
                    new CityDTO(result.Institution.City.Name)));
            }
            else
            {
                return null;
            }
        }
    }
}