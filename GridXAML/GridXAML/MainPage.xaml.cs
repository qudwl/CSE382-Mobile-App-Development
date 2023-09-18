namespace GridXAML;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
    {
		if (!(inputText.Text == "0"))
			inputText.Text += (sender as Button).Text;
		else
			inputText.Text = (sender as Button).Text;
    }

	private void Clear_Text(object sender, EventArgs e)
	{
		inputText.Text = "";
	}
}

