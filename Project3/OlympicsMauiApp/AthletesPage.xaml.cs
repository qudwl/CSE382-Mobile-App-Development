namespace OlympicsMauiApp;

public partial class AthletesPage : ContentPage
{
    private string country { get; set; }
    private string sport { get; set; }
    private string sportEvent { get; set; }
    public AthletesPage()
    {
        InitializeComponent();
        country = "";
        sport = "";
        sportEvent = "";
        var countriesList = (from p in DB.conn.Table<Participant2016Summer>()
                             orderby p.Country
                             select p.Country
                               ).Distinct();
        countries.ItemsSource = countriesList;
        countries.SelectedItem = countriesList.FirstOrDefault();
        var sportsList = (from p in DB.conn.Table<Participant2016Summer>()
                          orderby p.Sport
                          select p.Sport).Distinct();
        sports.ItemsSource = sportsList;
        sports.SelectedItem = sportsList.FirstOrDefault();
    }

    private void countries_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedCountry = countries.SelectedItem as string;
        if (country != selectedCountry)
        {
            country = selectedCountry;
        }

        showAtheletes();
    }

    private void sports_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        sport = e.SelectedItem as string;
        sportEvent = "";
        var eventsList = (from p in DB.conn.Table<Participant2016Summer>().ToList()
                          orderby p.Event
                          where p.Sport == sport
                          select p.Event).Distinct();
        events.ItemsSource = eventsList;
        events.SelectedItem = eventsList.FirstOrDefault();
    }

    private void events_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        sportEvent = e.SelectedItem as string;
        showAtheletes();
    }

    private void showAtheletes()
    {
        bool countrySelected = country != null && country.Length > 0;
        bool sportSelected = sport != null && sport.Length > 0;

        var linqVar = (from p in DB.conn.Table<Participant2016Summer>()
                       select p);

        if (countrySelected) linqVar = linqVar.Where((x) => x.Country == country);
        if (sportSelected) linqVar = linqVar.Where((y) => y.Sport == sport);

        atheletes.ItemsSource = linqVar.Where((x) => x.Event == sportEvent).OrderByDescending((x) => x.Medal).ToList();
        atheletes.SelectedItem = null;
    }

    private void atheletes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var participant = e.SelectedItem as Participant2016Summer;
        if (participant == null) return;
        var linqVar = (from p in DB.conn.Table<Participant2016Summer>()
                       where p.Name == participant.Name
                       where p.Country == participant.Country
                       orderby p.Event
                       select p.Event).ToList();
        var result = String.Join('\n', linqVar);
        DisplayAlert(participant.Name, result, "OK");
    }

    //private void atheletes_ItemTapped(object sender, ItemTappedEventArgs e)
    //{
    //    Debug.WriteLine(e.Group as Participant2016Summer);
    //}
}