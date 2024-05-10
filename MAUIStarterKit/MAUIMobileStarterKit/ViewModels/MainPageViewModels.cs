using System;
using Controls.UserDialogs.Maui;
using MAUIMobileStarterKit.Interface;

namespace MAUIMobileStarterKit.ViewModels
{
	public class MainPageViewModels: BaseViewModel
    {
        private readonly ILoading loading;
        private readonly IRunTimeNotificationChanel notificationChanell;
        public MainPageViewModels(ILoading loading, IRunTimeNotificationChanel notificationChanell)
		{
            this.loading = loading;
            this.notificationChanell = notificationChanell;
		}

        public void StartLoading()
        {
            loading.StartIndicator();
        }

        public void EndLoading()
        {
            loading.EndIndiCator();
        }

        public void GetNotification()
        {
            notificationChanell.CreateRunTimeNotificationChannel();
        }
    }
}

