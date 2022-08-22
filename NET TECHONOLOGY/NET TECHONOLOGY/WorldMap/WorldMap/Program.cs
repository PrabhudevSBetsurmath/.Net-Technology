
namespace WorldMap
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryData countryData = new();

            GetCountries.GetNeighboringCountries(countryData.countries);

        }

    }
}
