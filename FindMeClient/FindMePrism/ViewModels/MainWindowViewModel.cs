using FindMePrism.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMePrism.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainWindowViewModel (IRegionManager regionManager, IAuthenticationService authService)
        {
            this.regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string uri)
        {          
            if (uri != null)
                this.regionManager.RequestNavigate("ContentRegion", uri);
        }
    }
}
