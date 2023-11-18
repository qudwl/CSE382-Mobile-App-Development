using FinalProject.ViewModels;

namespace FinalProject;

public partial class App : Application
{
	public static ViewModel ViewModel { get; set; }
	public App()
	{
		InitializeComponent();

		DB.OpenConnection();
		if (!Preferences.ContainsKey("campus"))
			Preferences.Set("campus", "Oxford");
		ViewModel = new ViewModel();
		MainPage = new AppShell();
	}
}

