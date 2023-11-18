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
		UpdateCourseList();
		courses = new ObservableCollection<Course>();
		courseList.ItemsSource = courses;
	}

	public void UpdateCourseList()
	{
		courses.Clear();
		var dbList = DB.conn.Table<Course>().ToList();
		foreach (var course in dbList)
		{
            course.Schedules = DB.conn.Table<Schedule>().Where(s => s.Crn == course.Crn).ToArray();
			courses.Add(course);
        }
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		UpdateCourseList();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
		DB.conn.DeleteAll<Course>();
		DB.conn.DeleteAll<Schedule>();
		UpdateCourseList();
    }
}
