using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System
{
    public class Test
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public Test(string name, float price)
        {
            Name = name;
            Price = price;
        }

    }
}

