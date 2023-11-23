using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS_System.UserControls
{
    /// <summary>
    /// Interaction logic for NumericStepper.xaml
    /// </summary>
    public partial class NumericStepper : UserControl
    {

        public NumericStepper()
        {
            InitializeComponent();
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            Value--;
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            Value++;
        }


        public readonly static DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(decimal),
            typeof(NumericStepper),
            new PropertyMetadata(new decimal(0)));

        public decimal Value
        {
            get { return (decimal)GetValue(ValueProperty); }
            set
            {
                if (value < 0) value = 0;
                if (value > MaxValue)
                    value = MaxValue;
                SetValue(ValueProperty, value);
          
            }
        }


        public readonly static DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(decimal),
            typeof(NumericStepper),
            new PropertyMetadata(decimal.MaxValue));

        public decimal MaxValue
        {
            get { return (decimal)GetValue(MaxValueProperty); }
            set
            {
                if (value < 0)
                    value = 0;
                SetValue(MaxValueProperty, value);
            }
        }


  


 
    }
}
