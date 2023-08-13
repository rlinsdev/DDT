using System.Text.Json;
using Serializer.Models;

var person = new Person{
    Id = 1,
    FirstName = "Sean",
    LastName = "Connery",
    Age = 90,
    IsAlive = false,
    Address = new Address {
        StreetName = "main Street",
        City = "New York",
        ZipCode = "234324234"
    }
};

var opt = new JsonSerializerOptions {
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

};

string jsonString = JsonSerializer.Serialize(person, opt);
string fileName = "person.json";

File.WriteAllText(fileName, jsonString);

Console.WriteLine(File.ReadAllText(fileName));
