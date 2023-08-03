using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Syncfusion.Maui.Core.Hosting;
using Xceed.Maui.Toolkit;

namespace VsDrops
{
    public static class MauiProgram
    {
        public const string DisplayName = "VS Drops";
        public const string InternalName = "VsDrops";
        public const string DefaultAccountName = "DevDiv";
        public const string DefaultProjectName = "DevDiv";

        public static MauiApp CreateMauiApp()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NGaF1cWmhAYVJpR2NbfE53flRGallUVBYiSV9jS31TfkVhWHZcdHZURmZdVA==");

            return MauiApp.CreateBuilder()
                .ConfigureSyncfusionCore()
                .UseXceedMauiToolkit()
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
