namespace TrainingDB;

public partial class QueriesPage : ContentPage
{
	public QueriesPage()
	{
		InitializeComponent();
	}
	private void OnClicked(object sender, EventArgs e) {
		TimeSpan hour = new TimeSpan(1, 0, 0);
		lv.ItemsSource = from activity in DB.conn.Table<Activity>()
						 where activity.Sport.Equals("Running")
						 select activity;
	}

	private void HrRunAllOnClicked(object sender, EventArgs e)
	{
        TimeSpan hour = new TimeSpan(1, 0, 0);
        lv.ItemsSource = from activity in DB.conn.Table<Activity>()
                         where activity.Sport.Equals("Running")
						 where activity.Duration > hour
                         select activity;
    }

    private void HrRunDates_Clicked(object sender, EventArgs e)
    {
        TimeSpan hour = new TimeSpan(1, 0, 0);
        lv.ItemsSource = from activity in DB.conn.Table<Activity>()
                         where activity.Sport.Equals("Running")
                         where activity.Duration > hour
                         select activity.DatePerformed;
    }

    private void HrRunDateDuration_Clicked(object sender, EventArgs e)
    {
        TimeSpan hour = new TimeSpan(1, 0, 0);
        lv.ItemsSource = from activity in DB.conn.Table<Activity>()
                         where activity.Sport.Equals("Running")
                         where activity.Duration > hour
                         select new Tuple<DateTime, TimeSpan>(activity.DatePerformed, activity.Duration);
    }

    private void LRunAll_Clicked(object sender, EventArgs e)
    {
        lv.ItemsSource = from activity in DB.conn.Table<Activity>().ToList()
                         where activity.Sport.Equals("Running")
                         where TestIfLong(activity.Sport, activity.Duration)
                         select activity;

    }

    private static bool TestIfLong(string activityName, TimeSpan time)
    {
        TimeSpan testTime = (from la in DB.conn.Table<LongActivityDefinition>()
                        where la.Sport.Equals(activityName)
                        select la.Duration).First();
        return time >= testTime;
    }

    private void Calories_Clicked(object sender, EventArgs e)
    {
        lv.ItemsSource = from activity in DB.conn.Table<Activity>().ToList()
                         where activity.GetCalories() >= 500
                         select activity;
    }
}