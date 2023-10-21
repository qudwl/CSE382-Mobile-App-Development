namespace SymptomTracker;

public partial class MainPage : ContentPage {
    bool isBySeverity = false;

    public MainPage() {
		InitializeComponent();
		recordsView.ItemsSource = DB.conn.Table<Record>().ToList().OrderBy(x => isBySeverity ? x.severity : x.timeOfIncident);
	}

    private async void addRecordButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new AddRecord(recordsView), true);
    }
}

