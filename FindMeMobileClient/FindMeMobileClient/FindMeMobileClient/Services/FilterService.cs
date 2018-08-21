using FindMeMobileClient.Models;
using FindMeMobileClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindMeMobileClient.Services {
    public class FilterService : IFilterService {
        public Filter Filter { get; set; }
        public FilterService() {
            Filter = new Filter();
        }
    }
}
