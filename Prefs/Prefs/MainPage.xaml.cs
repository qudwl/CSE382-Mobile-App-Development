namespace Prefs;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        if (!Preferences.ContainsKey("MetricMode"))
            Preferences.Set("MetricMode", false);
        if (!Preferences.ContainsKey("DateOfBirth"))
            Preferences.Set("DateOfBirth", new DateTime());
        if (!Preferences.ContainsKey("Experience"))
            Preferences.Set("Experience", 0.0);
        metricSwitch.IsToggled = Preferences.Get("MetricMode", false);
        dobPicker.Date = Preferences.Get("DateOfBirth", new DateTime());
        experienceSlider.Value = Preferences.Get("Experience", 0.0);
    }
    private void MetricSwitchToggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("MetricMode", metricSwitch.IsToggled);
    }

    private void dobPicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        Preferences.Set("DateOfBirth", dobPicker.Date);
    }

    private void experienceSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Preferences.Set("Experience", experienceSlider.Value);
    }
}

