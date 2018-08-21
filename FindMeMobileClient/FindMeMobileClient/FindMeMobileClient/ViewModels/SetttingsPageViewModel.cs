using System;
using System.Collections.Generic;
using System.Text;
using FindMeMobileClient.Services.Interfaces;
using Prism.Mvvm;
using Prism.Navigation;

namespace FindMeMobileClient.ViewModels {
    public class SetttingsPageViewModel : BindableBase {
        private readonly IDataService dataService;
        public SetttingsPageViewModel(IDataService dataService) {
            this.dataService = dataService;
        }
    }
}