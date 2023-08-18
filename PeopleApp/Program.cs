using static System.Console;
using Packt.Shared;

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

        WriteLine(format: "{0}`s favorite wonder is {1}, Its integer is {2}",
            arg0: bob.Name,
            arg1:bob.FavoriteAncientWonder,
            arg2:(int)bob.FavoriteAncientWonder) ;
        WriteLine($"{bob.Name}`s bucket list is {bob.BucketList}");

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