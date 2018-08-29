using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMePrism.Models;
using FindMePrism.Repositories;

namespace FindMePrism.Services
{
    class LostService : ILostService
    {
        private readonly ILostRepository Repository;

        public LostService(ILostRepository repository)
        {
            Repository = repository;
        }

        public bool AddLost(Institution institution, Lost lost)
        {
            return Repository.AddLost(institution, lost);
        }

        public bool EditLost(Institution institution, Lost lost)
        {
            return Repository.EditLost(institution, lost);
        }

        public bool RemoveLost(Institution institution, Lost lost)
        {
            return Repository.RemoveLost(institution, lost);
        }

        public IEnumerable<Lost> GetLosts(Institution institution)
        {
            return Repository.GetLosts(institution);
        }

        public IEnumerable<string> GetEyeColors()
        {
            return Repository.GetEyeColors();
        }

        public IEnumerable<string> GetHairColors()
        {
            return Repository.GetHairColors();
        }

        public IEnumerable<string> GetGenders()
        {
            return Repository.GetGenders();
        }

        public IEnumerable<string> GetBodyTypes()
        {
            return Repository.GetBodyTypes();
        }
    }
}
