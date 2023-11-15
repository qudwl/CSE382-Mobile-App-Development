using FinalProject.Models;
using Newtonsoft.Json;
using System.ComponentModel;
namespace FinalProject.ViewModels
{
    public class CourseViewModel: INotifyPropertyChanged
    {
        public Department[] departments;
        public CourseViewModel()
        {
         

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

