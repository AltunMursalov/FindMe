﻿using System;
using System.Collections.Generic;
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
    /// Interaction logic for ViewForm.xaml
    /// </summary>
    public partial class ViewForm : UserControl
    {
        public ViewForm()
        {
            InitializeComponent();
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/FindMePrism;component/Resources/family.jpg")));
        }
    }
}
