﻿namespace SymptomTracker;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		DB.OpenConnection();
		DB.conn.CreateTable<Record>();
	}
}
