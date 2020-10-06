﻿using System;
using System.IO;
using Xamarin.Forms;
using Notes.Data;
using Notes.Views;

namespace Notes
{
    public partial class App : Application
    {
        static DsDatabase database;

        public static DsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
