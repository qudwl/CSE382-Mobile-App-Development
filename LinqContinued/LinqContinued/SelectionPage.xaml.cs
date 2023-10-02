namespace LinqContinued;

public partial class SelectionPage : ContentPage
{
	public SelectionPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e) {
		var pairs = from c in DB.conn.Table<Car>()
					select new Tuple<string, string>(c.Make, c.Model);
		var carPairs = from c in DB.conn.Table<Car>()
					select new CarPair(c.Make, c.Model);

		lv1.ItemsSource = pairs;
		lv2.ItemsSource = pairs;
		lv3.ItemsSource = carPairs;
	}
}