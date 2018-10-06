using FindMeMobileClient.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace FindMeMobileClient.ViewModels {
    public class OfflinePageViewModel : BindableBase, INavigationAware {
        private readonly IDataService dataService;
        private readonly INavigationService navigationService;

        public OfflinePageViewModel(IDataService dataService, INavigationService navigationService) {
            this.dataService = dataService;
            this.navigationService = navigationService;
            this.RetryCommand = new DelegateCommand(Retry);
        }

        public DelegateCommand RetryCommand { get; set; }

        public async void Retry() {
            var losts = await dataService.GetLosts();
            if (losts != null) {
                await this.navigationService.NavigateAsync("NavigationPage/MainPage");
            } else {
                await this.navigationService.NavigateAsync("app:///MainPage/NavigationPage/OfflinePage");
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters) { }

        public void OnNavigatedTo(NavigationParameters parameters) { }

        public void OnNavigatingTo(NavigationParameters parameters) { }
    }
}
