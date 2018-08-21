using FindMePrism.Events;
using FindMePrism.Models;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMePrism.ViewModels
{
    public class ViewLostsViewModel : BindableBase
    {
        private ObservableCollection<Lost> losts;
        public ObservableCollection<Lost> Losts { get => losts; set => SetProperty(ref losts, value); }

        public ViewLostsViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<LostsEvent>().Subscribe(GetLosts);
        }

        private void GetLosts(List<Lost> ls)
        {
            foreach (var l in ls)
            {
                Losts.Add(l);
            }
        }
    }
}
