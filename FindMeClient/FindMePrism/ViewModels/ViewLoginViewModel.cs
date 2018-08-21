using FindMePrism.Events;
using FindMePrism.Models;
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
    class ViewLoginViewModel : BindableBase, INavigationAware
    {
        private string login;
        public string Login
        {
            get { return login; }
            set { SetProperty(ref login, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public DelegateCommand LoginCommand { get; set; }
        public IEventAggregator EventAggregator { get; }

        public ViewLoginViewModel(IEventAggregator eventAggregator)
        {
            LoginCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(()=> Login).ObservesProperty(()=> Password);
            EventAggregator = eventAggregator;
        }

        private void Execute()
        {
            MessageBox.Show("Login!");
            //get losts from server
            var losts = new List<Lost>();
            EventAggregator.GetEvent<LostsEvent>().Publish(losts);
        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(Login) & !String.IsNullOrWhiteSpace(Password);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
