using Android.App;
using Android.Runtime;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Platforms.Android;

namespace MAUIMobileStarterKit;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

    protected override MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.Services.AddSingleton<IRunTimeNotificationChanel, RunTimeNotificationChanel>();
        return MauiProgram.CreateMauiApp(builder);
    }
}

