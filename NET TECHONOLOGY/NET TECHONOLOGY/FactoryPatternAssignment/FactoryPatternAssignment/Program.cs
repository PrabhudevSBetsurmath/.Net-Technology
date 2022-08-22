using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the type of the vehicle");
          string  VehicleType=Console.ReadLine();
            Vehicle vehicleDetails = VehicleFactory.GetVehicle(VehicleType);

            if (vehicleDetails != null)
            {
                Console.WriteLine("FuelType : " + vehicleDetails.FuelType());
                Console.WriteLine("PriceOfTheVechile: " + vehicleDetails.PriceOfVechile());
            }
            else
            {
                Console.Write("Invalid choice");
            }
            Console.ReadLine();
        }
    }
}
