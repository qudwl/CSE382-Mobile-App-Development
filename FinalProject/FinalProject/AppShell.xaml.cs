namespace FinalProject;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		if (!Preferences.ContainsKey("campus"))
			Preferences.Set("campus", "Oxford");
	}
}

