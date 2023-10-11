namespace ExerciseNavigation;

public partial class Technology : ContentPage
{

    private List<string> techArr = new List<string>();
    public Technology()
    {
        InitializeComponent();
        techArr.Add("XAML");
        techArr.Add("C#");
        techArr.Add("Maui");
        techArr.Add("JSON");
        techArr.Add("Asynchronous Programming");
        technologies.ItemsSource = techArr;
    }

    private async void technologies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        await Navigation.PushAsync(new TechInfo(e.SelectedItem as string));
    }
}