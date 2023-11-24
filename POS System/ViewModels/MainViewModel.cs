using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MangoMartDb.DTOs;
using MangoMartDb.Models;
using MangoMartDbService.Messages;
using MangoMartDbService.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Product = MangoMartDb.Models.Product;

namespace POS_System.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public RelayCommand LoadCommand { get; set; }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        public ObservableCollection<ProductViewModel> Products { get; set; } = new ObservableCollection<ProductViewModel>();
 
 

        public string testingText { get; set; }
        public IDatabaseService _databaseService { get; }

        public MainViewModel(IDatabaseService databaseService)
        {
            WeakReferenceMessenger.Default.Register<ProductBatch>(this, OnReceiveProductBatch);
            _databaseService = databaseService;
            InitializeDatabase();

        }


        public void InitializeDatabase()
        {
            var products = _databaseService.InitiateDataStream();
            MapProductViewModel(products);
        }

        private void OnReceiveProductBatch(object recipient, ProductBatch message)
        {
            MapProductViewModel(message.Value);
            Console.WriteLine("Batch arrived!");
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
