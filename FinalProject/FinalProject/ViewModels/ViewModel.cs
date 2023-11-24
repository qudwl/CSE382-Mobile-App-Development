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
        public ObservableCollection<Term> Terms { get; set; }
        private API api;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand RefreshPage { get; }
        public ICommand DeleteAllCommand { get; }
        private Term selectedTerm;
        private string campus;

        public ViewModel()
        {
            Courses = new ObservableCollection<Course>();
            Terms = new ObservableCollection<Term>();
            api = new API();
            SetTerms();
            Campus = Preferences.Get("campus", "o");
            DeleteAllCommand = new Command(DeleteAll);
            RefreshPage = new Command(RefreshCourses);
            RefreshCourses();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Term SelectedTerm
        {
            get { return selectedTerm; }
            set
            {
                if (selectedTerm != value)
                {
                    selectedTerm = value;
                    Preferences.Set("termCode", selectedTerm.id);
                    Console.WriteLine("Term changed to " + selectedTerm.label);
                    Courses.Clear();
                    OnPropertyChanged("SelectedTerm");
                }
            }
        }

        public string Campus
        {
            get { return campus; }
            set
            {
                if (value != campus)
                {
                    campus = value;
                    Preferences.Set("campus", campus);
                    OnPropertyChanged("Campus");
                }
            }
        }

        public void RefreshCourses()
        {
            Courses.Clear();
            var tempList = DB.conn.Table<Course>().ToList();
            foreach (var course in tempList)
            {
                course.Schedules = DB.conn.Table<Schedule>().Where(s => s.Crn == course.Crn).ToArray();
                Courses.Add(course);
            }
        }

        private void DeleteAll()
        {
            DB.conn.DropTable<Course>();
            DB.conn.DropTable<Schedule>();
            DB.conn.CreateTable<Course>();
            DB.conn.CreateTable<Schedule>();
            Courses.Clear();
        }

        private async void SetTerms()
        {
            Term[] tmp = await api.GetTerms();
            foreach (Term term in tmp)
            {
                Terms.Add(term);
            }
            if (!Preferences.ContainsKey("termId"))
                Preferences.Set("termId", Terms[2].id);
            else
            {
                int savedId = Preferences.Get("termId", -1);
                Term savedTerm = Terms.First(item => item.id == savedId);
                if (savedTerm != null)
                {
                    SelectedTerm = savedTerm;
                }
                else
                {
                    SelectedTerm = await api.GetTerm(savedId);
                }
            }
        }


    }
}

