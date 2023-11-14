using System.Collections.ObjectModel;
using System.ComponentModel;
using FinalProject.Models;

namespace FinalProject.ViewModels
{
	public class SettingsViewModel : INotifyPropertyChanged
	{
		string campus;

        public event PropertyChangedEventHandler PropertyChanged;

        public SettingsViewModel()
		{
			campus = Preferences.Get("campus", "o");
        }

		public string Campus
		{
			get
			{
				return campus;
			}
			set
			{
				if (value != campus)
				{
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Campus"));
				}
			}
		}
	}
}

