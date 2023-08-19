using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared;

//init : 인스턴스 생성 시, 속성 변경 가능, 이후 불가능 
public class ImmutablePerson
{
    public string? FirstName { get; init; }
    public string? LastName { get; init;}

    
}
public record ImmutableVehicle
{
    public int Wheels { get; init; }
    public string Color { get; init; }
    public string Brand { get; init; }
}
//레코드를 정의하는 더 단순한 방법
//속성, 생성자, 분해자를 자동생성
public record ImmutableAnimal
{
    public string Name { get; init; }
    public string Species { get; init; }
    
    public ImmutableAnimal(string name, string species)
    {
        Name = name;
        Species = species;
    }
    public void Deconstruct(out string name, out string species)
    {
        name = Name;
        species = Species;
        
    }
    
}



