using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using SQLite;
using FinalProject.Models;

namespace FinalProject;

public class DB
{
    private static string DBName = "course.db";
    public static SQLiteConnection conn;

    public static void OpenConnection()
    {
        string libFolder = FileSystem.AppDataDirectory;
        string fname = System.IO.Path.Combine(libFolder, DBName);
        conn = new SQLiteConnection(fname);
        conn.CreateTable<Course>();
        conn.CreateTable<Schedule>();
    }
}

