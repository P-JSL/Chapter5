using static System.Console;
using Packt.Shared;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PeopleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Person bob = new();
        bob.Name = "Bob smith";
        bob.DateOfBirth = new DateTime(1965, 12, 22);
        bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
        bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabulon | WondersOfTheAncientWorld.MausoleumAthalicarnassus;

        //Collection
        bob.Children.Add(new Person { Name = "Alfred" }); //C# 3
        bob.Children.Add(new() { Name = "Zoe" }); // C# 9~

        WriteLine($"{bob.Name}`s bucket list is {bob.BucketList}");

        WriteLine($"{bob.Name} has {bob.Children.Count} children");
        for (int child = 0; child < bob.Children.Count; child++)
        {
            WriteLine($"    {bob.Children[child].Name}");
        };

        var alice = new Person
        {
            Name = "Alice Jones",
            DateOfBirth = new(1998, 3, 7)
        };

        WriteLine(format: "{0} was born on {1:dddd,d MMMM yyyy}",
            arg0: alice.Name,
            arg1: alice.DateOfBirth);

        BankAccount.InterestRate = 0.012M;
        var jonesAccount = new BankAccount();
        jonesAccount.AccountName = "Mrs. Jones";
        jonesAccount.Balance = 2400;
        WriteLine(format : "{0} earned {1:c} interest",
            arg0:jonesAccount.AccountName,
            arg1:jonesAccount.Balance * BankAccount.InterestRate);

        var garrierAccount = new BankAccount();
        garrierAccount.AccountName = "Mrs. Gariier";
        garrierAccount.Balance = 98;
        WriteLine(format: "{0} earned {1:c} interest",
            arg0: garrierAccount.AccountName,
            arg1: garrierAccount.Balance * BankAccount.InterestRate);

        WriteLine($"{bob.Name} is a {Person.Species}");

        WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

    }

}