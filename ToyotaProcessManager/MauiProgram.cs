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
using ToyotaProcessManager.Services.Injections.Implementation.Repository;

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

                    fonts.AddFont("ToyotaFont.otf", "TOYOTA");

                    fonts.AddFont("FAR.otf", "FAR");
                    fonts.AddFont("FAS.otf", "FAS");
                    fonts.AddFont("FAB.otf", "FAB");
                });

#if DEBUG
    		builder.Logging.AddDebug();

            //services
            builder.Services.AddSingleton<IRepositoryServices, RepositoryServices>();

            builder.Services.AddTransient<IVerificationServices, VerificationServices>();
            builder.Services.AddTransient<INavigationServices, NavigationServices>();
            builder.Services.AddTransient<IJsonServices, JsonServices>();
            builder.Services.AddTransient<IPopServices, PopServices>();

            //views
            builder.Services.AddTransient<CreateTableView>();
            builder.Services.AddTransient<ShowTableView>();
            builder.Services.AddTransient<RegisterView>();

            //ViewModels
            builder.Services.AddSingleton<CreateTableViewModel>();
            builder.Services.AddSingleton<ShowTableViewModel>();
            builder.Services.AddSingleton<RegisterViewModel>();

            builder.Services.AddTransient<TableConfigModalViewModel>();
            builder.Services.AddTransient<IconPickerModalViewModel>();

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
