namespace LinqContinued;

public partial class JoinPage : ContentPage
{
	public JoinPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e) {
		lv.ItemsSource = from model in DB.conn.Table<Car>()
						 join manufacturer in DB.conn.Table<Manufacturer>() on model.Make equals manufacturer.Name
						 select new { ModelName = model.Model, ManufacturerName = manufacturer.Name, HQ = manufacturer.Headquarters };
	}
}