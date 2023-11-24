using MangoMartDbService.Services;
using Microsoft.Extensions.DependencyInjection;

using POS_System_Mobile.Views;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace POS_System_Mobile
{
    public partial class App : Application
    {
        public ServiceProvider ServiceProvider { get; }
        public App()
        {
            InitializeComponent();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            XF.Material.Forms.Material.Init(this);
  
            
            MainPage = new AppShell();
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "MangoLocalDb.db3");

            if (File.Exists(dbPath))
            {
                // Delete the database file
                File.Delete(dbPath);
                Console.WriteLine("Database file deleted successfully.");
            }
            else
            {
                Console.WriteLine("Database file does not exist.");
            }



            serviceCollection.AddSingleton(_ => new DatabaseService("ck_2682b35c4d9a8b6b6effac126ac552e0bfb315a0", "cs_cab8c9a729dfb49c50ce801a9ea41b577c00ad71", "https://mangomart-autocount.myboostorder.com/wp-json/wc/v1/products", $"Filename={dbPath}"));
        }

        protected override void OnStart()
        {


            _ = ServiceProvider.GetService<DatabaseService>();
            //await dbService.EnsureCreated();
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
