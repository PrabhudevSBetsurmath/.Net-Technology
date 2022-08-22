using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment
{
    internal class FourWheeler : Vehicle
    {
        public string FuelType()
        {
            return "the fuel type is petrol,diesel,CNG";
        }

        public int PriceOfVechile()
        {
            return 600000;
        }
    }
}
