using CommunityToolkit.Mvvm.Messaging;
using MangoMartDb.Models;
using MangoMartDbService.Messages;
using MangoMartDbService.Services;
using Microsoft.Extensions.Options;
using POS_System_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace POS_System_Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<ProductViewModel> Products { get; }
        private DatabaseService _databaseService { get; }
        public ItemsViewModel()
        {
            _databaseService = ((App)Application.Current).ServiceProvider.GetService(typeof(DatabaseService)) as DatabaseService;
            Products = new ObservableCollection<ProductViewModel>();
            WeakReferenceMessenger.Default.Register<ProductBatch>(this, OnReceiveProductBatch);
            InitializeDatabase();
        }

        private void OnReceiveProductBatch(object recipient, ProductBatch message)
        {
            MapProductViewModel(message.Value);
            Console.WriteLine("Batch arrived!");
        }

        public void InitializeDatabase()
        {
            IsBusy = true;
            var products = _databaseService.InitiateDataStream();
            MapProductViewModel(products);
            IsBusy = false;
        }

        private void MapProductViewModel(List<Product> products)
        {
            foreach (var product in products)
            {
                Products.Add(ProductViewModel.MapProduct(product));
            }
        }
    }
}