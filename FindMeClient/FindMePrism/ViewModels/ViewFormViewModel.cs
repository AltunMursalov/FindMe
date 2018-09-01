using FindMePrism.Events;
using FindMePrism.Models;
using FindMePrism.Services;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FindMePrism.ViewModels
{
    class ViewFormViewModel : BindableBase
    {
        private Lost lost;
        public Lost Lost { get => lost; set => SetProperty(ref lost, value); }

        //private List<string> ages;
        //public List<string> Ages { get => ages; set => SetProperty(ref ages, value); }

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

        public bool EditProcess { get; set; }

        public IEventAggregator EventAggregator { get; }
        public IRegionManager RegionManager { get; }
        public ILostService LostService { get; }

        /*public void FillAge()
        {
            Ages = new List<string>();
            Ages.Add("< 1");
            for (int i = 1; i < 101; i++)
            {
                Ages.Add(i.ToString());
            }
            Ages.Add("> 100");
        }*/

        public void FillEyeColors()
        {
            EyeColors = new List<string>();
            var ec = LostService.GetEyeColors();
            foreach (var item in ec) {
                EyeColors.Add(item);
            }
        }

        public void FillHairColors()
        {
            HairColors = new List<string>();
            var hc = LostService.GetHairColors();
            foreach (var item in hc)
            {
                HairColors.Add(item);
            }
        }

        public void FillGenders()
        {
            Genders = new List<string>();
            var gs = LostService.GetGenders();
            foreach (var item in gs)
            {
                Genders.Add(item);
            }
        }

        public void FillBodyTypes()
        {
            BodyTypes = new List<string>();
            var bt = LostService.GetBodyTypes();
            foreach (var item in bt)
            {
                BodyTypes.Add(item);
            }
        }

        public void FillFields()
        {
            Lost = new Lost();
            Lost.DetectionTime = DateTime.Now;
            //FillAge();
            FillEyeColors();
            FillGenders();
            FillHairColors();
            FillBodyTypes();
        }

        public ViewFormViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, ILostService lostService)
        {
            EventAggregator = eventAggregator;
            EventAggregator.GetEvent<EditLostEvent>().Subscribe(GetLost);
            EventAggregator.GetEvent<InstEvent>().Subscribe(GetInstitution);
            RegionManager = regionManager;
            LostService = lostService;           
            FillFields();
            EditProcess = false;
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
               Lost.Id = lost.Id;
               Lost.FirstName = lost.FirstName;
               Lost.MiddleName = lost.MiddleName;
               Lost.LastName = lost.LastName;
               Lost.EyeColor = lost.EyeColor;
               Lost.HairColor = lost.HairColor;
               Lost.Clothes = lost.Clothes;
               Lost.BodyType = lost.BodyType;
               Lost.Signs = lost.Signs;
               Lost.Age = lost.Age;
               Lost.Height = lost.Height;
               Lost.ImagePath = lost.ImagePath;
               Lost.Comment = lost.Comment;
               Lost.Description = lost.Description;
               Lost.DetectionDescription = lost.DetectionDescription;
               Lost.DetectionTime = lost.DetectionTime;
               Lost.Gender = lost.Gender;
               Lost.Institution = lost.Institution;
               EditProcess = true;
            }
        } 

        private void Navigate(string uri)
        {
            if (uri != null)
                RegionManager.RequestNavigate("ContentRegion", uri);
        }

        private DelegateCommand saveCommand;
        public DelegateCommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new DelegateCommand(
                    () =>
                    {
                        if (EditProcess) {
                            var res = LostService.EditLost(Institution, Lost);
                            if (res)
                            {
                                EventAggregator.GetEvent<EditLostEvent>().Publish(Lost);
                                Navigate("ViewLosts");
                                Lost = new Lost();
                                Lost.DetectionTime = DateTime.Now;
                            }
                        }
                        else {
                            var res = LostService.AddLost(Institution, Lost);
                            if (res != null)
                            {
                                EventAggregator.GetEvent<NewLostEvent>().Publish(res);
                                Navigate("ViewLosts");
                                Lost = new Lost();
                                Lost.DetectionTime = DateTime.Now;
                            }
                        }
                    }
                ));
            }
        }

        private DelegateCommand cancelCommand;
        public DelegateCommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new DelegateCommand(
                    () =>
                    {
                        Navigate("ViewLosts");
                        Lost = new Lost();
                        Lost.DetectionTime = DateTime.Now;
                    }
                ));
            }
        }
    }
}
