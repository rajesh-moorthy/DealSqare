using System;
using System.IO;
using Xamarin.Forms;
using DsCustomer.Data;
using DsCustomer.Views;

namespace DsCustomer
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
                    database = new DsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DealSqare.db3"));
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
