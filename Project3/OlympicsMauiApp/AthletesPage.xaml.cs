using System.Diagnostics.Metrics;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace OlympicsMauiApp;

public partial class AthletesPage : ContentPage
{
	public AthletesPage()
	{
		InitializeComponent();
		athletes.ItemsSource = from p in DB.conn.Table<Participant2016Summer>()
							   where p.Country == "United States"
							   select p;
	}
}