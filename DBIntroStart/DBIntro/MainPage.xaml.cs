using SQLite;
namespace DBIntro;
public partial class MainPage : ContentPage
{
    SQLiteConnection conn;
    public void CreateConnection()
    {
        string libFolder = FileSystem.AppDataDirectory;
        string fname = System.IO.Path.Combine(libFolder, "users.db");
        conn = new SQLiteConnection(fname);
        conn.CreateTable<User>();
        conn.CreateTable<Person>();
    }
    public MainPage()
    {
        InitializeComponent();
        CreateConnection();
        lv.ItemsSource = conn.Table<User>().ToList();
        personList.ItemsSource = conn.Table<Person>().ToList(); 
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        User newUser = new User { Username = name.Text };
        conn.Insert(newUser);
        lv.ItemsSource = conn.Table<User>().ToList();
    }

    private void AddPerson(object sender, EventArgs e)
    {
        int income;
        if (personName.Text != null && personName.Text.Length > 0 && personSSN.Text != null 
            && personSSN.Text.Length > 0 && personIncome.Text != null && int.TryParse(personIncome.Text, out income))
        {
            Person newPerson = new Person { Name = personName.Text, DOB = personDOB.Date, SSN = personSSN.Text, Income = income };
            conn.Insert(newPerson);
            personList.ItemsSource = conn.Table<Person>().ToList();
            personName.Text = "";
            personDOB.Date = DateTime.Now;
            personSSN.Text = "";
            personIncome.Text = "";
        }
    }

    private void ClearPersons(object sender, EventArgs e)
    {
        conn.DeleteAll<Person>();
        personList.ItemsSource= conn.Table<Person>().ToList();
    }
}
