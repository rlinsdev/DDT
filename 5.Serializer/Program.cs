﻿using System.Text.Json;
using Serializer.Models;

var person = new Person{
    Id = 1,
    FirstName = "Sean",
    LastName = "Connery",
    Age = 90,
    IsAlive = false
};

string jsonString = JsonSerializer.Serialize(person);
string fileName = "person.json";

File.WriteAllText(fileName, jsonString);

Console.WriteLine(File.ReadAllText(fileName));
