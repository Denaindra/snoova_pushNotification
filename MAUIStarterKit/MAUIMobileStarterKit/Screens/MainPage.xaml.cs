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
        GetFCMToken();

    }

    private async void GetFCMToken()
    {
        await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
        var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
        Console.WriteLine($"FCM token: {token}");
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

   async void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        viewModels.StartLoading();
        await Task.Delay(3000);
        viewModels.EndLoading();
    }
}
