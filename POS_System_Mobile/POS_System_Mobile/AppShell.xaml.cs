using POS_System_Mobile.ViewModels;
using POS_System_Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace POS_System_Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
