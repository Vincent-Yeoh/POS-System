using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POS_System_Mobile.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NumberStepper : Grid
    {

        public Color BtnColor
        {
            get { return (Color)GetValue(BtnColorProperty); }
            set { SetValue(BtnColorProperty, value); }
        }

        public static readonly BindableProperty BtnColorProperty =
            BindableProperty.Create(nameof(BtnColor), typeof(Color), typeof(NumberStepper), Color.Default);


        public decimal Value
        {
            get { return (decimal)GetValue(ValueProperty); }
            set {
                if (value > MaxValue) value = MaxValue;
                if (value < 0) value = 0;
                SetValue(ValueProperty, value); }
        }

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(decimal), typeof(NumberStepper), decimal.Zero);

        public decimal MaxValue
        {
            get { return (decimal)GetValue(MaxValueProperty); }
            set {
                if (value < 0) value = 0;
                SetValue(MaxValueProperty, value); }
        }

        public static readonly BindableProperty MaxValueProperty =
            BindableProperty.Create(nameof(MaxValue), typeof(decimal), typeof(NumberStepper), decimal.MaxValue);

        
        public NumberStepper()
        {
            InitializeComponent();
        }

        private void BtnMinus_Clicked(object sender, EventArgs e)
        {
            Value--;
        }

        private void BtnPlus_Clicked(object sender, EventArgs e)
        {
            Value++;
        }
    }
}