using FindMePrism.Events;
using FindMePrism.Models;
using FindMePrism.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace FindMePrism.ViewModels
{
    class ViewLoginViewModel : BindableBase
    {
        private string login = "login";
        public string Login 
        {
            get { return login; }
            set { SetProperty(ref login, value); }
        }

        private string password = "password";
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public DelegateCommand LoginCommand { get; set; }
        public IEventAggregator EventAggregator { get; }
        private readonly IRegionManager RegionManager;
        private readonly IAuthenticationService AuthService;
        private readonly ILostService LostService;

        public ViewLoginViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IAuthenticationService authService, ILostService lostService)
        {
            LoginCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => Login).ObservesProperty(() => Password);
            EventAggregator = eventAggregator;
            RegionManager = regionManager;
            AuthService = authService;
            LostService = lostService;
        }

        private void Navigate(string uri)
        {
            if (uri != null)
                RegionManager.RequestNavigate("ContentRegion", uri);
        }

        private void Execute()
        {
            var res = AuthService.Validate(Login, Password);
            if (res!=null)
            {
                var losts = LostService.GetLosts(res);
                Navigate("ViewLosts");
                if (losts != null)
                {
                    EventAggregator.GetEvent<LostsEvent>().Publish(losts);
                }
                EventAggregator.GetEvent<InstEvent>().Publish(res);
            }
        } 

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(Login) & !String.IsNullOrWhiteSpace(Password);
        }
    }
}
