using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared;

public partial class Person
{
    public string Origin
    {
        get {
            return $"{Name} was born on {HomePlanet}";
        }
    }

    public string Gretting => $"{Name} says 'Hello!'";
    public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

    public string FavoriteIceCream { get; set; }

    private string favoritePrimaryColor;
    public string FavoritePrimaryColor
    {
        get
        {
            return favoritePrimaryColor;
        }
        set
        {
            switch (value.ToLower())
            {
                case"red":
                case "green":
                case "blue":
                    favoritePrimaryColor = value;
                    break;
                default:
                    throw new System.ArgumentException(
                        $"{value} is not primary color." + "Choose form: red, green, blue."
                        );
            }
        }
    }

    // 인덱서
    public Person this[int index]
    {
        get
        {
            return Children[index];
        }
        set
        {
            Children[index] = value;
        }
    }
    
}
