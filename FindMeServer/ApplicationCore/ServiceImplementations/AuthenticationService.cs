using ApplicationCore.DataTransferObjects;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceImplementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILostRepository lostRepository;
        private readonly IInstitutionRepository institutionRepository;

        public AuthenticationService(ILostRepository lostRepository, IInstitutionRepository institutionRepository)
        {
            this.lostRepository = lostRepository;
            this.institutionRepository = institutionRepository;
        }

        public async Task<InstitutionDTO> Login(Institution institutionFromClient)
        {
            var institutionFromServer = await this.institutionRepository.GetInstitutionByName(institutionFromClient.Name);
            if (institutionFromServer != null)
            {
                var decryptResult = Cryptor.DecryptPassword(institutionFromServer.Password, institutionFromClient.Password);
                if (decryptResult)
                {
                    return new InstitutionDTO(institutionFromServer.Name, institutionFromServer.Address, institutionFromServer.Phone,
                                institutionFromServer.OpeningHours, institutionFromServer.Website, institutionFromServer.IsAdmin,
                                new InstitutionTypeDTO(institutionFromServer.InstitutionType.Type), 
                                new CityDTO(institutionFromServer.City.Name));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<InstitutionDTO> RegisterInstitution(Institution institution)
        {
            institution.Password = Cryptor.EncryptPassword(institution.Password);
            var result = await this.institutionRepository.CreateInstitution(institution);
            if (result != null)
            {
                return new InstitutionDTO(result.Name, result.Address, result.Phone, result.OpeningHours, result.Website, result.IsAdmin,
                                            new InstitutionTypeDTO(result.InstitutionType.Type), new CityDTO(result.City.Name));
            }
            else
            {
                return null;
            }
        }
    }
}