namespace SymptomTracker;

public partial class MainPage : ContentPage {
    bool isBySeverity = false;

    public MainPage() {
		InitializeComponent();
        recordsView.ItemsSource = DB.conn.Table<Record>().ToList();
	}

    private async void addRecordButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new AddRecord(recordsView), true);
    }
}

