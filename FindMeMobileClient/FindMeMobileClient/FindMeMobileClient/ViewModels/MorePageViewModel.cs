﻿using FindMeMobileClient.Models;
using FindMeMobileClient.Services.Interfaces;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;

namespace FindMeMobileClient.ViewModels {
    public class MorePageViewModel : BindableBase, INavigationAware {
        private readonly INavigationService navigationService;
        private readonly IPageDialogService pageDialogService;
        private readonly IDataService dataService;

        public MorePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDataService dataService) {
            this.navigationService = navigationService;
            this.pageDialogService = pageDialogService;
            this.dataService = dataService;
            this.ShowOnMap = new DelegateCommand(ShowOnMapMethod);
        }


        public DelegateCommand ShowOnMap { get; set; }

        public async void ShowOnMapMethod() {
            var prms = new NavigationParameters();
            prms.Add("MorePageQuery", Lost);
            await navigationService.NavigateAsync("MapPage", prms);
        }


        private Lost lost;

        public Lost Lost {
            get { return lost; }
            set {
                SetProperty(ref this.lost, value);
                City = lost.Institution.InstitutionCity;
                Institution = lost.Institution;

            }
        }

        private City city;
        public City City {
            get { return city; }
            set { SetProperty(ref this.city, value); }
        }

        private Institution institution;
        public Institution Institution {
            get { return institution; }
            set { SetProperty(ref this.institution, value); }
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
