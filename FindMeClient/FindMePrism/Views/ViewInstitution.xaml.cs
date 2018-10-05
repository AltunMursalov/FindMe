using FindMePrism.Events;
using Microsoft.Maps.MapControl.WPF;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FindMePrism.Views
{
    /// <summary>
    /// Interaction logic for ViewInstitution.xaml
    /// </summary>
    public partial class ViewInstitution : UserControl
    {
        public IEventAggregator EventAggregator { get; }

        public ViewInstitution(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            EventAggregator = eventAggregator;
            EventAggregator.GetEvent<EditProcessEvent>().Subscribe(InvisibleFields);
        }

        private void InvisibleFields(bool invisible)
        {
            if (invisible) {
                LoginField.Visibility = Visibility.Collapsed;
                PasswordField.Visibility = Visibility.Collapsed;
                Label.Text = "Institution Edit Form";
            }
            else
            {
                LoginField.Visibility = Visibility.Visible;
                PasswordField.Visibility = Visibility.Visible;
                Label.Text = "Institution Registration Form";
            }
        }
    }
}
