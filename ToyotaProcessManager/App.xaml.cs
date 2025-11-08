using ToyotaProcessManager.MVVM.View.Pages.Main;
using ToyotaProcessManager.MVVM.View.Pages.Main.RegisterView;
using ToyotaProcessManager.Services.Injections.Contract;

namespace ToyotaProcessManager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //var verificationServices = MauiProgram.ServiceProvider.GetRequiredService<IVerificationServices>();
            //var jsonServices = MauiProgram.ServiceProvider.GetRequiredService<IJsonServices>();
            var window = new Window(new NavigationPage(new RegisterView()));
            window.Height = 720;
            window.MinimumHeight = 720;
            window.Width = 1280;
            window.MinimumWidth = 1280;
            return window;
            //return new Window(new AppShell());
        }
    }
}