namespace ExerciseNavigation
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        Units units = new Units();
        Technology technology = new Technology();
        Credits credits = new Credits();

        private async void UnitsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(units, true);
        }

        private async void TechnologyButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(technology, true);
        }

        private async void CreditsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(credits, true);
        }
    }
}