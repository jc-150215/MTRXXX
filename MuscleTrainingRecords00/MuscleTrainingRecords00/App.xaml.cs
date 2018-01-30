using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MuscleTrainingRecords00
{
    public partial class App : Application
    {
           public static string dbPath;

        public App(string dbPath)
        {
            App.dbPath = dbPath;
            InitializeComponent();
            MainPage = new MuscleTrainingRecords00.MainPage()
            {
                BarBackgroundColor = Color.FromHex("#00bfff"),
                BarTextColor = Color.White,
            };
            
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

        static TodoItemDatabase database;


        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

    }
}



/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;
namespace MuscleTrainingRecords
{
    public partial class App : Application
    {
        public static string dbPath; //データベースのパスを格納
        public App(string dbPath)
        {
            App.dbPath = dbPath; //AppのdbPathに引数のパスを指定
            InitializeComponent();
            MainPage = new MuscleTrainingRecords.MainPage();
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
*/
