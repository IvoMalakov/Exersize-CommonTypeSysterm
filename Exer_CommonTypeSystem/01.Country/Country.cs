using System;
using System.Collections.Generic;
using System.Linq;

public class Country : IComparable<Country>, ICloneable
{
    private string name;
    private long population;
    private double area;
    private HashSet<string> cities;

    public Country(string name, long population, double area, params string[] cities)
    {
        this.Name = name;
        this.Population = population;
        this.Area = area;
        this.Cities = new HashSet<string>(cities);
    }


    public string Name
    {
        get { return this.name; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value", "Your name can not be null or empty");
            }

            this.name = value;
        }
    }

    public long Population
    {
        get { return this.population; }

        set
        {
            if (value < 0L)
            {
                throw new ArgumentOutOfRangeException("value", "Your population can not be negative");
            }

            this.population = value;
        }
    }

    public double Area
    {
        get { return this.area; }

        set
        {
            if (value < 0.0)
            {
                throw new ArgumentOutOfRangeException("value", "Your area can not be negative");
            }

            this.area = value;
        }
    }

    public HashSet<string> Cities { get; private set; }

    public int CompareTo(Country other)
    {
        if (Math.Abs(this.Area - other.Area) < 0.0001)
        {
            if (this.Population == other.Population)
            {
                return String.Compare(this.Name, other.Name, StringComparison.InvariantCulture);
            }

            return this.Population.CompareTo(other.Population) * -1;
        }

        return this.Area.CompareTo(other.Area) * -1;
    }

    public override bool Equals(object obj)
    {
        var other = obj as Country;

        if (object.Equals(other, null))
        {
            return false;
        }

        return this.Name.Equals(other.Name);
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
    }

    public object Clone()
    {
        Country clonedCountry = new Country(this.Name, this.Population, this.Area, this.Cities.ToArray());

        return clonedCountry;
    }

    public static bool operator ==(Country country1, Country country2)
    {
        if (object.Equals(country1, null))
        {
            return false;
        }

        return country1.Equals(country2);
    }

    public static bool operator !=(Country country1, Country country2)
    {
        if (object.Equals(country1, null))
        {
            return false;
        }

        return !country1.Equals(country2);
    }
}