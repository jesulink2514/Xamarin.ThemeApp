using Prism.Unity;
using ThemeApp.Views;
using Xamarin.Forms;

namespace ThemeApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        public static ThemeManager ThemeManager { get; private set; }

        protected override void OnInitialized()
        {
            InitializeComponent();

            ThemeManager = new ThemeManager();
            ThemeManager.Init();

            NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SettingsPage>();
        }
    }
}
