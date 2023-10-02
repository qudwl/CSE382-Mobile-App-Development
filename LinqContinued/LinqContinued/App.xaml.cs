﻿namespace LinqContinued;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		DB.InitDBConnection();
	}
}
