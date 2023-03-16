using MittEgnaProjekt.ApplicationFacade;
using MittEgnaProjekt.Contracts;
using MittEgnaProjekt.ViewModels;

namespace MittEgnaProjekt.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private readonly ILogInFacade loginFacade = new LogInFacade();
    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        //Får de inmatade användarnamnen och lösenorden från Entry
        string username = userNameEntry.Text;
        string password = passWordEntry.Text;

        //Kalla CanLogIn metoden av loginFace för att se om användaren kan logga in
        if (loginFacade.CanLogIn(username, password))
        {
            DisplayAlert("Du har loggat in", "Välkommen!", "OK");

            //Om användaren kan logga in, skicka användaren till mainpage
            Navigation.PushAsync(new MainPage());
        }
        else
        {
            //Om användaren inte kan logga in, skriv ut ett felmeddelande
            DisplayAlert("Error", "Fel användarnamn eller lösenord", "OK");
        }
    }

    private void OnCreateAccountClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}