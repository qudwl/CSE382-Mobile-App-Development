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

        public ViewModel()
        {
            Courses = new ObservableCollection<Course>();
            Terms = new ObservableCollection<Term>();
            api = new API();
            var tempList = DB.conn.Table<Course>().ToList();
            foreach (var course in tempList)
            {
                course.Schedules = DB.conn.Table<Schedule>().Where(s => s.Crn == course.Crn).ToArray();
                Courses.Add(course);
            }
            SetTerms();
            
            DeleteAllCommand = new Command(DeleteAll);
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
                    Console.WriteLine("Term changed to " + selectedTerm.label);
                    OnPropertyChanged("SelectedTerm");
                }
            }
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

