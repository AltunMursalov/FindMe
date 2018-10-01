using FindMePrism.Events;
using FindMePrism.Models;
using FindMePrism.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace FindMePrism.ViewModels
{
    public class ViewChangePasswordViewModel : BindableBase
    {
        private Institution institution;
        public Institution Institution { get => institution; set => SetProperty(ref institution, value); }
     
        private readonly IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;
        private readonly IInstitutionService institutionService;
        public DelegateCommand SaveCommand { get; }


        public ViewChangePasswordViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IInstitutionService institutionService)
        {
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            this.institutionService = institutionService;
            this.eventAggregator.GetEvent<ChangePasswordEvent>().Subscribe(GetInstitution);
            SaveCommand = new DelegateCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
        }

        private void Navigate(string uri)
        {
            if (uri != null)
                this.regionManager.RequestNavigate("ContentRegion", uri);
        }

        private void GetInstitution(Institution institution)
        {
            if (institution != null) {
                Institution = new Institution();
                Institution = institution.Clone() as Institution;          
            }
        }

        private DelegateCommand cancelCommand;
        public DelegateCommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new DelegateCommand(
                    () => {
                        Navigate("ViewAdmin");
                        Institution = new Institution();
                    }
                ));
            }
        }



        private async void ExecuteSaveCommand()
        {
            var res = await institutionService.ChangePassword(Institution);
            if (res)
            {
                Navigate("ViewAdmin");
                Institution = new Institution();
            }
        }
        

        private bool CanExecuteSaveCommand()
        {
            if (Institution?.NewPassword == Institution?.ConfirmPassword)
                return true;
            return false;
        }
    }
}
