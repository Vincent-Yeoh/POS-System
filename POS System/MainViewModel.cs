using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System
{
    internal class MainViewModel : ViewModel
    {
        List<Test> test = new List<Test>();

        public MainViewModel()
        {
            test.Add(new Test("Hello", 1));
            test.Add(new Test("World", 2));
        }
    }
}
