using System;
using System.Collections.Generic;
using System.Linq;

public class MainProgram
{
    public static void Main()
    {
        try
        {
            Country bg = new Country("Bulgaria", 7100000, 111000, "Sofia", "Plovdiv", "Varna");
            Country usa = new Country("USA", 300000000, 1200000, "New York", "Los Angeles", "San Francisco");
            Country bg2 = new Country("Bulgaria", 8000000, 10);
            Country bg3 = new Country("Bulgaria", 8000000, 111000);
            Country hr = new Country("Croatia", 8000000, 111000);

            Console.WriteLine(bg == bg2); // True
            Console.WriteLine(bg == usa); // False
            Console.WriteLine(bg != bg2); // False
            Console.WriteLine(bg != usa); // True

            var countries = new List<Country> { bg, usa, bg2, bg3, hr };
            countries.Sort();

            Console.WriteLine(
                string.Join(Environment.NewLine, countries
                    .Select(c => new {c.Name, c.Area, c.Population})));

            var bgCopy = bg.Clone() as Country;
            bg.Cities.Add("Kaspichan");
            Console.WriteLine(string.Join(", ", bg.Cities));
            Console.WriteLine(string.Join(", ", bgCopy.Cities));


        }

        catch (ArgumentNullException ex)
        {
            Console.Error.WriteLine(ex.Message);
        }

        catch (ArgumentOutOfRangeException ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }
}