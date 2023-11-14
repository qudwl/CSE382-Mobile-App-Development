namespace FinalProject.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    void searchBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(new SearchPage());
    }

    void settingBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(new SettingsPage());
    }
}
