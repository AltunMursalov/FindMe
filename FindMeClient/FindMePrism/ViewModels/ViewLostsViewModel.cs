using FindMePrism.Events;
using FindMePrism.Models;
using FindMePrism.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FindMePrism.ViewModels
{
    class ViewLostsViewModel : BindableBase
    {
        private ObservableCollection<Lost> losts;
        public ObservableCollection<Lost> Losts { get => losts; set => SetProperty(ref losts, value); }

        private Institution institution;
        public Institution Institution { get => institution; set => SetProperty(ref institution, value); }

        public IEventAggregator EventAggregator { get; }
        public IRegionManager RegionManager { get; }
        private readonly ILostService LostService;

        private Visibility buttonOpenVisibility;
        public Visibility ButtonOpenVisibility { get => buttonOpenVisibility; set => SetProperty(ref buttonOpenVisibility, value);}

        private Visibility buttonCloseVisibilty;
        public Visibility ButtonCloseVisibility { get => buttonCloseVisibilty; set => SetProperty(ref buttonCloseVisibilty, value);}

        public ViewLostsViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, ILostService lostService)
        {
            Losts = new ObservableCollection<Lost>();
            EventAggregator = eventAggregator;
            EventAggregator.GetEvent<LostsEvent>().Subscribe(GetLosts);
            EventAggregator.GetEvent<InstEvent>().Subscribe(GetInstitution);
            EventAggregator.GetEvent<NewLostEvent>().Subscribe(AddNewLost);
            EventAggregator.GetEvent<EditLostEvent>().Subscribe(EditLost);
            RegionManager = regionManager;
            LostService = lostService;
            ButtonCloseVisibility = Visibility.Collapsed;
        }

        private void EditLost(Lost l)
        {
            var oldItem = Losts.FirstOrDefault(i => i.Id == l.Id);
            var oldIndex = Losts.IndexOf(oldItem);
            Losts[oldIndex] = l;
        }

        private void AddNewLost(Lost l)
        {
            Losts.Add(l);
        }

        private void Navigate(string uri)
        {
            if (uri != null)
                RegionManager.RequestNavigate("ContentRegion", uri);
        }

        private void GetLosts(IEnumerable<Lost> ls)
        {
            foreach (var l in ls)
            {
                Losts.Add(l);
            }
        }

        private void GetInstitution(Institution inst)
        {
            if (inst != null)
            {
                Institution = new Institution();
                Institution.Id = inst.Id;
                Institution.Name = inst.Name;
                Institution.InstitutionCity = inst.InstitutionCity;
                Institution.Number = inst.Number;
                Institution.OpeningHours = inst.OpeningHours;
                Institution.Website = inst.Website;
                Institution.Address = inst.Address;
            }
        }


        private DelegateCommand <Lost> deleteLostCommand;
        public DelegateCommand <Lost> DeleteLostCommand
        {
            get
            {
                return deleteLostCommand ?? (deleteLostCommand = new DelegateCommand<Lost>(
                    param =>
                    {
                       var res = LostService.RemoveLost(Institution, param);
                       if (res) {
                           Losts.Remove(param);
                       }
                    }
                ));
            }
        }

        private DelegateCommand addLostCommand;
        public DelegateCommand AddLostCommand
        {
            get
            {
                return addLostCommand ?? (addLostCommand = new DelegateCommand(
                    () =>
                    {
                        Navigate("ViewForm");
                    }
                ));
            }
        }

        private DelegateCommand<Lost> editLostCommand;
        public DelegateCommand<Lost> EditLostCommand
        {
            get
            {
                return editLostCommand ?? (editLostCommand = new DelegateCommand<Lost>(
                    param =>
                    {

                        Navigate("ViewForm");
                        EventAggregator.GetEvent<EditLostEvent>().Publish(param);
                    }
                ));
            }
        }

        private DelegateCommand logoutCommand;
        public DelegateCommand LogoutCommand
        {
            get
            {
                return logoutCommand ?? (logoutCommand = new DelegateCommand(
                    () =>
                    {
                        Navigate("ViewLogin");
                    }
                ));
            }
        }

        private DelegateCommand openMenuCommand;
        public DelegateCommand OpenMenuCommand
        {
            get
            {
                return openMenuCommand ?? (openMenuCommand = new DelegateCommand(
                    () =>
                    {
                        ButtonCloseVisibility = Visibility.Visible;
                        ButtonOpenVisibility = Visibility.Collapsed;
                    }
                ));
            }
        }

        private DelegateCommand closeMenuCommand;
        public DelegateCommand CloseMenuCommand
        {
            get
            {
                return closeMenuCommand ?? (closeMenuCommand = new DelegateCommand(
                    () =>
                    {
                        ButtonCloseVisibility = Visibility.Collapsed;
                        ButtonOpenVisibility = Visibility.Visible;
                    }
                ));
            }
        }

    }
}
