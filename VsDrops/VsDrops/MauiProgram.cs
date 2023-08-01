using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace VsDrops
{
    public static class MauiProgram
    {
        public const string DisplayName = "VS Drops";
        public const string InternalName = "VsDrops";

        public static MauiApp CreateMauiApp()
        {
            return MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .Build();
        }
    }
}
