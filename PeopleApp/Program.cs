using static System.Console;
using Packt.Shared;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

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
        /*
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
        */

        //읽기전용 필드
        Person blankPerson = new();
        WriteLine(
            format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
            arg0: blankPerson.Name,
            arg1: blankPerson.HomePlanet,
            arg2: blankPerson.Instantiated
            );

        Person gunny = new(initialName: "Gunny", homePlanet: "Mars");
        WriteLine(
           format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
           arg0: gunny.Name,
           arg1: gunny.HomePlanet,
           arg2: gunny.Instantiated
           );

        bob.WriteToConsole();
        WriteLine(bob.GetOrigin());

        (string, int) fruit = bob.GetFruit();
        WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

        var fruitNamed = bob.GetNamedFruit();
        WriteLine($"there are {fruitNamed.Number}, {fruitNamed.Name} .");

        //튜플 이름 추론
        var thing1 = ("Nevile", 4);
        WriteLine($"{thing1.Item1} has {thing1.Item2} children");
        var thing2 = (bob.Name, bob.Children.Count);
        WriteLine($"{thing2.Name} has {thing2.Count} children");

        WriteLine(bob.SayHello());
        WriteLine(bob.SayHello("Emily"));

        WriteLine(bob.OptionalParameters("Jump!", 98.5));

        //이름지정 매개변수
        WriteLine(bob.OptionalParameters(command: "Hide!", number: 52.7));
        WriteLine(bob.OptionalParameters(command: "Poke", active: false));

        int a = 10;
        int b = 20;
        int c = 30;
        WriteLine($"Before : a = {a}, b = {b}, c = {c}");
        bob.PassingPrameters(a, ref b, out c);
        WriteLine($"After : a = {a}, b = {b}, c = {c}");


        int d = 10;
        int e = 20;
        WriteLine($"Before : d = {d}, e = {e}, f doesn't exist yet!");
        bob.PassingPrameters(d, ref e, out int f);
        WriteLine($"Before : d = {d}, e = {e}, f = {f}");

    }

}