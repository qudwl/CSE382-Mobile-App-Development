namespace EventHandlers;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		pickerElement.SelectedIndex = 0;
	}

	private void countButtonHandle(object sender, EventArgs e) {
		count++;
		countButtonLabel.Text = count.ToString();
	}

	private void entryHandle(object sender, TextChangedEventArgs e) {
		entryLabel.Text = entry.Text.Length.ToString();
	}

	private void checkHandle(object sender, EventArgs e)
	{
		if (checkBox.IsChecked)
		{
			checkBoxLabel.Text = "Checked";
		}
		else
		{
			checkBoxLabel.Text = "Unchecked";
		}
	}

	private void switchToggleHandle(object sender, EventArgs e)
	{
		if (switchToggle.IsToggled) 
		{
			switchToggleLabel.Text = "True";
		}
		else
		{
			switchToggleLabel.Text = "False";
		}
	}

    private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		sliderLabel.Text = sliderElement.Value.ToString();
    }

    private void stepperElement_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		stepperLabel.Text = stepperElement.Value.ToString();
    }

    private void pickerElement_SelectedIndexChanged(object sender, EventArgs e)
    {
		pickerLabel.Text = pickerElement.SelectedItem.ToString();
		pickerLabel.TextColor = Color.Parse(pickerElement.SelectedItem.ToString());
    }
}

