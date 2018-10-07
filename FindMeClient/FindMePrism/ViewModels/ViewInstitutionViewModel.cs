using FindMePrism.Events;
using FindMePrism.Models;
using FindMePrism.Services;
using Microsoft.Maps.MapControl.WPF;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System.ComponentModel;
using System.Windows;

namespace FindMePrism.ViewModels
{
    public class ViewInstitutionViewModel : BindableBase
    {
        private Institution institution;
        public Institution Institution { get => institution; set => SetProperty(ref institution, value); }

        private Visibility visibility;
        public Visibility Visibility { get => visibility; set => SetProperty(ref visibility, value); }

        private string label;
        public string Label { get => label; set => SetProperty(ref label, value); }

        private List<InstitutionType> institutionTypes;
        public List<InstitutionType> InstitutionTypes { get => institutionTypes; set => SetProperty(ref institutionTypes, value); }

        public IEventAggregator eventAggregator { get; }
        public IRegionManager regionManager { get; }
        public IInstitutionService institutionService { get; }
        public bool editProcess { get; set; }
        public DelegateCommand OkCommand { get; set; }

        private ObservableCollection<Pushpin> pushpins;
        public ObservableCollection<Pushpin> Pushpins
        {
            get { return pushpins; }
            set { SetProperty(ref pushpins, value); }
        }

        public ViewInstitutionViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IInstitutionService service)
        {
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            this.institutionService = service;
            InstitutionTypes = new List<InstitutionType>();
            Institution = new Institution() {
                City = new City(),
                InstitutionType = new InstitutionType()
            };

            Institution.PropertyChanged += Institution_PropertyChanged;
            Pushpins = new ObservableCollection<Pushpin>();
            OkCommand = new DelegateCommand(ExecuteOkCommandAsync, CanExecuteOkCommand);
            editProcess = false;
            Label = "Institution Registration Form";
            Visibility = Visibility.Visible;
            this.eventAggregator.GetEvent<InstTypesEvent>().Subscribe(GetTypes);
            this.eventAggregator.GetEvent<InstEvent>().Subscribe(GetInstitution);
            this.eventAggregator.GetEvent<AddressEvent>().Subscribe(GetAddress);
        }

        private void GetTypes(IEnumerable<InstitutionType> ts)
        {
            InstitutionTypes.Clear();
            if (ts != null) {
                foreach (var item in ts) {
                    InstitutionTypes.Add(item);
                }
            }
        }

        private void Institution_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OkCommand.RaiseCanExecuteChanged();
        }

        private void GetAddress(List<string> address)
        {
            if (address != null) {               
                Institution.City.Name = address[0];
                Institution.Address = address[1];
                Institution.Latitude = Convert.ToDouble(address[2]);
                Institution.Longitude = Convert.ToDouble(address[3]);
            }
            this.eventAggregator.GetEvent<AddressEvent>().Subscribe(GetAddress);
        }

        private void GetInstitution(Institution inst)
        {
            if (inst != null) {
                this.Institution = inst.Clone() as Institution;
                editProcess = true;
                Visibility = Visibility.Collapsed;
                Label = "Institution Edit Form";
            }
        }

        private void Navigate(string uri)
        {
            if (uri != null)
                this.regionManager.RequestNavigate("ContentRegion", uri);
        }


        private async void ExecuteOkCommandAsync()
        {
            try
            {
                if (editProcess) {
                    var res = await this.institutionService.EditInstitution(Institution);
                    if (res) {
                        this.eventAggregator.GetEvent<EditInstEvent>().Publish(Institution);
                        Navigate("ViewAdmin");
                        Institution = new Institution();
                        Institution.City = new City();
                        this.eventAggregator.GetEvent<ClearPinsEvent>().Publish(true);
                    }
                    else
                        this.eventAggregator.GetEvent<ShowAlertEvent>().Publish(new Notification { Content = "Error", Title = "Error" });
                }
                else {
                    var res = await this.institutionService.AddInstitution(Institution);
                    if (res != null) {
                        this.eventAggregator.GetEvent<NewInstEvent>().Publish(res);
                        Navigate("ViewAdmin");
                        Institution = new Institution();
                        Institution.City = new City();
                        this.eventAggregator.GetEvent<ClearPinsEvent>().Publish(true);
                    }
                    else
                        this.eventAggregator.GetEvent<ShowAlertEvent>().Publish(new Notification { Content = "Error", Title = "Error" });
                }
                editProcess = false;
                Visibility = Visibility.Visible;
                Label = "Institution Registration Form";
            }
            catch (Exception) { }
        }

        private bool CanExecuteOkCommand()
        {
            return true;
            //return !String.IsNullOrWhiteSpace(Institution?.Name) & !String.IsNullOrWhiteSpace(Institution?.Address) & !String.IsNullOrWhiteSpace(Institution?.Phone) &
            //       !String.IsNullOrWhiteSpace(Institution?.City.Name) & !String.IsNullOrWhiteSpace(Institution?.OpeningHours) & !String.IsNullOrWhiteSpace(Institution.InstitutionType.Type);

        }

        private DelegateCommand cancelCommand;
        public DelegateCommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new DelegateCommand(
                    () => {
                        Navigate("ViewAdmin");
                        this.Institution = new Institution()
                        {
                            City = new City(),
                            InstitutionType = new InstitutionType()
                        };

                        this.eventAggregator.GetEvent<ClearPinsEvent>().Publish(true);
                        editProcess = false;
                        Visibility = Visibility.Visible;
                        Label = "Institution Registration Form";
                    }
                ));
            }
        }
    }
}
