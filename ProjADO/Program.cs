using ProjADO.Controllers;
using ProjADO.Model;

Console.WriteLine("Proj MVC - ADO.NET");
Console.WriteLine("Teste de inclusão de dados");

#region[Método abreviado]
// Este método de contruir é uma abreviação dos 2 métodos avbaixo.
//if (new AirplaneController().Insert(new Airplane()
//{
//    Descripition = "Para testes",
//    Id = 1,
//    Name = "TOP TURBO",
//    NumbOfPassengers = 20
//}));
#endregion

Airplane airplane = new()
{
    Descripition = "Para testes",
    Id = 1,
    Name = "TOP TURBO",
    NumbOfPassengers = 20,
    Engine = new() { Description = "Turbo-Helice"} // um objeto precisa receber um new!
};

for(int i = 0; i <= 100; i++)
{
    if (new AirplaneController().Insert(airplane))
        Console.WriteLine("Inserido com sucesso!");
    else
        Console.WriteLine("Erro ao inserir registro!");
}
//if (new AirplaneController().Insert(airplane))
//    Console.WriteLine("Inserido com sucesso!");
//else
//    Console.WriteLine("Erro ao inserir registro!");

new AirplaneController().FindAll().ForEach(Console.WriteLine);
