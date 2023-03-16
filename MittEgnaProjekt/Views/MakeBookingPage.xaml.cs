using MittEgnaProjekt.ViewModels;
namespace MittEgnaProjekt.Views;

public partial class MakeBookingPage : ContentPage
{
    public MakeBookingPage()
	{
        InitializeComponent();
        BindingContext = new BookedBoatsViewModel();
    }
    bool pageStarted = false;
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!pageStarted)
        {
            Task t = (BindingContext as BookedBoatsViewModel).GetBoats();
            pageStarted = true;
        }
    }
}