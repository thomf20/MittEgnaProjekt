namespace MittEgnaProjekt.Views;

public partial class WeatherDataPage : ContentPage
{
    public WeatherDataPage() 
    {
        InitializeComponent();
        BindingContext = new ViewModels.WeatherDataPageViewModel().TheWeatherData;
    }
}