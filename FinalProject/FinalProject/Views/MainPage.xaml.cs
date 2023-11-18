using FinalProject.Models;

namespace FinalProject.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		UpdateCourseList();
	}

	public void UpdateCourseList()
	{
		var courses = DB.conn.Table<Course>().ToList();
		foreach (var course in courses)
		{
            course.Schedules = DB.conn.Table<Schedule>().Where(s => s.Crn == course.Crn).ToArray();
        }
		courseList.ItemsSource = courses;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		UpdateCourseList();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
		DB.conn.DeleteAll<Course>();
		DB.conn.DeleteAll<Schedule>();
    }
}
