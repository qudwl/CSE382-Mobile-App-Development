using System;
using System.Collections.ObjectModel;
using FinalProject.Models;
using FinalProject.Views;
using System.ComponentModel;
using System.Windows.Input;
using Android.Telecom;

namespace FinalProject.ViewModels
{
	public class MainViewModel: INotifyPropertyChanged
	{
        Course[] savedCourses { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        ICommand Refresh;
        ICommand DeleteAll;

        public MainViewModel()
        {
            UpdateCourseList();
        }

        public void UpdateCourseList()
        {
            savedCourses = DB.conn.Table<Course>().ToArray();
            foreach (var course in savedCourses)
            {
                course.Schedules = DB.conn.Table<Schedule>().Where(s => s.Crn == course.Crn).ToArray();
            }
        }
    }
}

