namespace SymptomTracker;

public partial class ModifyRecord : ContentPage
{
    Record record;
	public ModifyRecord(Record rc)
	{
		InitializeComponent();
        record = rc;
        datePicker.Date = rc.timeOfIncident;
        timePicker.Time = rc.timeOfIncident.TimeOfDay;
        severityPicker.ItemsSource = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        severityPicker.SelectedIndex = rc.severity - 1;
        noteField.Text = rc.note;
	}

    private async void modButton_Clicked(object sender, EventArgs e)
    {
        if (noteField.Text != null && noteField.Text.Length > 0)
        {
            record.timeOfIncident = datePicker.Date;
            record.timeOfIncident += timePicker.Time;
            record.severity = severityPicker.SelectedIndex + 1;
            record.note = noteField.Text;
            DB.conn.Update(record);
        }
        await Navigation.PopModalAsync();
    }

    private async void cancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}