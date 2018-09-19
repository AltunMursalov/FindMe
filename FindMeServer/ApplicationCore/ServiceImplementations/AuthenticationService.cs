using ApplicationCore.DataTransferObjects;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceImplementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper mapper;
        private readonly ILostRepository lostRepository;
        private readonly IInstitutionRepository institutionRepository;

        public AuthenticationService(ILostRepository lostRepository, IInstitutionRepository institutionRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.lostRepository = lostRepository;
            this.institutionRepository = institutionRepository;
        }

        public async Task<InstitutionDTO> Login(Institution institutionFromClient)
        {
            var institutionFromServer = await this.institutionRepository.GetInstitutionByLogin(institutionFromClient.Login);
            if (institutionFromServer != null)
            {
                var isValidPassword = Cryptor.DecryptPassword(institutionFromServer.Password, institutionFromClient.Password);
                if (isValidPassword)
                {
                    return this.mapper.Map<Institution, InstitutionDTO>(institutionFromServer);
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
                return this.mapper.Map<Institution, InstitutionDTO>(result);
            }
            else
            {
                return null;
            }
        }
    }
}