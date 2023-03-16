namespace MittEgnaProjekt;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    private async void OnMakeBookingClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.MakeBookingPage());
    }
    private async void OnCheckWeatherDataClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.WeatherDataPage());
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.LoginPage());
    }
}

