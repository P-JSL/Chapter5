using System;
using static System.Console;

namespace Packt.Shared;

public class Person : Object
{
    public string Name;
    public DateTime DateOfBirth;
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;

    //Collection
    public List<Person> Children = new();

    //상수
    public const string Species = "Homo Sapien";
}
