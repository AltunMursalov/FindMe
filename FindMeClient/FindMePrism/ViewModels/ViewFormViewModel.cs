using FindMePrism.Events;
using FindMePrism.Models;
using FindMePrism.Services;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Commands;
using System;
using System.Collections.Generic;
using Microsoft.Win32;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System.Threading;

namespace FindMePrism.ViewModels
{
    public class ViewFormViewModel : BindableBase
    {
        private Lost lost;
        public Lost Lost { get => lost; set => SetProperty(ref lost, value); }

        private Institution institution;
        public Institution Institution { get => institution; set => SetProperty(ref institution, value); }

        private List<string> hairColors;
        public List<string> HairColors { get => hairColors; set => SetProperty(ref hairColors, value); }

        private List<string> eyeColors;
        public List<string> EyeColors { get => eyeColors; set => SetProperty(ref eyeColors, value); }

        private List<string> genders;
        public List<string> Genders { get => genders; set => SetProperty(ref genders, value); }

        private List<string> bodyTypes;
        public List<string> BodyTypes { get => bodyTypes; set => SetProperty(ref bodyTypes, value); }

        public IEventAggregator eventAggregator { get; }
        public IRegionManager regionManager { get; }
        public ILostService lostService { get; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand FillFieldsCommand { get;}
        public bool editProcess { get; set; } 

        public void FillEyeColors()
        {
            EyeColors = new List<string>();
            var ec = this.lostService.GetEyeColors();
            foreach (var item in ec)
            {
                EyeColors.Add(item);
            }
        }
        public void FillHairColors()
        {
            HairColors = new List<string>();
            var hc = this.lostService.GetHairColors();
            foreach (var item in hc)
            {
                HairColors.Add(item);
            }
        }       
        public void FillGenders()
        {
            Genders = new List<string>();
            var gs = this.lostService.GetGenders();
            foreach (var item in gs)
            {
                Genders.Add(item);
            }
        }
        public void FillBodyTypes()
        {
            BodyTypes = new List<string>();
            var bt = this.lostService.GetBodyTypes();
            foreach (var item in bt)
            {
                BodyTypes.Add(item);
            }
        }

        public void FillFields()
        {
            FillEyeColors();
            FillGenders();
            FillHairColors();
            FillBodyTypes();
        }

        public ViewFormViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, ILostService lostService)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<EditLostEvent>().Subscribe(GetLost);
            this.eventAggregator.GetEvent<InstEvent>().Subscribe(GetInstitution);
            this.regionManager = regionManager;
            this.lostService = lostService;
            this.Lost = new Lost();
            this.Lost.Institution = new Institution();
            this.Lost.Institution.City = new City();
            this.Lost.Institution.InstitutionType = new InstitutionType();
            this.Lost.DetectionTime = DateTime.Now;
            editProcess = false;
            FillFields();
            SaveCommand = new DelegateCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            FillFieldsCommand = new DelegateCommand(ExecuteFillFieldsCommand);

        }

        private void GetInstitution(Institution inst)
        {
            if (inst != null) {
                Institution = new Institution();
                Institution = inst;
               // Lost.Institution.City = new City();
               // Lost.Institution.InstitutionType = new InstitutionType();
               // Lost.Institution = inst.Clone() as Institution;
            }
        }

        private void GetLost(Lost lost)
        {
            if (lost != null) {
                Lost = lost.Clone() as Lost;
                Lost.Institution = lost.Institution.Clone() as Institution;
                Lost.Institution.City = lost.Institution.City.Clone() as City;
                Lost.Institution.InstitutionType = lost.Institution.InstitutionType.Clone() as InstitutionType;
                editProcess = true;
            }
        }

        private void Navigate(string uri)
        {
            if (uri != null)
                this.regionManager.RequestNavigate("ContentRegion", uri);
        }

        private async void ExecuteSaveCommand()
        {
            if (editProcess) {
                var res = await this.lostService.EditLost(Lost);
                if (res) {
                    this.eventAggregator.GetEvent<EditLostEvent>().Publish(Lost);
                    Navigate("ViewLosts");
                    Lost = new Lost();
                    Lost.DetectionTime = DateTime.Now;
                }
                else {
                    this.eventAggregator.GetEvent<ShowAlertEvent>().Publish(new Notification { Content = "Error!", Title = "Error" });
                }
            }
            else {
                Lost.Institution = Institution;
                Lost.InstitutionId = Institution.Id;
                var res = this.lostService.AddLost(Lost).Result;
                if (res != null) {
                    this.eventAggregator.GetEvent<NewLostEvent>().Publish(res);
                    Navigate("ViewLosts");
                    Lost = new Lost();
                    Lost.DetectionTime = DateTime.Now;
                }
                else {
                    this.eventAggregator.GetEvent<ShowAlertEvent>().Publish(new Notification { Content = "Error!", Title = "Error" });
                }
            }
        }

        private bool CanExecuteSaveCommand()
        {
            return true;
        }

        private DelegateCommand cancelCommand;
        public DelegateCommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new DelegateCommand(
                    () => {
                        Navigate("ViewLosts");
                        Lost = new Lost();
                        Lost.DetectionTime = DateTime.Now;
                    }
                ));
            }
        }

        private DelegateCommand openCommand;
        public DelegateCommand OpenCommand
        {
            get
            {
                return openCommand ?? (openCommand = new DelegateCommand(
                    () => {
                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.FileName = String.Empty;
                        dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                        if (dialog.ShowDialog() == true)
                           Lost.ImagePath = System.IO.Path.GetFullPath(dialog.FileName);
                    }
                ));
            }
        }

        private void ExecuteFillFieldsCommand()
        {
            this.Lost = new Lost()
            {
                FirstName = "Murad",
                MiddleName = "Rustam",
                LastName = "Mamedov",
                Gender = "Male",
                EyeColor = "Blue",
                HairColor = "Brown",
                Clothes = "Clothes",
                BodyType = "Medium",
                AgeBegin = 20,
                AgeEnd = 20,
                Height = 180,
                ImagePath = @"C:\Users\Ibra_yf85\FMR\FindMeClient\FindMePrism\user-default.png",
                Description = "description",
                DetectionDescription = "detection description",
                DetectionTime = DateTime.Now,
                Signs = "signs",
                Comment = "comment",
            };
        }        
    }
}
