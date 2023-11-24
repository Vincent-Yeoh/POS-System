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
    public partial class ComboBox : Grid
    {
        public ComboBox()
        {
            InitializeComponent();
       
        }


        public IList<object> ItemsSource
        {
            get { return (IList<object>)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IList<object>), typeof(ComboBox), default, propertyChanged: OnItemsSourceChanged);

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
           if(bindable is ComboBox comboBox)
            {
                var value = newValue as List<object>;
                comboBox.picker.SelectedItem = value.FirstOrDefault();
            }
        }
    }
}