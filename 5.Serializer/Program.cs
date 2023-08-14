using System.Text.Json;
using Serializer.Models;
using Serializer.Helpers;

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
    },
    Phones = new List<Phone>() {
        new Phone { Type="Home", Number="1654654" },
        new Phone { Type="Mobile", Number="32323232" }
    }
};

var opt = new JsonSerializerOptions {
    WriteIndented = true,
    PropertyNamingPolicy = new LowerCaseNamingPolicy(),

};

string jsonString = JsonSerializer.Serialize(person, opt);
string fileName = "person.json";

File.WriteAllText(fileName, jsonString);

Console.WriteLine(File.ReadAllText(fileName));
