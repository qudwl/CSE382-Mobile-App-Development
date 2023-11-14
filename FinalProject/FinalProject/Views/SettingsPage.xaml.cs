using System.Collections.ObjectModel;
using FinalProject.Models;

namespace FinalProject.Views;

public partial class SettingsPage : ContentPage
{
	ObservableCollection<Term> terms;
	API api;

	public SettingsPage()
	{
		InitializeComponent();
		api = new API();
		terms = new ObservableCollection<Term>();

		SetTerms();
	}

    void backBtn_Clicked(System.Object sender, System.EventArgs e)
    {
		Navigation.PopModalAsync();
    }

	async void SetTerms()
	{
		Term[] tmp = await api.GetTerms();
		foreach(Term term in tmp)
		{
			terms.Add(term);
		}
	}
}
