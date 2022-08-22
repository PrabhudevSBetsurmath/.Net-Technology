using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment
{
    class VehicleFactory
    {
        public static Vehicle GetVehicle(string vehicleType)
        {
            Vehicle vehicleDetails = null;
            if (vehicleType.ToLower() == "twowheeler")
            {
                vehicleDetails = new TwoWheeler();
            }
            else if (vehicleType.ToLower() == "threewheeler")
            {
                vehicleDetails = new ThreeWheeler();
            }
            else if (vehicleType.ToLower() == "fourwheeler")
            {
                vehicleDetails = new FourWheeler();
            }
            return vehicleDetails;
        }
    }
}
