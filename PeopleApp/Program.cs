using static System.Console;
using Packt.Shared;
using System.Collections.Generic;

namespace PeopleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Person bob = new();
        bob.Name = "Bob smith";
        bob.DateOfBirth = new DateTime(1965,12,22);
        bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
        bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabulon | WondersOfTheAncientWorld.MausoleumAthalicarnassus;
        
        //Collection
        bob.Children.Add(new Person { Name = "Alfred"}); //C# 3
        bob.Children.Add(new() { Name = "Zoe" }); // C# 9~

        WriteLine($"{bob.Name}`s bucket list is {bob.BucketList}");

        WriteLine($"{bob.Name} has {bob.Children.Count} children");
        for(int child = 0; child < bob.Children.Count; child++)
        {
            WriteLine($"    {bob.Children[child].Name}");
        }

        var alice = new Person
        {
            Name = "Alice Jones",
            DateOfBirth = new(1998, 3, 7)
        };

        WriteLine(format: "{0} was born on {1:dddd,d MMMM yyyy}",
            arg0: alice.Name,
            arg1: alice.DateOfBirth);
        }
    
    }