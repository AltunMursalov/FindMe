using FindMeMobileClient.Models;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindMeMobileClient.ViewModels {
    public class FilterPageViewModel : BindableBase {
        private readonly INavigationService navigationService;
        public FilterPageViewModel(INavigationService navigationService) {
            this.navigationService = navigationService;
            App.filterService.Filter = new Filter {
                FirstName = "John",
                MiddleName = "",
                LastName = "Doe",
                AgeBegin = 18,
                AgeEnd = 19,
                BodyType = "Middle",
                EyeColor = "Blue",
                HairColor = "Black",
                Gender = "Man",
                Height = 178
            };
        }
    }
}
