using System;
using System.Collections.ObjectModel;
using FinalProject.Models;

namespace FinalProject.Views;

public partial class MainPage : ContentPage
{
	public ObservableCollection<Course> courses;
	public MainPage()
	{
		InitializeComponent();
		
		courses = new ObservableCollection<Course>();

        UpdateCourseList();
        courseList.ItemsSource = courses;
	}

    private void Button_Clicked_1(object sender, EventArgs e)
    {
		DB.conn.DeleteAll<Course>();
		DB.conn.DeleteAll<Schedule>();
		UpdateCourseList();
    }
}
