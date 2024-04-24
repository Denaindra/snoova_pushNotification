using Controls.UserDialogs.Maui;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Screens;
using MAUIMobileStarterKit.Utilities;
using MAUIMobileStarterKit.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Bundled.Shared;
#if IOS
using Plugin.Firebase.Bundled.Platforms.iOS;
#else
using Plugin.Firebase.Bundled.Platforms.Android;
#endif


namespace MAUIMobileStarterKit;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
			.UseMauiApp<App>()
            .RegisterFirebaseServices()
            .UseUserDialogs(true, () =>
            {
#if ANDROID
                var fontFamily = "OpenSans-Default.ttf";
#else
                    var fontFamily = "OpenSans-Regular";
#endif
                AlertConfig.DefaultMessageFontFamily = fontFamily;
                AlertConfig.DefaultUserInterfaceStyle = UserInterfaceStyle.Dark;
                AlertConfig.DefaultPositiveButtonTextColor = Colors.Purple;
                ConfirmConfig.DefaultMessageFontFamily = fontFamily;
                ActionSheetConfig.DefaultMessageFontFamily = fontFamily;
                ToastConfig.DefaultMessageFontFamily = fontFamily;
                SnackbarConfig.DefaultMessageFontFamily = fontFamily;
                HudDialogConfig.DefaultMessageFontFamily = fontFamily;
            })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //Views
        builder.Services.AddTransient<MainPage>();

        //ViewModels
        builder.Services.AddTransient<MainPageViewModels>();

        //Services
        builder.Services.AddSingleton<ILoading, Loading>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
    private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events => {
#if IOS
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                CrossFirebase.Initialize(CreateCrossFirebaseSettings());
                return false;
            }));
#else
            events.AddAndroid(android => android.OnCreate((activity, _) =>
                CrossFirebase.Initialize(activity, CreateCrossFirebaseSettings())));
#endif
        });

        builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
        return builder;
    }

    private static CrossFirebaseSettings CreateCrossFirebaseSettings()
    {
        return new CrossFirebaseSettings(
         isAuthEnabled: true,
         isCloudMessagingEnabled: true,
         isAnalyticsEnabled: true);
    }
}

