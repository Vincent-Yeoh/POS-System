using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POS_System
{
    internal class MainViewModel : ViewModel
    {
        public RelayCommand ClickCommand { get; set; }
        public List<Test> test { get; set; } = new List<Test>();

        public string testingText { get; set; }
        public MainViewModel()
        {
            ClickCommand = new RelayCommand(() => new Database().GetData());
            testingText = "If u happy and u know it clap your cheeks";
            //OnPropertyChanged(nameof(testingText));
            test.Add(new Test("Hello", 1));
            test.Add(new Test("World", 2));
        }
    }
}
