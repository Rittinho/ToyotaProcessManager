using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ToyotaProcessManager.MVVM.View.Pages.Main;
using ToyotaProcessManager.MVVM.View.Pages.Main.RegisterView;
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
            builder.Services.AddTransient<CreateTableView>();
            builder.Services.AddTransient<RegisterView>();
            builder.Services.AddTransient<ShowTableViw>();


            var app = builder.Build();

            ServiceProvider = app.Services;
#endif

            return app;
        }
    }
}
