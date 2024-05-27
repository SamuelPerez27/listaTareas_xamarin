using System;
using taskList.data;
using taskList_tarea1.views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taskList_tarea1
{
    public partial class App : Application
    {
        public static databaseContext context { get; set; }

        public App()
        {
            InitializeComponent();
            InitializeDatabase();
            MainPage = new NavigationPage(new listView ());
        }
        private void InitializeDatabase()
        {
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = System.IO.Path.Combine(folderApp, "taskList.db3");
            context = new databaseContext(dbPath);
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
