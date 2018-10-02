using FindMeMobileClient.Models;
using FindMeMobileClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMeMobileClient.Services {
    public class SubscribeService : ISubscribeService {
        private readonly List<Filter> subscribedFilters;

        public SubscribeService() {
            subscribedFilters = new List<Filter>();
            subscribedFilters.Add(new Filter {
                FilterDate = DateTime.Now,
                AgeBegin = 18,
                AgeEnd = 20,
                BodyType = "Normal",
                EyeColor = "Black",
                FirstName = "Orkhan",
                Gender = "Male",
                HairColor = "Black",
                Height = 178,
                LastName = "Ansar",
                MiddleName = "Aydin"
            });
            subscribedFilters.Add(new Filter {
                FilterDate = DateTime.Now,
                AgeBegin = 17,
                AgeEnd = 17,
                BodyType = "Normal",
                EyeColor = "Black",
                FirstName = "Altun",
                Gender = "Male",
                HairColor = "Black",
                Height = 187,
                LastName = "Mursalov",
                MiddleName = "idk"
            });
            subscribedFilters.Add(new Filter {
                FilterDate = DateTime.Now,
                AgeBegin = 42,
                AgeEnd = 42,
                BodyType = "Normal",
                EyeColor = "Black",
                FirstName = "John",
                Gender = "Male",
                HairColor = "Black",
                Height = 172,
                LastName = "Doe",
                MiddleName = "Developer"
            });
        }

        public void AddSubscribedFilter() {
            subscribedFilters.Add(App.Filter);
        }

        /// <summary>
        /// Delete subscribed filter by key
        /// </summary>
        /// <param name="key">key of the object in dictionary with filters</param>
        /// <returns>returns 0 if process is successfull
        /// 1 if process is unsuccessfull</returns>
        public void DeleteSubscribedFilter(DateTime filterDate) {
            subscribedFilters.Remove(subscribedFilters.First(p => p.FilterDate == filterDate));
        }

        public List<Filter> GetSubscribedFilters() {
            return subscribedFilters;
        }
    }
}
