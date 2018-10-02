using FindMeMobileClient.Models;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;

using System.Text;
using Xamarin.Forms.Maps;

namespace FindMeMobileClient.ViewModels {
    public class MapPageViewModel : BindableBase, INavigationAware {

        public MapPageViewModel() {
            this.PinPosition = new Position();
        }

        public string Name { get; set; }

        private Position pinPosition;

        public Position PinPosition {
            get { return pinPosition; }
            set { SetProperty(ref this.pinPosition, value); }
        }

        public void OnNavigatedFrom(NavigationParameters parameters) { }

        public void OnNavigatedTo(NavigationParameters parameters) {
            if (parameters.ContainsKey("MorePageQuery")) {
                if (parameters["MorePageQuery"] is Lost lost) {
                    // потом поставь если асинхронно будешь делать device....
                    this.Name = lost.Institution.Name;
                    this.PinPosition = new Position(lost.Institution.Latitude,
                        lost.Institution.Longitude);
                }
            } else if (parameters.ContainsKey("OrganizationsPageQuery")) {
                if (parameters["OrganizationsPageQuery"] is Institution institution) {
                    this.Name = institution.Name;
                    this.PinPosition = new Position(institution.Latitude,
                        institution.Longitude);
                }
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters) { }
    }
}
