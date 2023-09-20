using System.Collections.ObjectModel;

namespace ListViewXAML;

public partial class TemplatePage : ContentPage {
	public ObservableCollection<School> Schools { get; private set; }
	public List<string> AvailableColors { get; }
	private School CurrentSchool { get; set; }

	public TemplatePage() {
		Schools = new ObservableCollection<School>();
		Schools.Add(new School { Name = "MU", SchoolColor = Colors.Red, School2ndColor = Colors.White, WebsiteURL = "https://www.miamioh.edu" });
		Schools.Add(new School { Name = "OSU", SchoolColor = Colors.Gray, School2ndColor = Colors.Red, WebsiteURL = "https://www.osu.edu" });
		Schools.Add(new School { Name = "UC", SchoolColor = Colors.Red, School2ndColor = Colors.Black, WebsiteURL = "https://www.uc.edu" });
		Schools.Add(new School { Name = "Ohio U", SchoolColor = Colors.Green, School2ndColor = Colors.Black, WebsiteURL = "https://www.ohio.edu" });
		Schools.Add(new School { Name = "BGSU", SchoolColor = Colors.Orange, School2ndColor = Colors.SaddleBrown, WebsiteURL = "https://www.bgsu.edu" });

		AvailableColors = new List<string> { "Red", "Blue", "Green", "Yellow", "Black", "White", "Gray", "Purple", "Orange" };

		InitializeComponent();

		lv.SelectedItem = Schools[0];
		lv.ItemsSource = Schools;
        SchoolColor.ItemsSource = AvailableColors;
        School2ndColor.ItemsSource = AvailableColors;
		SchoolColor.SelectedIndex = 0;
		School2ndColor.SelectedIndex = 0;
		CurrentSchool = Schools[0];
		lv_ItemTapped(null, null);
    }

    private void lv_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		if (CurrentSchool == null)
		{
			return;
		}
		CurrentSchool = lv.SelectedItem as School;
        webView.Source = CurrentSchool.WebsiteURL;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		if (SchoolName.Text == null || SchoolName.Text.Length == 0)
		{
			await DisplayAlert("Error", "School name not added", "OK");
			return;
		}
		else if (SchoolUrl.Text == null || !SchoolUrl.Text.StartsWith("https://"))
		{
			await DisplayAlert("Error", "URL not added correctly. Must start with https://", "OK");
			return;
		}


		School newSchool = new School
		{
			Name = SchoolName.Text,
			WebsiteURL = SchoolUrl.Text,
			SchoolColor = Color.Parse(SchoolColor.SelectedItem.ToString()),
			School2ndColor = Color.Parse(School2ndColor.SelectedItem.ToString()) 
		};

		Schools.Add(newSchool);
		SchoolName.Text = "";
		SchoolUrl.Text = "";
		SchoolColor.SelectedIndex = 0;
		School2ndColor.SelectedIndex = 0;
    }
}