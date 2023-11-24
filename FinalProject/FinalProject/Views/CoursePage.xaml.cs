using FinalProject.Models;
using CommunityToolkit.Maui.Alerts;

namespace FinalProject.Views;

public partial class CoursePage : ContentPage
{
	Course course;
	public CoursePage(Course course)
	{
		this.course = course;
		InitializeComponent();
		title.Text = course.Title;
		courseId.Text = course.SectionName;
		description.Text = course.Description;
		currentRegistered.Text = course.CurrentStudents.ToString();
		totalAvailable.Text = course.MaxStudents.ToString();
		instructor.Text = course.Instructor;
		schedules.ItemsSource = course.Schedules;
		if (course.CurrentStudents < course.MaxStudents)
		{
			availability.BackgroundColor = Color.Parse("lightgreen");
		} else
		{
			availability.BackgroundColor = Color.Parse("red");
		}
	}

    async void deleteBtn_Pressed(System.Object sender, System.EventArgs e)
    {
		bool deleteCourse = await DisplayAlert("Delete Course", "Do you want to delete this course?", "Yes", "No");
		if (deleteCourse)
		{
            DB.conn.Delete(course);
            App.ViewModel.Courses.Remove(course);
            await Navigation.PopAsync();
        }
    }

    async void copyBtn_Pressed(System.Object sender, System.EventArgs e)
    {
		CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
		await Clipboard.Default.SetTextAsync(course.Crn.ToString());
		var toast = Toast.Make("Copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 14);
		await toast.Show(cancellationTokenSource.Token);
    }
}
