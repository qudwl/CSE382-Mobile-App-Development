namespace ExerciseNavigation;

public partial class Credits : ContentPage
{
    public Credits()
    {
        InitializeComponent();
    }

    private async void DoneButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}