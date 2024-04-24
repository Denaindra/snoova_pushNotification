using Android.App;
using Firebase.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Platforms.Android
{
    [Service(Exported = true)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class AsdFirebaseMessagingService: FirebaseMessagingService
    {
        //public override void OnNewToken(string p0)
        //{
        //    base.OnNewToken(p0);
        //    if (Preferences.ContainsKey("DeviceToken"))
        //    {
        //        Preferences.Remove("DeviceToken");
        //    }
        //    Preferences.Set("DeviceToken", p0);
        //}

        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);
            var notification = message.GetNotification();
        }
    }
}
