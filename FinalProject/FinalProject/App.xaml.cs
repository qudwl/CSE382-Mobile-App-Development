namespace FinalProject;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		DB.OpenConnection();
		if (!Preferences.ContainsKey("campus"))
			Preferences.Set("campus", "Oxford");

		MainPage = new AppShell();
	}
}

