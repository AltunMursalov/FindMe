using FindMeMobileClient.Models;
using FindMeMobileClient.Services.Interfaces;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FindMeMobileClient.ViewModels {
    public class OrganizationsPageViewModel : BindableBase {
        private readonly IDataService dataService;
        public OrganizationsPageViewModel(IDataService dataService) {
            this.dataService = dataService;
            Institutions = new ObservableCollection<Institution>();
            Update();
        }

        public ObservableCollection<Institution> Institutions { get; set; }

        public void Update() {
            Device.BeginInvokeOnMainThread(() => {
                Institutions.Clear();
            });
            var institutions = this.dataService.GetInstitutions();
            if (institutions != null) {
                foreach (var item in institutions) {
                    Device.BeginInvokeOnMainThread(() => {
                        Institutions.Add(item);
                    });
                }
            }
        }
    }
}
