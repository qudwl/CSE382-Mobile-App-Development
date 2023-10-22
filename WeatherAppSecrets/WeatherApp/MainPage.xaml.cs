namespace WeatherApp;

using System.Collections.ObjectModel;

public partial class MainPage : ContentPage
{
    RestService _restService;
    ObservableCollection<WeatherData> data;

    public MainPage()
	{
		InitializeComponent();
        _restService = new RestService();
        data = new ObservableCollection<WeatherData>();
    }

    private async void OnGetWeatherButtonClicked(object sender, EventArgs e) {
        if (!string.IsNullOrWhiteSpace(_cityEntry.Text)) {
            string[] cities = _cityEntry.Text.Split(',');
            data.Clear();
            foreach (string city in cities) {
                string uriRequest = GenerateRequestUri(Constants.OpenWeatherMapEndpoint, city);
                WeatherData weatherData = await _restService.GetWeatherData(uriRequest);
                if (weatherData != null)
                    data.Add(weatherData);
            }
            lv.ItemsSource = data;
        }
    }
    string GenerateRequestUri(string endpoint, string city) {
        string requestUri = endpoint;
        requestUri += $"?q={city}";
        requestUri += "&units=imperial"; // or units=metric
        string key = Constants.GetOpenWeatherMapAPIKey();
        requestUri += $"&APPID={key}";
        return requestUri;
    }
}

