using System.Collections.ObjectModel;
using FinalProject.Models;

namespace FinalProject.Views;

public partial class SearchPage : ContentPage
{
    ObservableCollection<Course> Courses { get; set; }
    Department[] Departments;
    API api;
    public SearchPage()
    {
        Departments = new Department[]
        {
            new Department { Value = "AA", Label = "AA - Academic Affairs" },
            new Department { Value = "AAA", Label = "AAA - Asian/Asian American Studies" },
            new Department { Value = "ACC", Label = "ACC - Accountancy" },
            new Department { Value = "ACE", Label = "ACE - American Culture and English Prg" },
            new Department { Value = "AER", Label = "AER - Aeronautics" },
            new Department { Value = "AES", Label = "AES - Aerospace Studies" },
            new Department { Value = "AMS", Label = "AMS - American Studies" },
            new Department { Value = "APC", Label = "APC - Applied Communication" },
            new Department { Value = "ARB", Label = "ARB - Arabic" },
            new Department { Value = "ARC", Label = "ARC - Architecture and Interior Design" },
            new Department { Value = "ART", Label = "ART - Art" },
            new Department { Value = "ASO", Label = "ASO - Applied Social Science" },
            new Department { Value = "ATH", Label = "ATH - Anthropology" },
            new Department { Value = "BIO", Label = "BIO - Biology" },
            new Department { Value = "BIS", Label = "BIS - Integrative Studies" },
            new Department { Value = "BLS", Label = "BLS - Business Legal Studies" },
            new Department { Value = "BSC", Label = "BSC - Biological Sciences" },
            new Department { Value = "BUS", Label = "BUS - Business Analysis" },
            new Department { Value = "BWS", Label = "BWS - Black World Studies" },
            new Department { Value = "CAS", Label = "CAS - College of Arts and Science" },
            new Department { Value = "CCA", Label = "CCA - College of Creative Arts" },
            new Department { Value = "CEC", Label = "CEC - Col of Engineering and Computing" },
            new Department { Value = "CHI", Label = "CHI - Chinese" },
            new Department { Value = "CHM", Label = "CHM - Chemistry and Biochemistry" },
            new Department { Value = "CIT", Label = "CIT - Comp and Information Technology" },
            new Department { Value = "CJS", Label = "CJS - Criminal Justice Studies" },
            new Department { Value = "CLA", Label = "CLA - Col Liberal Arts and Applied Sci" },
            new Department { Value = "CLS", Label = "CLS - Classics" },
            new Department { Value = "CMA", Label = "CMA - Community Arts" },
            new Department { Value = "CMR", Label = "CMR - Commerce" },
            new Department { Value = "CMS", Label = "CMS - Comparative Media Studies" },
            new Department { Value = "CPB", Label = "CPB - Chem, Paper and Biomed Engineer" },
            new Department { Value = "CRD", Label = "CRD - Civic and Regional Development" },
            new Department { Value = "CRE", Label = "CRE - Critical Race and Ethnic Studies" },
            new Department { Value = "CSE", Label = "CSE - Comp Sci and Software Engineering" },
            new Department { Value = "CYB", Label = "CYB - Cybersecurity" },
            new Department { Value = "DST", Label = "DST - Disability Studies" },
            new Department { Value = "ECE", Label = "ECE - Electrical and Computer Engineer" },
            new Department { Value = "ECO", Label = "ECO - Economics" },
            new Department { Value = "EDL", Label = "EDL - Educational Leadership" },
            new Department { Value = "EDP", Label = "EDP - Educational Psychology" },
            new Department { Value = "EDT", Label = "EDT - Teaching, Curriculum and Ed Inquiry" },
            new Department { Value = "EGM", Label = "EGM - Engineering Management" },
            new Department { Value = "EGS", Label = "EGS - English Studies" },
            new Department { Value = "EHS", Label = "EHS - Education, Health and Society" },
            new Department { Value = "ENG", Label = "ENG - English" },
            new Department { Value = "ENT", Label = "ENT - Engineering Technology" },
            new Department { Value = "ENV", Label = "ENV - Environmental Science" },
            new Department { Value = "ESP", Label = "ESP - Entrepreneurship" },
            new Department { Value = "FAS", Label = "FAS - Fashion" },
            new Department { Value = "FIN", Label = "FIN - Finance" },
            new Department { Value = "FRE", Label = "FRE - French" },
            new Department { Value = "FST", Label = "FST - Film Studies" },
            new Department { Value = "FSW", Label = "FSW - Family Science and Social Work" },
            new Department { Value = "GEO", Label = "GEO - Geography" },
            new Department { Value = "GER", Label = "GER - German" },
            new Department { Value = "GHS", Label = "GHS - Global Health Studies" },
            new Department { Value = "GIC", Label = "GIC - Global and Intercultural Studies" },
            new Department { Value = "GLG", Label = "GLG - Geology" },
            new Department { Value = "GRK", Label = "GRK - Greek Language and Literature" },
            new Department { Value = "GSC", Label = "GSC - Graduate School Community" },
            new Department { Value = "GTY", Label = "GTY - Gerontology" },
            new Department { Value = "HON", Label = "HON - Honors" },
            new Department { Value = "HST", Label = "HST - History" },
            new Department { Value = "HUM", Label = "HUM - Humanities Center" },
            new Department { Value = "IDS", Label = "IDS - Interdisciplinary" },
            new Department { Value = "IES", Label = "IES - Environmental Sciences" },
            new Department { Value = "IMS", Label = "IMS - Emerging Tech = BusinessandDesign" },
            new Department { Value = "ISA", Label = "ISA - Information Systemsand Analytics" },
            new Department { Value = "ITL", Label = "ITL - Italian" },
            new Department { Value = "ITS", Label = "ITS - International Studies" },
            new Department { Value = "JPN", Label = "JPN - Japanese" },
            new Department { Value = "JRN", Label = "JRN - Journalism" },
            new Department { Value = "KNH", Label = "KNH - Kinesiology,Nutrition and Health" },
            new Department { Value = "KOR", Label = "KOR - Korean" },
            new Department { Value = "LAS", Label = "LAS - Latin American Studies" },
            new Department { Value = "LAT", Label = "LAT - Latin Language and Literature" },
            new Department { Value = "LIN", Label = "LIN - Linguistics" },
            new Department { Value = "LR", Label = "LR - Inst Learning in Retirement" },
            new Department { Value = "LST", Label = "LST - Liberal Studies" },
            new Department { Value = "LUX", Label = "LUX - Luxembourg" },
            new Department { Value = "MAC", Label = "MAC - Media and Communication" },
            new Department { Value = "MBI", Label = "MBI - Microbiology" },
            new Department { Value = "MGT", Label = "MGT - Management" },
            new Department { Value = "MJF", Label = "MJF - Media, Journalism and Film" },
            new Department { Value = "MKT", Label = "MKT - Marketing" },
            new Department { Value = "MME", Label = "MME - Mechan and Manufact Engineering" },
            new Department { Value = "MMS", Label = "MMS - Medical Science" },
            new Department { Value = "MSC", Label = "MSC - Military Science" },
            new Department { Value = "MTH", Label = "MTH - Mathematics" },
            new Department { Value = "MUS", Label = "MUS - Music" },
            new Department { Value = "NCS", Label = "NCS - Nonprofit and Community Studies" },
            new Department { Value = "NSC", Label = "NSC - Naval Science" },
            new Department { Value = "NSG", Label = "NSG - Nursing" },
            new Department { Value = "ORG", Label = "ORG - Organizational Leadership" },
            new Department { Value = "PAS", Label = "PAS - Physician Associate Studies" },
            new Department { Value = "PHL", Label = "PHL - Philosophy" },
            new Department { Value = "PHY", Label = "PHY - Physics" },
            new Department { Value = "PLW", Label = "PLW - Pre-Law Studies" },
            new Department { Value = "PMD", Label = "PMD - Premedical Studies" },
            new Department { Value = "POL", Label = "POL - Political Science" },
            new Department { Value = "POR", Label = "POR - Portuguese" },
            new Department { Value = "PSS", Label = "PSS - Psychological Science" },
            new Department { Value = "PSY", Label = "PSY - Psychology" },
            new Department { Value = "REL", Label = "REL - Religion, Comparative" },
            new Department { Value = "RUS", Label = "RUS - Russian" },
            new Department { Value = "SJS", Label = "SJS - Social Justice Studies" },
            new Department { Value = "SLM", Label = "SLM - Sport Leadership and Management" },
            new Department { Value = "SOC", Label = "SOC - Sociology" },
            new Department { Value = "SPA", Label = "SPA - Speech Pathology and Audiology" },
            new Department { Value = "SPN", Label = "SPN - Spanish" },
            new Department { Value = "STA", Label = "STA - Statistics" },
            new Department { Value = "STC", Label = "STC - Strategic Communication" },
            new Department { Value = "TCE", Label = "TCE - Teaching,CurriculumandEd Inquiry" },
            new Department { Value = "THE", Label = "THE - Theatre" },
            new Department { Value = "UNV", Label = "UNV - University" },
            new Department { Value = "WGS", Label = "WGS - Women,GenderandSexuality Studies" },
            new Department { Value = "WST", Label = "WST - Western Program" }
        };
        api = new API();
        Courses = new ObservableCollection<Course>();

        InitializeComponent();
        searchList.ItemsSource = Courses;
        departmentPicker.ItemsSource = Departments;
        departmentPicker.SelectedIndexChanged += DepartmentPicker_SelectedIndexChanged;
    }

    private void DepartmentPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = departmentPicker.SelectedIndex;
        string termCode = Preferences.Get("termCode", "202310");
        api.GetCourseByDepartment(Departments[index].Value, termCode, Courses);
    }
    async void searchList_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        Course course = (searchList.SelectedItem as Course);
        string message = "Would you like to add " + course.SectionName + "?";
        var addCourseAnswer = await DisplayAlert("Add Course to Favorites", message, "Yes", "No");

        if (addCourseAnswer)
        {
            DB.conn.Insert(course);
            foreach (var schedule in course.Schedules)
            {
                DB.conn.Insert(schedule);
            }
            var stack = Shell.Current.Navigation.NavigationStack.ToArray();
            foreach(var page in stack)
            {
                if (page is MainPage)
                {
                    Shell.Current.Navigation.RemovePage(page);
                    break;
                }
            }
            await Navigation.PushAsync(new MainPage());
        }

        else
        {
            searchList.SelectedItem = null;
        }
    }
}
