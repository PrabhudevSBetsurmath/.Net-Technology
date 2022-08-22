using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment
{
    internal class ThreeWheeler : Vehicle
    {
        public string FuelType()
        {
            return "the fuel type is petrol,gas";
        }

        public int PriceOfVechile()
        {
            return 200000;
        }
    }
}
