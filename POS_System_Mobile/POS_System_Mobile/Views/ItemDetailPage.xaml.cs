using POS_System_Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace POS_System_Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}