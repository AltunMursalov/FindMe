using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMePrism.Models;

namespace FindMePrism.Repositories
{
    public class LostRepository : ILostRepository
    {
        public Lost AddLost(Institution institution, Lost lost)
        {
            //server возвращает lost с Id
            return lost;
        }

        public bool EditLost(Institution institution, Lost lost)
        {
            //server
            return true;
        }

        public bool RemoveLost(Institution institution, Lost lost)
        {
            //server
            return true;
        }

        public IEnumerable<Lost> GetLosts(Institution institution)
        {
            //server
            var losts = new List<Lost>();
            City city = new City { Id = 1, Name = "Baku" };

            var l1 = new Lost() {
                Id = 1,
                FirstName = "F",
                MiddleName = "M",
                LastName = "L",
                EyeColor = "Green",
                HairColor = "Blonde",
                Clothes = "C",
                BodyType = "Thin",
                Signs = "S",
                Age = "30",
                Height = 45,
                ImagePath = "IP",
                Comment = "C",
                Description = "D",
                DetectionDescription = "DD",
                DetectionTime = new DateTime(2018, 5, 5, 10, 11, 12),
                Gender = "M",
                Institution = new Institution {
                    Id = 1,
                    Name = "Instutution",
                    Address = "Address",
                    Number = "9379992",
                    OpeningHours = "09.00 - 23.00",
                    Website = "www.findme.az",
                    InstitutionCity = city }
            };

            var l2 = new Lost()
            {
                Id = 2,
                FirstName = "F2",
                MiddleName = "M2",
                LastName = "L2",
                EyeColor = "Green",
                HairColor = "Blonde",
                Clothes = "C",
                BodyType = "Thin",
                Signs = "S",
                Age = "35",
                Height = 50,
                ImagePath = "IP",
                Comment = "C",
                Description = "D2",
                DetectionDescription = "DD",
                DetectionTime = new DateTime(2018, 5, 1, 10, 10, 12),
                Gender = "M",
                Institution = new Institution
                {
                    Id = 1,
                    Name = "I",
                    Address = "A",
                    Number = "9379992",
                    OpeningHours = "09.00 - 23.00",
                    Website = "www",
                    InstitutionCity = city
                }
            };
            losts.Add(l1);
            losts.Add(l2);

            return losts;
        }

        public IEnumerable<string> GetEyeColors()
        {
            //server
            List<string> Colors = new List<string>() { "Blue", "Gray", "Green" };
            return Colors;
        }

        public IEnumerable<string> GetHairColors()
        {
            //server
            List<string> Colors = new List<string>() { "Blonde", "Brown", "Black" };
            return Colors;
        }

        public IEnumerable<string> GetGenders()
        {
            //server
            List<string> Genders = new List<string>() { "M", "F"};
            return Genders;

        }

        public IEnumerable<string> GetBodyTypes()
        {
            //server
            List<string> Types = new List<string>() { "Thin", "Medium-Build", "Fat" };
            return Types;
        }
    }
}
