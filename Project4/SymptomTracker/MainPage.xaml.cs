using System.Diagnostics;

namespace SymptomTracker;

public partial class MainPage : ContentPage {
    string sorting;

    public MainPage() {
		InitializeComponent();

        if (Preferences.ContainsKey("isBySeverity"))
            sorting = Preferences.Get("isBySeverity", false) ? "Severity" : "Date";
        else
        {
            Preferences.Set("isBySeverity", false);
            sorting = "Date";
        }

        if (sorting == "Date")
        {
            byDate.IsChecked = true;
        }
        else
        {
            bySev.IsChecked = true;
        }

        refreshList();
    }

    private void refreshList()
    {
        var listFromDB = (DB.conn.Table<Record>().ToList());
        if (sorting == "Severity")
        {
            listFromDB = listFromDB.OrderBy(x => x.severity).ToList();
        }
        else
        {
            listFromDB = listFromDB.OrderBy(x => x.timeOfIncident).ToList();
        }
        recordsView.ItemsSource = listFromDB;
    }

    private async void addRecordButton_Clicked(object sender, EventArgs e)
    {
        AddRecord arPage = new AddRecord();
        arPage.Disappearing += (sender, e) =>
        {
            refreshList();
        };
        await Navigation.PushModalAsync(arPage, true);
    }

    private void CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        sorting = (sender as RadioButton).Value.ToString();
        Preferences.Set("isBySeverity", sorting == "Severity");
        refreshList();
    }

    private async void recordsView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        string res = await DisplayActionSheet("Operation", "Cancel", null, "Modify Record", "Delete Record");
        Record rc = recordsView.SelectedItem as Record;
        if (res == "Modify Record")
        {
            ModifyRecord mrPage = new ModifyRecord(rc);
            mrPage.Disappearing += (sender, e) =>
            {
                refreshList();
            };
            await Navigation.PushModalAsync(mrPage, true);
        }
        else if (res == "Delete Record")
        {
            bool deleteConfirm = await DisplayAlert("Warning", "Do you wish to delete this record?", "Yes", "No");
            if (deleteConfirm)
            {
                DB.conn.Delete(rc);
                refreshList();
            }
        }
    }
}

