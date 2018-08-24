using System;
using FindMeMobileClient.Models;
using FindMeMobileClient.Services;
using FindMeMobileClient.Services.Interfaces;
using FindMeMobileClient.Views;
using Prism;
using Prism.Autofac;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace FindMeMobileClient
{
	public partial class App : PrismApplication
	{
        public static Filter Filter { get; set; }
        public App() : base(null)
        {
            InitializeComponent();
        }

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
            InitializeComponent();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDataService, DataService>();
            containerRegistry.RegisterForNavigation<HomePage>();
            containerRegistry.RegisterForNavigation<SettingsPage>();
            containerRegistry.RegisterForNavigation<OrganizationsPage>();
            containerRegistry.RegisterForNavigation<FilterPage>();
        }

        protected override void OnInitialized()
        {
            this.MainPage = new MainPage();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
    }
}
