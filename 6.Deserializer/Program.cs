﻿using System.Text.Json;
using Deserializer.Models;

var opt = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true 
};

using HttpClient client = new ()
{
    BaseAddress = new Uri("http://localhost:5138")
};
 
var response = await client.GetAsync("weatherforecast");

if (response.IsSuccessStatusCode) 
{
    var temperatures = await JsonSerializer.DeserializeAsync<Temperature[]>(await response.Content.ReadAsStreamAsync(), opt);

    if (temperatures != null)
    {
        foreach (var temperature in temperatures)
        {
            Console.WriteLine($"Summary: ", temperature.Summary);
        }
    }
}
else
{
    Console.WriteLine($"Whoops! Error {response.StatusCode}");
}