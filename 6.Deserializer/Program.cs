using System.Net.Http.Json;
using System.Text.Json;
using Deserializer.Models;

var opt = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true 
};

using HttpClient client = new ()
{
    BaseAddress = new Uri("http://localhost:5138")
};

var temperatures = await client.GetFromJsonAsync<Temperature[]>("weatherforecast", opt);

if (temperatures != null)
{
    foreach (var temp in temperatures)
    {
        Console.WriteLine($"Summary: {temp.Summary}");
    }
}

// First code
// var response = await client.GetAsync("weatherforecast");

// if (response.IsSuccessStatusCode) 
// {
//     var temperatures = await JsonSerializer.DeserializeAsync<Temperature[]>(await response.Content.ReadAsStreamAsync(), opt);

//     if (temperatures != null)
//     {
    // foreach (var temp in temperatures)
    //     {
    //         Console.WriteLine($"Summary: {temp.Summary}");
    //     }
//     }
// }
// else
// {
//     Console.WriteLine($"Whoops! Error {response.StatusCode}");
// }