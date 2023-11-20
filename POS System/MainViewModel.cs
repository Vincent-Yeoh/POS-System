using CommunityToolkit.Mvvm.Input;
using MangoMartDb;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POS_System
{
    internal class MainViewModel : ViewModel
    {
        public RelayCommand ClickCommand { get; set; }
        public ObservableCollection<ProductViewModel> test { get; set; } = new ObservableCollection<ProductViewModel>();

        public string testingText { get; set; }
        public MangoDatabase _database { get; set; }

        public MainViewModel(MangoDatabase database)
        {
            
            

            _database = database;
            InitializeDatabase(_database);
            
        }

        public async void InitializeDatabase(MangoDatabase database)
        {
            var productList = database.B();
            foreach (var product in productList)
            {
                test.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Sku = product.Sku,
                    InStock = product.InStock,
                    Image = product.ImageFilePath,
                });
            }
        }
    }
}
