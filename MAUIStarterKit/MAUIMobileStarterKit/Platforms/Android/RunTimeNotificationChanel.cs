using Android;
using Android.OS;
using MAUIMobileStarterKit.Interface;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MAUIMobileStarterKit.Platforms.Android
{
    public class RunTimeNotificationChanel: MainActivity, IRunTimeNotificationChanel
    {
        public async void CreateRunTimeNotificationChannel()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu)
            {
                var result = await Permissions.RequestAsync<PostNotifications>();
            }
        }
    }

    internal class PostNotifications : BasePlatformPermission
    {
        public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
                    new (string, bool)[] { (Manifest.Permission.PostNotifications, true) };
    }
}
