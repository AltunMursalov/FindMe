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

namespace FindMePrism.ViewModels
{
    public class ViewInstitutionViewModel : BindableBase
    {
        private Institution institution;
        public Institution Institution { get => institution; set => SetProperty(ref institution, value); }
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
            editProcess = false;
            this.eventAggregator.GetEvent<InstEvent>().Subscribe(GetInstitution);
            this.eventAggregator.GetEvent<AddressEvent>().Subscribe(GetAddress);
            OkCommand = new DelegateCommand(ExecuteOkCommandAsync, CanExecuteOkCommand).ObservesProperty(() => Institution);
            Institution = new Institution();
            Institution.City = new City();
            Institution.InstitutionType = new InstitutionType();
            Pushpins = new ObservableCollection<Pushpin>();
            InstitutionTypes = new List<InstitutionType>();
            FillInstitutionTypes();
        }


        public async void FillInstitutionTypes()
        {
            InstitutionTypes = new List<InstitutionType>();
            List<InstitutionType> its = new List<InstitutionType>();
            its =  await this.institutionService.GetInstitutionTypes();
            if (its!=null) {
                foreach (var item in its) {
                    InstitutionTypes.Add(item);
                }
            }

        }
        private void GetAddress(List<string> address)
        {
            if (address != null)
            {
                Institution.City.Name = address[0];
                Institution.Address = address[1];
                Institution.Latitude = Convert.ToDouble(address[2]);
                Institution.Longitude = Convert.ToDouble(address[3]);
            }
            this.eventAggregator.GetEvent<AddressEvent>().Subscribe(GetAddress);
        }

        private void GetInstitution(Institution inst)
        {
            if (inst != null)
            {
                Institution = inst.Clone() as Institution;
                Institution.InstitutionType = inst.InstitutionType.Clone() as InstitutionType;
                Institution.City = inst.City.Clone() as City;
                this.Institution.InstitutionType.Id -= 1;
                editProcess = true;
                this.eventAggregator.GetEvent<EditProcessEvent>().Publish(true);
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
                if (editProcess)
                {
                    this.Institution.InstitutionType.Id += 1;
                    var res = await this.institutionService.EditInstitution(Institution);
                    if (res)
                    {
                        this.eventAggregator.GetEvent<EditInstEvent>().Publish(Institution);
                        Navigate("ViewAdmin");
                        Institution = new Institution();
                        Institution.City = new City();
                        this.eventAggregator.GetEvent<ClearPinsEvent>().Publish(true);
                    }
                    else
                        this.eventAggregator.GetEvent<ShowAlertEvent>().Publish(new Notification { Content = "Error", Title = "Error" });

                }
                else
                {
                    var res = await this.institutionService.AddInstitution(Institution);
                    if (res != null)
                    {
                        this.eventAggregator.GetEvent<NewInstEvent>().Publish(res);
                        Navigate("ViewAdmin");
                        Institution = new Institution();
                        Institution.City = new City();
                        this.eventAggregator.GetEvent<ClearPinsEvent>().Publish(true);
                    }
                    else
                        this.eventAggregator.GetEvent<ShowAlertEvent>().Publish(new Notification { Content = "Error", Title = "Error" });
                }
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
                    () =>
                    {
                        Navigate("ViewAdmin");
                        Institution = new Institution();
                        Institution.City = new City();
                        this.eventAggregator.GetEvent<ClearPinsEvent>().Publish(true);
                    }
                ));
            }
        }
    }
}
