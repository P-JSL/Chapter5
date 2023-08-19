using System;
using static System.Console;

namespace Packt.Shared;

public partial class Person : Object
{
    public string Name;
    public DateTime DateOfBirth;
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;

    //Collection
    public List<Person> Children = new();

    //상수
    public const string Species = "Homo Sapien";

    //읽기모드
    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;

    //생성자
    public Person()
    {
        //읽기전용 필드를 포함한 필드 기본값 설정
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }

    //메서드
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
    }
    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}";
    }

    //튜플
    public (string, int) GetFruit()
    {
        return ("Apples", 5);
    }

    public (string Name, int Number) GetNamedFruit()
    {
        return (Name: "Apples", Number: 5);
    }

    public string SayHello()
    {
        return $"{Name} says 'Hello!'.";
    }
    //overloading
    public string SayHello(string name)
    {
        return $"{Name} says 'Hello {name}!'";
    }

    public string OptionalParameters(
            string command = "Run!",
            double number = 0.0,
            bool active = true
        )
    {
        return string.Format(
            format: "command is {0}, number is {1}, active is {2}",
            arg0: command,
            arg1:number,
            arg2:active
            ) ;
    }

    //매개변수 전달제어하기
    public void PassingPrameters(int x, ref int y, out int z)
    {
        z = 99;
        x++;
        y++;
        z++;
    }



}


