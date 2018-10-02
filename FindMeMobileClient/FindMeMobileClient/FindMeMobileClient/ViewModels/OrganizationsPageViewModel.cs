using FindMeMobileClient.Models;
using FindMeMobileClient.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FindMeMobileClient.ViewModels
{
    public class OrganizationsPageViewModel : BindableBase
    {
        private readonly IDataService dataService;
        public OrganizationsPageViewModel(IDataService dataService)
        {
            this.dataService = dataService;
            this.IsBusy = false;
            this.Institutions = new ObservableCollection<Institution>();
            this.RefreshInstitutionsCommand = new DelegateCommand(Update);
            Update();
        }

        #region IsBusy
        private bool isBusy;
        public bool IsBusy { get => this.isBusy; set { SetProperty(ref this.isBusy, value); } }
        #endregion

        public ObservableCollection<Institution> Institutions { get; set; }

        public DelegateCommand RefreshInstitutionsCommand { get; set; }

        public async void Update()
        {
            this.IsBusy = true;
            Device.BeginInvokeOnMainThread(() =>
            {
                this.Institutions.Clear();
            });
            var institutions = await this.dataService.GetInstitutions();
            if (institutions != null)
            {
                foreach (var item in institutions)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        this.Institutions.Add(item);
                    });
                }
            }
            this.IsBusy = false;
        }
    }
}
