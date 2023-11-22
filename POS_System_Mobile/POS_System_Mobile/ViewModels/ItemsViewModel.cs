using MangoMartDbService.Services;
using POS_System;
using POS_System_Mobile.Models;
using POS_System_Mobile.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace POS_System_Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<ProductViewModel> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        private DatabaseService _dbService { get; }

        public ItemsViewModel()
        {
            _dbService = ((App)Application.Current).ServiceProvider.GetService(typeof(DatabaseService)) as DatabaseService;
            
            Title = "Browse";
            Items = new ObservableCollection<ProductViewModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = _dbService.B();
                foreach (var item in items)
                {
                    Items.Add(
                        new ProductViewModel
                        {
                            Name = item.Name,
                            Price = item.Price,
                            Sku = item.Sku,
                            InStock = item.InStock,
                            Image = item.Image,
                        }
                        );
                    
                }
            }
            
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}