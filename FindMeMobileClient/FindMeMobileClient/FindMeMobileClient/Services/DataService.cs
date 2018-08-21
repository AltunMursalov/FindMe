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
            losts.Add(new Lost(false, losts.Count + 1, "John"
               , "", "Doe", "John Doe", "Blue", "Brown",
                "pink trousers", "Fat", "headless", 19, 19, 178, "", "Comment", "description", "detection description",
                DateTime.Now, "Man", 1, new Institution { Address = "address", Id = 1, Number = "+994508556321" }));
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
        }

        public IEnumerable<Lost> GetLosts() {
            return losts;
        }
    }
}