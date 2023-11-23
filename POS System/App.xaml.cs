using Accessibility;
using MangoMartDbService.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using POS_System.ViewModels;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;

namespace POS_System
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }
        public App()
        {


  
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<IDatabaseService>(provider => new DatabaseService("ck_2682b35c4d9a8b6b6effac126ac552e0bfb315a0", "cs_cab8c9a729dfb49c50ce801a9ea41b577c00ad71", "https://mangomart-autocount.myboostorder.com/wp-json/wc/v1/products", ConfigurationManager.
    ConnectionStrings["conn"].ConnectionString));
                    
                }).Build();

        }

        protected override async void OnStartup(StartupEventArgs e)
        {

     
            await AppHost!.StartAsync();
            var database = AppHost.Services.GetRequiredService<IDatabaseService>();
            //await database.EnsureCreated();
            var startUpForm = AppHost.Services.GetRequiredService<MainWindow>();
            startUpForm.DataContext = AppHost.Services.GetService<MainViewModel>();

     
            startUpForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e); 
        }
    

    }



}
