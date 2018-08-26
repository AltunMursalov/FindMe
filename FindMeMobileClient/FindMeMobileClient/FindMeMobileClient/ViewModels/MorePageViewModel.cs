using FindMeMobileClient.Models;
using FindMeMobileClient.Services.Interfaces;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FindMeMobileClient.ViewModels {
    public class MorePageViewModel : BindableBase, INavigationAware {
        private readonly INavigationService navigationService;
        private readonly IPageDialogService pageDialogService;
        private readonly IDataService dataService;

        public MorePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDataService dataService) {
            this.navigationService = navigationService;
            this.pageDialogService = pageDialogService;
            this.dataService = dataService;
        }

        private Lost lost;

        public Lost Lost {
            get { return lost; }
            set {
                SetProperty(ref this.lost, value);
                City = lost.Institution.InstitutionCity;
                InstitutionName = lost.Institution.Name;
                institutionAddress = lost.Institution.Address;
                InstitutionPhone = lost.Institution.Number;

            }
        }

        private City city;
        public City City {
            get { return city; }
            set { SetProperty(ref this.city, value); }
        }

        private string institutionName;
        public string InstitutionName {
            get { return institutionName; }
            set { SetProperty(ref this.institutionName, value); }
        }

        private string institutionAddress;
        public string InstitutionAddress {
            get { return institutionAddress; }
            set { SetProperty(ref this.institutionAddress, value); }
        }

        private string institutionPhone;
        public string InstitutionPhone {
            get { return institutionPhone; }
            set { SetProperty(ref this.institutionPhone, value); }
        }

        public void OnNavigatedFrom(NavigationParameters parameters) {

        }

        public void OnNavigatedTo(NavigationParameters parameters) {
            if (parameters["SelectedLost"] is Lost lost)
                this.Lost = lost;
        }

        public void OnNavigatingTo(NavigationParameters parameters) {

        }
    }
}
