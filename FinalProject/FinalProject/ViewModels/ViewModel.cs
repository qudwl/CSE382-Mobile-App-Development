using System;
using FinalProject.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FinalProject.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Course> Courses { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand RefreshPage { get; }
        public ICommand DeleteAllCommand { get; }

        public ViewModel()
        {
            Courses = new ObservableCollection<Course>();
            var tempList = DB.conn.Table<Course>().ToList();
            foreach (var course in tempList)
            {
                course.Schedules = DB.conn.Table<Schedule>().Where(s => s.Crn == course.Crn).ToArray();
                Courses.Add(course);
            }

            DeleteAllCommand = new Command(DeleteAll);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RefreshCourses()
        {

        }

        private void DeleteAll()
        {
            DB.conn.DropTable<Course>();
            DB.conn.DropTable<Schedule>();
            DB.conn.CreateTable<Course>();
            DB.conn.CreateTable<Schedule>();
            Courses.Clear();
        }
    }
}

