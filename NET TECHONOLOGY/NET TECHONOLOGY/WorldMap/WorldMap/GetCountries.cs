using System;
using System.Collections.Generic;

namespace WorldMap
{
  public  class GetCountries
    {
        public static void GetNeighboringCountries(Dictionary<string, List<string>> countries)
        {
            string countryCode;

            Console.WriteLine("Enter the Country Name to find its neighbours");
            countryCode = Console.ReadLine().ToLower();

            List<string> neighbouringCountriesList = new();

            int numberOfNeighbours = 0;


            SearchCountries.SearchingneighbouringCountries(numberOfNeighbours, countryCode, countries, neighbouringCountriesList);

            if (neighbouringCountriesList.Count == 0)
            {
                Console.WriteLine("Invalid Country Name");
                return;
            }

            Console.WriteLine("The Neighbouring Countries are : ");
            foreach (string country in neighbouringCountriesList)
            {
                Console.Write($"{country}\n");
            }

        }
    }
}
