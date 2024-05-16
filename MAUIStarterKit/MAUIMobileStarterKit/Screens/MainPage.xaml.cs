using Controls.UserDialogs.Maui;
using MAUIMobileStarterKit.ViewModels;
using Plugin.Firebase.CloudMessaging;

namespace MAUIMobileStarterKit.Screens;

public partial class MainPage : ContentPage
{
	private readonly IUserDialogs userDialogs;
    private readonly MainPageViewModels viewModels;

    public MainPage(MainPageViewModels viewModel, IUserDialogs userDialogs)
	{
		InitializeComponent();
		this.userDialogs = userDialogs;
        this.viewModels = viewModel;
 
        //push notification tapped event
        CrossFirebaseCloudMessaging.Current.NotificationTapped += delegate
        {
            NotificationHasTapped();
        };
    }
   
    private void NotificationHasTapped()
    {
       
    }

    protected override void OnAppearing()
    {
        //Get firebased token ID
        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            EnableCouldMessagingFacilities();
        }
        base.OnAppearing();

    }

    private async void EnableCouldMessagingFacilities()
    {
        await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
    }

    public async void ButtonClicked(System.Object sender, System.EventArgs e)
    {
        var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
        Console.WriteLine($"FCM token: {token}");

        if(DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            viewModels.GetNotification();
        }
        else
        {
          EnableCouldMessagingFacilities();
        }
    }
}
