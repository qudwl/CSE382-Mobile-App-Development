using System.Collections.ObjectModel;
using FinalProject.Models;

namespace FinalProject.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		BindingContext = App.ViewModel;
	}
}
