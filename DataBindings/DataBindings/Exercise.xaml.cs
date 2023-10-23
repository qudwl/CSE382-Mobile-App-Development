namespace DataBindings;

public partial class Exercise : ContentPage
{
	public Exercise()
	{
		InitializeComponent();
		exercisePicker.ItemsSource = new string[] { "Apple", "Orange", "Lemon" };
		exercisePicker.SelectedIndex = 0;
	}
}