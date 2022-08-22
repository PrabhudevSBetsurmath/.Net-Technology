using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment
{
    internal class TwoWheeler : Vehicle
    {
        public string FuelType()
        {
            return "the fuel type is petrol";
        }

        public int PriceOfVechile()
        {
            return 100000;
        }
    }
}
