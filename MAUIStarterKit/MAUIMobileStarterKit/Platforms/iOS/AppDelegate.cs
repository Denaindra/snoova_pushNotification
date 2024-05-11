using Foundation;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Platforms.iOS;

namespace MAUIMobileStarterKit;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.Services.AddSingleton<IRunTimeNotificationChanel, RunTimeNotificationChanel>();
        return MauiProgram.CreateMauiApp(builder);
    }
}

