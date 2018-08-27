using FindMeMobileClient.Models;
using FindMeMobileClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace FindMeMobileClient.Services {
    public class DataService : IDataService {
        private List<Lost> losts = new List<Lost>();

        public DataService() {
            losts.Add(new Lost(false, losts.Count + 1, "Orkhan", "Aydin", "Ansar", "Orkhan Ansar Aydin", "Blue", "Black", "sdjc",
                "Normal", "signs", 20, 20, 178, "", "comment", "description", "detdes", DateTime.Now, "Male", 1, new Institution { Address = "address", Id = 1, Number = "5555", Name = "Institution Name", InstitutionCity = new City { Name = "London" } }));
            losts.Add(new Lost(false, losts.Count + 1, "John"
               , "", "Doe", "Orkhan Ansar", "Blue", "Brown",
                "pink trousers", "Fat", "headless", 19, 19, 178, "", "Comment", "description", "detection description",
                DateTime.Now, "Man", 1, new Institution { Address = "address", Id = 1, Number = "+994508556321" }));
            losts.Add(new Lost(false, losts.Count + 1, "John"
               , "", "Doe", "Rohan Ansareon", "Blue", "Brown",
                "pink trousers", "Fat", "headless", 19, 19, 178, "", "Comment", "description", "detection description",
                DateTime.Now, "Man", 1, new Institution { Address = "address", Id = 1, Number = "+994508556321" }));
            losts.Add(new Lost(false, losts.Count + 1, "John"
               , "", "Doe", "Altun Dawnich", "Blue", "Brown",
                "pink trousers", "Fat", "headless", 19, 19, 178, "", "Comment", "description", "detection description",
                DateTime.Now, "Man", 1, new Institution { Address = "address", Id = 1, Number = "+994508556321" }));
            losts.Add(new Lost(false, losts.Count + 1, "John"
               , "", "Doe", "Altun Dawnich", "Blue", "Brown",
                "pink trousers", "Fat", "headless", 19, 19, 178, "", "Comment", "description", "detection description",
                DateTime.Now, "Man", 1, new Institution { Address = "address", Id = 1, Number = "+994508556321" }));
            losts.Add(new Lost(false, losts.Count + 1, "John"
               , "", "Doe", "Altun Dawnich", "Blue", "Brown",
                "pink trousers", "Fat", "headless", 19, 19, 178, "", "Comment", "description", "detection description",
                DateTime.Now, "Man", 1, new Institution { Address = "address", Id = 1, Number = "+994508556321" }));
        }

        public IEnumerable<Lost> GetLosts() {
            return losts;
        }

        public IEnumerable<Institution> GetInstitutions() {
            var institutions = new List<Institution>();
            institutions.Add(new Institution {
                Id = 1,
                Address = "221B Baker Street",
                InstitutionCity = new City { Id = 1, Name = "London" },
                Name = "Sherlock Holmes Consulting Detective",
                CityId = 1,
                Number = "+994508556321",
                OpeningHours = "19:00 - 21:00",
                Website = "vk.com"
            });
            institutions.Add(new Institution {
                Id = 2,
                Address = "222B Baker Street",
                InstitutionCity = new City { Id = 1, Name = "London" },
                Name = "Sherlock Holmes neighbor",
                CityId = 1,
                Number = "+994508556322",
                OpeningHours = "17:00 - 20:00",
                Website = "ok.com"
            });
            institutions.Add(new Institution {
                Id = 3,
                Address = "223B Baker Street",
                InstitutionCity = new City { Id = 1, Name = "London" },
                Name = "Some place",
                CityId = 1,
                Number = "+994508556322",
                OpeningHours = "17:00 - 20:00",
                Website = "ok.com"
            });
            institutions.Add(new Institution {
                Id = 3,
                Address = "223B Baker Street",
                InstitutionCity = new City { Id = 1, Name = "London" },
                Name = "Some place",
                CityId = 1,
                Number = "+994508556322",
                OpeningHours = "17:00 - 20:00",
                Website = "ok.com"
            });
            institutions.Add(new Institution {
                Id = 3,
                Address = "223B Baker Street",
                InstitutionCity = new City { Id = 1, Name = "London" },
                Name = "Some place",
                CityId = 1,
                Number = "+994508556322",
                OpeningHours = "17:00 - 20:00",
                Website = "ok.com"
            });
            institutions.Add(new Institution {
                Id = 3,
                Address = "223B Baker Street",
                InstitutionCity = new City { Id = 1, Name = "London" },
                Name = "Some place",
                CityId = 1,
                Number = "+994508556322",
                OpeningHours = "17:00 - 20:00",
                Website = "ok.com"
            });
            return institutions;
        }
    }
}