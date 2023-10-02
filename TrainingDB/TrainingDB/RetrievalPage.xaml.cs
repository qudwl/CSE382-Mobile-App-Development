namespace TrainingDB;

public partial class RetrievalPage : ContentPage
{
	public RetrievalPage()
	{
		InitializeComponent();
		sport.SelectedIndex = 0;
	}
	protected override void OnAppearing() {
		base.OnAppearing();
		lvActivities.ItemsSource = null;
	}
	private void SportSelected(object sender, EventArgs e) {
		string S = (string)sport.SelectedItem;
		lvActivities.ItemsSource = DB.conn.Table<Activity>().Where(a => a.Sport.Equals(S));
	}
}