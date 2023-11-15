using System;
using System.Collections.ObjectModel;
using FinalProject.Models;
using FinalProject.Views;
using System.ComponentModel;
using System.Windows.Input;
namespace FinalProject.ViewModels
{
	public class MainViewModel: INotifyPropertyChanged
	{
        ObservableCollection<Course> savedCourses;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            savedCourses = new ObservableCollection<Course>();
        }
    }
}

