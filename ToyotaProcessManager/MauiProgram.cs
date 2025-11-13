using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ToyotaProcessManager.MVVM.Model.Domain.Employee;
using ToyotaProcessManager.MVVM.Model.Domain.Process;
using ToyotaProcessManager.MVVM.Model.Domain.Table;
using ToyotaProcessManager.MVVM.View.Pages.Main.CreateTable;
using ToyotaProcessManager.MVVM.View.Pages.Main.Register;
using ToyotaProcessManager.MVVM.View.Pages.Main.ShowTable;
using ToyotaProcessManager.MVVM.ViewModel.Modal.Forms.IconPicker;
using ToyotaProcessManager.MVVM.ViewModel.Modal.Forms.TableConfigModal;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.CreateTable;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.Register;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.ShowTable;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.Injections.Implementation;

namespace ToyotaProcessManager
{
    public static class MauiProgram
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    fonts.AddFont("FAR.otf", "FAR");
                    fonts.AddFont("FAS.otf", "FAS");
                    fonts.AddFont("FAB.otf", "FAB");
                });

#if DEBUG
    		builder.Logging.AddDebug();

            builder.Services.AddTransient<IVerificationServices, VerificationServices>();
            builder.Services.AddTransient<INavigationServices, NavigationServices>();
            builder.Services.AddTransient<IJsonServices, JsonServices>();
            builder.Services.AddTransient<IPopServices, PopServices>();

            //views
            builder.Services.AddTransient<CreateTableView>();
            builder.Services.AddTransient<ShowTableView>();
            builder.Services.AddTransient<RegisterView>();
            //ViewModels
            builder.Services.AddTransient<TableConfigModalViewModel>();
            builder.Services.AddTransient<IconPickerModalViewModel>();
            builder.Services.AddTransient<CreateTableViewModel>();
            builder.Services.AddTransient<ShowTableViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();

            //models
            builder.Services.AddTransient<ToyotaEmployeeModel>();
            builder.Services.AddTransient<ToyotaProcessModel>();
            builder.Services.AddTransient<CreateTableModel>();

            var app = builder.Build();

            ServiceProvider = app.Services;
#endif

            return app;
        }
    }
}
