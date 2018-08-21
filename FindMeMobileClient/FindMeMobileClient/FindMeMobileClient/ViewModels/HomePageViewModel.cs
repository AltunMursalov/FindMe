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
    public class HomePageViewModel : BindableBase{
        private readonly IPageDialogService pageDialogService;
        private readonly INavigationService navigationService;
        private readonly IDataService dataService;
        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDataService dataService)  {
            this.pageDialogService = pageDialogService;
            this.dataService = dataService;
            this.navigationService = navigationService;
            SearchCommand = new DelegateCommand(Search);
            FilterCommand = new DelegateCommand(Filter);
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
            // Filter Action
            pageDialogService.DisplayAlertAsync("Filter Command", "Filter command was execute", "OK");
        }
        #endregion

        public void Update() {
            Losts.Clear();
            var losts = dataService.GetLosts();
            foreach (var item in losts) {
                Losts.Add(item);
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