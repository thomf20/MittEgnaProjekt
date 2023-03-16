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
        //F�r de inmatade anv�ndarnamnen och l�senorden fr�n Entry
        string username = userNameEntry.Text;
        string password = passWordEntry.Text;

        //Kalla CanLogIn metoden av loginFace f�r att se om anv�ndaren kan logga in
        if (loginFacade.CanLogIn(username, password))
        {
            DisplayAlert("Du har loggat in", "V�lkommen!", "OK");

            //Om anv�ndaren kan logga in, skicka anv�ndaren till mainpage
            Navigation.PushAsync(new MainPage());
        }
        else
        {
            //Om anv�ndaren inte kan logga in, skriv ut ett felmeddelande
            DisplayAlert("Error", "Fel anv�ndarnamn eller l�senord", "OK");
        }
    }

    private void OnCreateAccountClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}