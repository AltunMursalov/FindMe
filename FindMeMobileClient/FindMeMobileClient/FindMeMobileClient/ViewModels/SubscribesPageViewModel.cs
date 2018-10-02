using FindMeMobileClient.Models;
using FindMeMobileClient.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FindMeMobileClient.ViewModels {
    public class SubscribesPageViewModel : BindableBase, INavigationAware {
        private readonly ISubscribeService subscribeService;
        private readonly INavigationService navigationService;

        // Constructor
        public SubscribesPageViewModel(ISubscribeService subscribeService, INavigationService navigationService) {
            this.subscribeService = subscribeService;
            this.navigationService = navigationService;
            this.AddFilterCommand = new DelegateCommand(AddFilter);
            this.DeleteFilterCommand = new DelegateCommand<object>(DeleteFilter);
            this.Filters = new ObservableCollection<Filter>();
            this.SelectedItem = new Filter();
            Update();
        }


        #region Bindings
        public ObservableCollection<Filter> Filters { get; set; }
        private Filter selectedItem;
        public Filter SelectedItem {
            get { return selectedItem; }
            set {
                SetProperty(ref this.selectedItem, value);
            }
        }
        #endregion


        #region AddingFilter
        public DelegateCommand AddFilterCommand { get; set; }
        private void AddFilter() {
            navigationService.NavigateAsync("FilterPage");
        }
        #endregion

        #region DeleteFilter
        public DelegateCommand<object> DeleteFilterCommand { get; set; }
        private void DeleteFilter(object param) {
            if (param is Filter filter) {
                subscribeService.DeleteSubscribedFilter(filter.FilterDate);
                Update();
            }
        }
        #endregion

        public void Update() {
            //Device.BeginInvokeOnMainThread(() => {
            Filters.Clear();
            //});
            var filters = this.subscribeService.GetSubscribedFilters();
            if (filters != null) {
                foreach (var item in filters) {
                    //Device.BeginInvokeOnMainThread(() => {
                    Filters.Add(item);
                    //});
                }
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters) {

        }

        public void OnNavigatedTo(NavigationParameters parameters) {
            if (parameters["filter"] is bool param) {
                if (param == true) {
                    subscribeService.AddSubscribedFilter();
                    Update();
                }
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters) {

        }

    }
}
