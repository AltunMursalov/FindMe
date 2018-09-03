using System;
using System.Collections.Generic;
using System.Text;
using FindMeMobileClient.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

namespace FindMeMobileClient.ViewModels {
    public class SettingsPageViewModel : BindableBase {
        private readonly IDataService dataService;
        private readonly IPageDialogService pageDialogService;
        private readonly INavigationService navigationService;
        public SettingsPageViewModel(IDataService dataService, IPageDialogService pageDialogService, INavigationService navigationService) {
            this.dataService = dataService;
            this.pageDialogService = pageDialogService;
            this.navigationService = navigationService;
            this.FollowToggleCommand = new DelegateCommand(Toggle);
        }

        private bool followToggled;

        public bool FollowToggled {
            get { return followToggled; }
            set { SetProperty(ref this.followToggled, value); }
        }

        public DelegateCommand FollowToggleCommand { get; set; }

        public void Toggle() {
            //pageDialogService.DisplayAlertAsync("title", FollowToggled.ToString(), "OK");
            
        }
    }
}