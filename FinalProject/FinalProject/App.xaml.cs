namespace FinalProject;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		DB.OpenConnection();

		MainPage = new AppShell();
	}
}

