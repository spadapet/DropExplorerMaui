using Microsoft.Identity.Client.Extensions.Msal;
using System.IO;
using VsDrops.Model;

namespace VsDrops.Utility;

internal static class FileUtility
{
    public static string UserRootDirectory
    {
        get
        {
            string dir = Path.Combine(MsalCacheHelper.UserRootDirectory, MauiProgram.InternalName);
            Directory.CreateDirectory(dir);
            return dir;
        }
    }

    public static string AppModelFile => Path.Combine(FileUtility.UserRootDirectory, $"{nameof(AppModel)}.json");
}
