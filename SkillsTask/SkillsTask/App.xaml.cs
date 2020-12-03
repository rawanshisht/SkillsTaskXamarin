using SkillsTask.Models;
using SkillsTask.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkillsTask
{
    public partial class App : Application
    {
        static Database database;

        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new SkillsListView());
        }

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "skills8.db3"));
                    App.Database.SaveSkillAsync(new Skill() { Name = "Name1", Level = 100, Descritpion = "desc1" });
                    App.Database.SaveSkillAsync(new Skill() { Name = "Name2", Level = 80, Descritpion = "desc2" });
                    App.Database.SaveSkillAsync(new Skill() { Name = "Name3", Level = 60, Descritpion = "desc3" });
                    App.Database.SaveSkillAsync(new Skill() { Name = "Name4", Level = 50, Descritpion = "desc4" });
                }
                return database;
            }
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
