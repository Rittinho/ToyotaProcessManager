using ToyotaProcessManager.MVVM.View.Pages.Main;
using ToyotaProcessManager.MVVM.View.Pages.Main.RegisterView;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.RegisterViewModel;
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
            var vm = MauiProgram.ServiceProvider.GetRequiredService<RegisterViewModel>();
            var window = new Window(new NavigationPage(new RegisterView(vm)));
            window.Height = 720;
            window.MinimumHeight = 720;
            window.Width = 1280;
            window.MinimumWidth = 1280;
            return window;
            //return new Window(new AppShell());
        }
    }
}