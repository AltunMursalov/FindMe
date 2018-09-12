using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DataTransferObjects;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;

namespace ApplicationCore.ServiceImplementations
{
    public class DataService : IDataService
    {
        private readonly ILostRepository lostRepository;
        private readonly IInstitutionRepository institutionRepository;
        private readonly IMapper mapper;

        public DataService(ILostRepository lostRepository, IInstitutionRepository institutionRepository, IMapper mapper)
        {
            this.mapper = mapper;
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
                return this.mapper.Map<Lost, LostDTO>(result);
            }
            else
            {
                return null;
            }
        }
    }
}