using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CodingIdeas
{
    public partial class App : Application
    {
        public static string GetLocalFilePath(string fileName)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, fileName);
        }

        private string dbPath;

        // Our repository static member should go here
        public static IdeaRepository ideaRepository;
        
        public App()
        {
            InitializeComponent();
            dbPath = GetLocalFilePath("codingIdeas.db3");
            // Initialize the idea repository and pass in the result of the local file path method
            ideaRepository = new IdeaRepository(dbPath);
            MainPage = new MainPage();
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
