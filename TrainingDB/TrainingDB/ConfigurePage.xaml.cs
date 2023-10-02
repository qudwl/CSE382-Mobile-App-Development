namespace TrainingDB;

public partial class ConfigurePage : ContentPage
{
	public ConfigurePage()
	{
		InitializeComponent();
	}
	private void ResetListViewSources() {
		lvActivities.ItemsSource = DB.conn.Table<Activity>().ToList();
		lvLongDefs.ItemsSource = DB.conn.Table<LongActivityDefinition>().ToList();
	}
	protected override void OnAppearing() {
		base.OnAppearing();
		ResetListViewSources();
	}
	private void ResetClicked(object sender, EventArgs e) {
		DB.RepopulateTables();
		ResetListViewSources();
	}
}