using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class Products
    {
        public int NumGood { get; set; }
        public string NameGood { get; set; }
        public int PriceGood
        {
            get
            {
                return PriceGood;
            }
            set
            {
                if (value < 0)
                    PriceGood = 1;
                else
                    PriceGood = value;
            }
        }
    }
}
