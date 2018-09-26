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


namespace FindMePrism.ViewModels
{
    public class ViewFormViewModel : BindableBase
    {
        private Lost lost;
        public Lost Lost { get => lost; set => SetProperty(ref lost, value); }     

        private List<string> hairColors;
        public List<string> HairColors { get => hairColors; set => SetProperty(ref hairColors, value); }

        private List<string> eyeColors;
        public List<string> EyeColors { get => eyeColors; set => SetProperty(ref eyeColors, value); }

        private List<string> genders;
        public List<string> Genders { get => genders; set => SetProperty(ref genders, value); }

        private List<string> bodyTypes;
        public List<string> BodyTypes { get => bodyTypes; set => SetProperty(ref bodyTypes, value); }

        private Institution institution;
        public Institution Institution { get => institution; set => SetProperty(ref institution, value); }


        public IEventAggregator eventAggregator { get; }
        public IRegionManager regionManager { get; }
        public ILostService lostService { get; }
        public DelegateCommand SaveCommand { get; set; }
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
            Lost = new Lost();
            Lost.DetectionTime = DateTime.Now;
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
            editProcess = false;
            FillFields();
            SaveCommand = new DelegateCommand(ExecuteSaveCommand, CanExecuteSaveCommand).ObservesProperty(() => Lost);
        }

        private void GetInstitution(Institution inst)
        {
            if (inst != null)
            {
                Institution = new Institution();
                Institution = inst;
            }
        }

        private void GetLost(Lost lost)
        {
            if (lost != null)
            {
                try {
                    Lost = lost;
                    editProcess = true;
                }
                catch (Exception) { }
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
                //var res = LostService.EditLost(Institution, Lost);
                var result = this.lostService.EditLost(Lost);
                var res = await result;

                if (res) {
                    this.eventAggregator.GetEvent<EditLostEvent>().Publish(Lost);
                    Navigate("ViewLosts");
                    Lost = new Lost();
                    Lost.DetectionTime = DateTime.Now;
                }
            }
            else {
               // var res = LostService.AddLostAsync(Institution, Lost);
                var result = this.lostService.AddLostAsync(Institution, Lost);
                var res = await result;
                if (res != null) {
                    this.eventAggregator.GetEvent<NewLostEvent>().Publish(res);
                    Navigate("ViewLosts");
                    Lost = new Lost();
                    Lost.DetectionTime = DateTime.Now;
                }
            }
        }

        private bool CanExecuteSaveCommand()
        {
            return true;
            //!String.IsNullOrWhiteSpace(Lost.FirstName);
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
    }
}
