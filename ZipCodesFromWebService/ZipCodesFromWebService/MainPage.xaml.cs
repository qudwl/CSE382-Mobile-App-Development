using System.Collections.ObjectModel;

namespace ZipCodesFromWebService;

public partial class MainPage : ContentPage
{

	WebRequest _webRequest;
	ObservableCollection<Place> Places;

	public MainPage()
	{
		InitializeComponent();
		_webRequest = new WebRequest();
		Places = new ObservableCollection<Place>();
		listOfZipCodes.ItemsSource = Places;
	}

    async void search_Clicked(System.Object sender, System.EventArgs e)
    {
		string cityText = city.Text;
		string stateText = state.Text;
		if (cityText != null && cityText.Length > 0 && stateText != null && stateText.Length > 0)
		{
            Response res = await _webRequest.GetData($"https://api.zippopotam.us/us/{stateText}/{cityText}");
			Places.Clear();
			foreach (Place place in res.Places)
			{
				Places.Add(place);
			}
        }
    }
}


