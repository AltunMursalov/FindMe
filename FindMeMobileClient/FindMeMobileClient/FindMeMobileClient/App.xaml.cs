using FindMeMobileClient.Services;
using FindMeMobileClient.Services.Interfaces;
using FindMeMobileClient.Views;
using Prism;
using Prism.Autofac;
using Prism.Ioc;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FindMeMobileClient
{
    public partial class App : PrismApplication
	{
        public const string NotificationReceivedKey = "NotificationReceived";
        public const string MobileServiceUrl = "https://findmeazserver.azurewebsites.net";
        public static IFilterService filterService;
        public App() : base(null)
        {
            InitializeComponent();
        }

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
            InitializeComponent();
            filterService = new FilterService();
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