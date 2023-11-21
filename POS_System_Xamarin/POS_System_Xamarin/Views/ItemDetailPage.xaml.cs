using POS_System_Xamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace POS_System_Xamarin.Views
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