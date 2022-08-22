using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap
{
     class CountryData
    {

       public Dictionary<string, List<string>> countries = new Dictionary<string, List<string>>() {

                {"in", new List<string> {"Pakistan","Afghanistan", "China", "nepal", "Bangladesh", "Maldives", "Myanmar", "Sri Lanka" } },

                {"pak", new List<string> { "India", "Afghanistan", "China", "iran" } },

                {"chn", new List<string> { "India", "Afghanistan", "China", "Korea", "Nepal", "Bhutan", "Vietnam", "Tajikistan", "Kirghizstan" } }
            };
    }
}
