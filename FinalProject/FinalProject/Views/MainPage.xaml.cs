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
}
