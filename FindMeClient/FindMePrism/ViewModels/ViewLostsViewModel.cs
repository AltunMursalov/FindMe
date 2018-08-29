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

namespace FindMePrism.ViewModels
{
    class ViewLostsViewModel : BindableBase
    {
        private ObservableCollection<Lost> losts;
        public ObservableCollection<Lost> Losts { get => losts; set => SetProperty(ref losts, value); }

        private Institution institution;
        public Institution Institution
        {
            get { return institution; }
            set { SetProperty(ref institution, value); }
        }

        public IEventAggregator EventAggregator { get; }
        public IRegionManager RegionManager { get; }
        private readonly ILostService LostService;

        public ViewLostsViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, ILostService lostService)
        {
            Losts = new ObservableCollection<Lost>();
            EventAggregator = eventAggregator;
            EventAggregator.GetEvent<LostsEvent>().Subscribe(GetLosts);
            EventAggregator.GetEvent<InstEvent>().Subscribe(GetInstitution);
            RegionManager = regionManager;
            LostService = lostService;
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
                Institution = inst;
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
    }
}
