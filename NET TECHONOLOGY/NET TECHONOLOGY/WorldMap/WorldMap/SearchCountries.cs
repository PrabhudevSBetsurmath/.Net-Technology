using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap
{
   public class SearchCountries
    {
        public static void SearchingneighbouringCountries(int numberOfNeighbours, string countryCode, Dictionary<string, List<string>> countries, List<string> neighbouringCountriesList)
        {
            if (!countries.ContainsKey(countryCode))
                return;
            if (numberOfNeighbours == countries[countryCode].Count)
            {
                return;
            }

            neighbouringCountriesList.Add(countries[countryCode][numberOfNeighbours]);

            numberOfNeighbours++;

            SearchingneighbouringCountries(numberOfNeighbours, countryCode, countries, neighbouringCountriesList);
        }

    }
}
