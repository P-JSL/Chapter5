using static System.Console;
using Packt.Shared;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Dynamic;

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
        
        var sam = new Person
        {
            Name = "Sam",
            DateOfBirth = new DateTime(1972, 1, 27)
        };
        WriteLine(sam.Origin);
        WriteLine(sam.Gretting);
        WriteLine(sam.Age);
        WriteLine();
        sam.FavoriteIceCream = "Chocolate Fudge";
        WriteLine($"Sam`s favorite ice-cream flavor is {sam.FavoriteIceCream}");
        sam.FavoritePrimaryColor = "Red";
        WriteLine($"Sam`s favorite primary color is {sam.FavoritePrimaryColor}");

        sam.Children.Add( new Person { Name="Charlie"} );
        sam.Children.Add(new Person { Name = "Ella" });

        WriteLine($"Sam`s first child is {sam.Children[0].Name}");
        WriteLine($"Sam`s second child is {sam.Children[1].Name}");
        WriteLine($"Sam`s first child is {sam[0].Name}");
        WriteLine($"Sam`s second child is {sam[1].Name}");

        WriteLine();
        object[] passengers =
        {
            new FirstClassPassenger {AirMiles = 1_419},
            new FirstClassPassenger {AirMiles = 16_562},
            new BusinessClassPassenger(),
            new CoachClassPassenger{ CarryOnKG = 25.7},
            new CoachClassPassenger{CarryOnKG = 0}
        };
        foreach (object passenger in passengers)
        {
            decimal flightCost = passenger switch
            {
                /* C# 8 구문
                FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
                FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
                FirstClassPassenger _ => 2000M, */

                // C# 9 구문
                FirstClassPassenger p => p.AirMiles switch
                {
                    > 35000 => 1500M,
                    > 15000 => 1750M,
                    _ => 2000M
                },
                BusinessClassPassenger _ => 1000M,
                CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
                CoachClassPassenger _ => 650M,
                _ => 800M
            };
            WriteLine($"Flight costs {flightCost:C} for {passenger}");
        }

        ImmutablePerson jeff = new()
        {
            FirstName = "Jeff",
            LastName = "Winger"
        };

        ImmutableVehicle car = new()
        {
            Brand = "Mazda MX-5 RF",
            Color = "Soul Red Crystal Metallic",
            Wheels = 4
        };

        ImmutableVehicle repaintedCar = car with
        {
            Color = "Polymetal Grey Metallic"
        };
        WriteLine();
        WriteLine($"Original car color was {car.Color}");
        WriteLine($"New car color is {repaintedCar.Color}");

        ImmutableAnimal oscar = new("Oscar", "Labrador");

        var (who, what) = oscar;
        WriteLine($"{who} is a {what}");
    }

}