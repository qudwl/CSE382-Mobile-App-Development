namespace SymptomTracker;

public partial class AddRecord : ContentPage
{
	public AddRecord()
	{
		InitializeComponent();
		severityPicker.ItemsSource = new int[10] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
		severityPicker.SelectedIndex = 0;
	}

    private async void cancelButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private async void addButton_Clicked(object sender, EventArgs e)
    {
		DateTime dt = new DateTime();
		dt = datePicker.Date;
		dt += timePicker.Time;

		string note = noteField.Text;
		int severity = severityPicker.SelectedIndex + 1;

		if (note != null && note.Length > 0) 
		{
            DB.conn.Insert(new Record(dt, note, severity));
            datePicker.Date = DateTime.Today;
            timePicker.Time = new TimeSpan(0, 0, 0);
            noteField.Text = "";
            severityPicker.SelectedIndex = 0;
            await Navigation.PopModalAsync();
			
        }
		else
		{
			await DisplayAlert("Error", "You must add a note.", "Ok");
		}
    }
}