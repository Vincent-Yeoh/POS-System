using CommunityToolkit.Mvvm.Input;
using MangoMartDb.DTOs;
using MangoMartDb.Models;
using MangoMartDbService.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace POS_System.ViewModels
{
    internal class MainViewModel : ViewModel
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
        private int _pageCounter = 1;
        private int _pageSize = 0;
 

        public string testingText { get; set; }
        public IDatabaseService _databaseService { get; }

        public MainViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
            LoadCommand = new RelayCommand(OnLoadCommand);
            InitializeDatabase();

        }

        private async void OnLoadCommand()
        {
            IsLoading = true;
            await LoadData();
            IsLoading = false;
        }
        private async Task LoadData()
        {

            if (_pageCounter > _pageSize) return;
            List<Product> products = await _databaseService.Get(_pageCounter++);

            foreach (Product product in products)
            {
                Products.Add(ProductViewModel.MapProduct(product));
            }

        }

        public async void InitializeDatabase()
        {
            _pageSize = await _databaseService.GetPageTotal();
            await LoadData();
        }
    }
}
