using FindMeMobileClient.Models;
using FindMeMobileClient.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FindMeMobileClient.ViewModels {
    public class HomePageViewModel : BindableBase {
        private readonly IPageDialogService pageDialogService;
        private readonly INavigationService navigationService;
        private readonly IDataService dataService;
        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDataService dataService) {
            this.pageDialogService = pageDialogService;
            this.dataService = dataService;
            this.navigationService = navigationService;
            SearchCommand = new DelegateCommand(Search);
            FilterCommand = new DelegateCommand(Filter);
            MoreCommand = new DelegateCommand(More);
            Losts = new ObservableCollection<Lost>();
            Update();

        }

        public ObservableCollection<Lost> Losts { get; set; }

        #region Search
        public DelegateCommand SearchCommand { get; set; }
        private string searchText;
        public string SearchText {
            get { return searchText; }
            set {
                SetProperty(ref this.searchText, value);
            }
        }
        public void Search() {
            Update(SearchText);
            //pageDialogService.DisplayAlertAsync("Search Command", "Search command was execute", "OK");
        }
        #endregion

        #region Filter
        public DelegateCommand FilterCommand { get; set; }

        public void Filter() {
            navigationService.NavigateAsync("FilterPage");
            Update();
            //pageDialogService.DisplayAlertAsync("Filter Command", "Filter command was execute", "OK");

        }
        #endregion

        #region More
        public DelegateCommand MoreCommand { get; set; }



        private Lost selectedItem;
        public Lost SelectedItem {
            get { return selectedItem; }
            set {
                SetProperty(ref this.selectedItem, value);
            }
        }

        public async void More() {
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("SelectedLost", SelectedItem);
            await navigationService.NavigateAsync("MorePage", navigationParameters);
            //pageDialogService.DisplayAlertAsync("Filter Command", "Filter command was execute", "OK");

        }
        #endregion

        public void Update() {
            Losts.Clear();
            if (App.Filter == null) {
                var losts = dataService.GetLosts();
                foreach (var item in losts) {
                    Losts.Add(item);
                }
            } else {
                var losts = dataService.GetLosts();
                var lostsFiltered = losts.Where((p) => {
                    if (
                        string.IsNullOrWhiteSpace(p.FirstName) ? true : string.IsNullOrWhiteSpace(App.Filter.FirstName) ? true : (p.FirstName == App.Filter.FirstName ? true : false) &&
                        string.IsNullOrWhiteSpace(p.MiddleName) ? true : string.IsNullOrWhiteSpace(App.Filter.MiddleName) ? true : (p.MiddleName == App.Filter.MiddleName ? true : false) &&
                        string.IsNullOrWhiteSpace(p.LastName) ? true : string.IsNullOrWhiteSpace(App.Filter.LastName) ? true : (p.LastName == App.Filter.LastName ? true : false) &&
                        string.IsNullOrWhiteSpace(p.Age) ? true : App.Filter.AgeBegin == 0 && App.Filter.AgeEnd == 0 ? true : int.Parse(p.Age) >= App.Filter.AgeBegin && int.Parse(p.Age) <= App.Filter.AgeEnd ? true : false &&
                        App.Filter.Height == 0 ? true : App.Filter.Height == p.Height &&
                        string.IsNullOrEmpty(App.Filter.HairColor) ? true : p.HairColor == App.Filter.HairColor ? true : false &&
                        string.IsNullOrEmpty(App.Filter.EyeColor) ? true : p.EyeColor == App.Filter.EyeColor ? true : false &&
                        string.IsNullOrEmpty(App.Filter.BodyType) ? true : p.BodyType == App.Filter.BodyType ? true : false &&
                        string.IsNullOrEmpty(App.Filter.Gender) ? true : p.Gender == App.Filter.Gender ? true : false
                    ) { return true; } else { return false; }
                });
                foreach (var item in lostsFiltered) {
                    Losts.Add(item);
                }
            }
        }

        public void Update(string param) {
            Losts.Clear();
            var losts = dataService.GetLosts();
            var lostsFiltered = losts.Where((p) => p.FullName.ToLower().Contains(param.ToLower()));
            foreach (var item in lostsFiltered) {
                Losts.Add(item);
            }
        }
    }
}