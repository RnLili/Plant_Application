using Microsoft.Extensions.Logging;

namespace PlantTracker_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<CompassPageViewModel>();
            builder.Services.AddSingleton<CompassPage>();
            builder.Services.AddSingleton<CalendarPageViewModel>();
            builder.Services.AddSingleton<CalendarPage>();
            builder.Services.AddTransient<EditPlantPageViewModel>();
            builder.Services.AddTransient<EditPlantPage>();
            builder.Services.AddSingleton<IPlantDatabase, SQLitePlantDatabase>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
