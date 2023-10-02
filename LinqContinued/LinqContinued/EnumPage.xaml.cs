namespace LinqContinued;

public partial class EnumPage : ContentPage
{
	public EnumPage()
	{
		InitializeComponent();
	}

	private void ButtonClicked(object sender, EventArgs e) {
		max.Text = (from c in DB.conn.Table<Car>()
						  select c.Cost).Max().ToString();
		average.Text = (from c in DB.conn.Table<Car>()
					select c.Cost).Average().ToString();
		count.Text = (from c in DB.conn.Table<Car>()
						where c.Cost < 30000
						select c.Cost).Count().ToString(); 
		aggregate.Text = (from c in DB.conn.Table<Car>()
					select c.Cost).Aggregate((a, b) => a+b).ToString();
		max.Text = (from c in DB.conn.Table<Car>()
						select c.Cost).Max().ToString();
		firstof.Text = (from c in DB.conn.Table<Car>()
						select c.Cost).FirstOrDefault().ToString();
		lastof.Text = (from c in DB.conn.Table<Car>()
						select c.Cost).LastOrDefault().ToString();
		distinctAndSortedLV.ItemsSource = (from c in DB.conn.Table<Car>()
										   select c.Make).Distinct().OrderBy(m => m);
		firstLetterF.ItemsSource = (from c in DB.conn.Table<Car>().ToList()   // .ToList() is needed
									where c.Make[0] =='F'
									select c);
	}
}