
using POS_System_Mobile.ViewModels;
using POS_System_Mobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POS_System_Mobile.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public async void OnTapFrameRecognized(object sender, EventArgs args)
        {
            Console.WriteLine("what");
            await App.Current.MainPage.DisplayAlert("Test Title", "Test", "OK");
        }
    }
}