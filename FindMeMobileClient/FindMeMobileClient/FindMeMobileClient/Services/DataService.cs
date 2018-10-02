using FindMeMobileClient.Models;
using FindMeMobileClient.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FindMeMobileClient.Services {
    public class DataService : IDataService {
        private readonly HttpClient client;
        public DataService() {
            client = new HttpClient {
                Timeout = TimeSpan.FromSeconds(15),
                BaseAddress = new Uri(App.MobileServiceUrl)
            };
        }

        public IEnumerable<Lost> GetLosts() {
            //var response = await client.GetAsync("/api/losts/getlosts");
            //if (response.IsSuccessStatusCode) {
            //    var data = await response.Content.ReadAsStringAsync();
            //    return JsonConvert.DeserializeObject<IEnumerable<Lost>>(data);
            //}
            //return null;
            var list = new List<Lost>();
            list.Add(new Lost(
                    false, 1, "Orkhan", "Aydin", "Ansar", "Orkhan Aydin Ansar", "Black", "Black",
                    "clothes", "Normal", "Signs", 18, 20, 178, "https://cdn.pixabay.com/photo/2016/03/31/19/57/avatar-1295406_960_720.png", "Comment",
                    "Description", "DetectionDescription", DateTime.Now, "Male", 1, new Institution {
                        Address = "HuseynCavid st. home 8",
                        CityId = 1,
                        Id = 1,
                        InstitutionCity = new City { Id = 1, Name = "Baku" },
                        Name = "Medical centre",
                        IsVisible = false,
                        Number = "+994508556321",
                        OpeningHours = "10:00-10:01",
                        Website = "www.website.com",
                        Latitude = 40.432892,
                        Longitude = 50.035452
                    }
                ));
            list.Add(new Lost(
                    false, 1, "John", "Developer", "Doe", "John Developer Doe", "Black", "Black",
                    "clothes", "Normal", "Signs", 42, 42, 172, "https://cdn.pixabay.com/photo/2016/03/31/19/57/avatar-1295406_960_720.png", "Comment",
                    "Description", "DetectionDescription", DateTime.Now, "Male", 1, new Institution {
                        Address = "Baker st.8",
                        CityId = 2,
                        Id = 2,
                        InstitutionCity = new City { Id = 2, Name = "London" },
                        Name = "Medical centre London",
                        IsVisible = false,
                        Number = "+1508556321",
                        OpeningHours = "10:00-10:01",
                        Website = "www.website.com",
                        Latitude = 40.432892,
                        Longitude = 50.035452
                    }
                ));
            list.Add(new Lost(
                    false, 1, "Jack", "Kenneth", "Coleman", "John Developer Doe", "Black", "Black",
                    "clothes", "Normal", "Signs", 42, 42, 172, "https://cdn.pixabay.com/photo/2016/03/31/19/57/avatar-1295406_960_720.png", "Comment",
                    "Description", "DetectionDescription", DateTime.Now, "Male", 1, new Institution {
                        Address = "Baker st.8",
                        CityId = 2,
                        Id = 2,
                        InstitutionCity = new City { Id = 2, Name = "London" },
                        Name = "Medical centre London",
                        IsVisible = false,
                        Number = "+1508556321",
                        OpeningHours = "10:00-10:01",
                        Website = "www.website.com",
                        Latitude = 40.432892,
                        Longitude = 50.035452
                    }
                ));
            list.Add(new Lost(
                    false, 1, "Carl", "Alexander", "Watson", "John Developer Doe", "Black", "Black",
                    "clothes", "Normal", "Signs", 42, 42, 172, "https://cdn.pixabay.com/photo/2016/03/31/19/57/avatar-1295406_960_720.png", "Comment",
                    "Description", "DetectionDescription", DateTime.Now, "Male", 1, new Institution {
                        Address = "Baker st.8",
                        CityId = 2,
                        Id = 2,
                        InstitutionCity = new City { Id = 2, Name = "London" },
                        Name = "Medical centre London",
                        IsVisible = false,
                        Number = "+1508556321",
                        OpeningHours = "10:00-10:01",
                        Website = "www.website.com",
                        Latitude = 40.432892,
                        Longitude = 50.035452
                    }
                ));
            list.Add(new Lost(
                    false, 1, "James", "Brooks", "Ward", "John Developer Doe", "Black", "Black",
                    "clothes", "Normal", "Signs", 42, 42, 172, "https://cdn.pixabay.com/photo/2016/03/31/19/57/avatar-1295406_960_720.png", "Comment",
                    "Description", "DetectionDescription", DateTime.Now, "Male", 1, new Institution {
                        Address = "Baker st.8",
                        CityId = 2,
                        Id = 2,
                        InstitutionCity = new City { Id = 2, Name = "London" },
                        Name = "Medical centre London",
                        IsVisible = false,
                        Number = "+1508556321",
                        OpeningHours = "10:00-10:01",
                        Website = "www.website.com",
                        Latitude = 40.432892,
                        Longitude = 50.035452
                    }
                ));
            list.Add(new Lost(
                    false, 1, "Ramirez", "Rodriguez", "Gray", "John Developer Doe", "Black", "Black",
                    "clothes", "Normal", "Signs", 42, 42, 172, "https://cdn.pixabay.com/photo/2016/03/31/19/57/avatar-1295406_960_720.png", "Comment",
                    "Description", "DetectionDescription", DateTime.Now, "Male", 1, new Institution {
                        Address = "Baker st.8",
                        CityId = 2,
                        Id = 2,
                        InstitutionCity = new City { Id = 2, Name = "London" },
                        Name = "Medical centre London",
                        IsVisible = false,
                        Number = "+1508556321",
                        OpeningHours = "10:00-10:01",
                        Website = "www.website.com",
                        Latitude = 40.432892,
                        Longitude = 50.035452
                    }
                ));
            list.Add(new Lost(
                    false, 1, "Cook", "Griffin", "Martin", "John Developer Doe", "Black", "Black",
                    "clothes", "Normal", "Signs", 42, 42, 172, "https://cdn.pixabay.com/photo/2016/03/31/19/57/avatar-1295406_960_720.png", "Comment",
                    "Description", "DetectionDescription", DateTime.Now, "Male", 1, new Institution {
                        Address = "Baker st.8",
                        CityId = 2,
                        Id = 2,
                        InstitutionCity = new City { Id = 2, Name = "London" },
                        Name = "Medical centre London",
                        IsVisible = false,
                        Number = "+1508556321",
                        OpeningHours = "10:00-10:01",
                        Website = "www.website.com",
                        Latitude = 40.432892,
                        Longitude = 50.035452
                    }
                ));
            list.Add(new Lost(
                    false, 1, "Patricia", "Smith", "Robinson", "John Developer Doe", "Black", "Black",
                    "clothes", "Normal", "Signs", 42, 42, 172, "https://cdn.pixabay.com/photo/2016/03/31/19/57/avatar-1295406_960_720.png", "Comment",
                    "Description", "DetectionDescription", DateTime.Now, "Male", 1, new Institution {
                        Address = "Baker st.8",
                        CityId = 2,
                        Id = 2,
                        InstitutionCity = new City { Id = 2, Name = "London" },
                        Name = "Medical centre London",
                        IsVisible = false,
                        Number = "+1508556321",
                        OpeningHours = "10:00-10:01",
                        Website = "www.website.com",
                        Latitude = 40.432892,
                        Longitude = 50.035452
                    }
                ));
            return list;
        }

        public IEnumerable<Institution> GetInstitutions() {
            //var response = await client.GetAsync("/api/losts/getinstituions");
            //if (response.IsSuccessStatusCode) {
            //    var data = await response.Content.ReadAsStringAsync();
            //    return JsonConvert.DeserializeObject<IEnumerable<Institution>>(data);
            //}
            //return null;
            var list = new List<Institution>();
            list.Add(new Institution {
                Address = "HuseynCavid st. home 8",
                CityId = 1,
                Id = 1,
                InstitutionCity = new City { Id = 1, Name = "Baku" },
                Name = "Medical centre",
                IsVisible = false,
                Number = "+994508556321",
                OpeningHours = "10:00-10:01",
                Website = "www.website.com",
                Latitude = 40.432892,
                Longitude = 50.035452
            });
            list.Add(new Institution {
                Address = "Baker st.8",
                CityId = 2,
                Id = 2,
                InstitutionCity = new City { Id = 2, Name = "London" },
                Name = "Medical centre London",
                IsVisible = false,
                Number = "+1508556321",
                OpeningHours = "10:00-10:01",
                Website = "www.website.com",
                Latitude = 40.432892,
                Longitude = 50.035452
            });
            return list;
        }
    }
}