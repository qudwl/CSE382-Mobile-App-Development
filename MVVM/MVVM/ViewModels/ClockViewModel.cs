using System;
using System.ComponentModel;

namespace MVVM.ViewModels;

public class ClockViewModel : INotifyPropertyChanged {
	DateTime dateTime = DateTime.Now;
	DateTime startedTime = DateTime.Now;
	Timer timer;

	public event PropertyChangedEventHandler PropertyChanged;

	public ClockViewModel() {
		timer = new Timer(new TimerCallback((s) => this.DateTime = DateTime.Now),
							   null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
	}
	~ClockViewModel() {
		timer.Dispose();
	}
	public DateTime DateTime {
		private set {
			if (dateTime != value) {
				dateTime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateTime"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartedTime"));
			}
		}
		get {
			return dateTime;
		}
	}

	public TimeSpan StartedTime
	{
		get
		{
			return dateTime.Subtract(startedTime);
		}
	}
}
