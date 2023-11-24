using System;
using System.Collections.ObjectModel;
using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = App.ViewModel;

		firstLoad();
	}

	private async void firstLoad()
	{
        await Task.Delay(1000);
		App.ViewModel.RefreshCourses();
    }

    async void courseList_ItemTapped(System.Object sender, Microsoft.Maui.Controls.ItemTappedEventArgs e)
    {
		await Navigation.PushAsync(new CoursePage(e.Item as Course));
    }
}
