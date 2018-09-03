using System;
using FindMeMobileClient.Models;
using FindMeMobileClient.Services;
using FindMeMobileClient.Services.Interfaces;
using FindMeMobileClient.ViewModels;
using FindMeMobileClient.Views;
using Plugin.FirebasePushNotification;
using Prism;
using Prism.Autofac;
using Prism.Ioc;
using Prism.Plugin.Popups;
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
            containerRegistry.RegisterForNavigation<OrganizationsPage>();
            containerRegistry.RegisterForNavigation<MorePage>();
            containerRegistry.RegisterForNavigation<FilterPage>();
            containerRegistry.RegisterForNavigation<SettingsPage>();
        }

        protected override void OnInitialized()
        {
            this.MainPage = new MainPage();
        }

        protected override void OnStart ()
		{
            
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
