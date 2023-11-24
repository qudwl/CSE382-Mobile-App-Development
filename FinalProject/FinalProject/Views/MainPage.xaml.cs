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
	}

    async void courseList_ItemTapped(System.Object sender, Microsoft.Maui.Controls.ItemTappedEventArgs e)
    {
		Course course = (sender as Course);
		Console.WriteLine(course.Crn);
        await Navigation.PushAsync(new CoursePage());
    }
}
