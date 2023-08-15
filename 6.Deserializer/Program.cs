using System.Text.Json;

// var opt = new JsonSerializerOptions
// {
//     PropertyNameCaseInsensitive = true 
// };

using HttpClient client = new ()
{
    BaseAddress = new Uri("http://localhost:5138")
};

// var temperatures = await client.GetFromJsonAsync<Temperature[]>("weatherforecast", opt);

// if (temperatures != null)
// {
//     foreach (var temp in temperatures)
//     {
//         Console.WriteLine($"Summary: {temp.Summary}");
//     }
// }

var response = await client.GetAsync("weatherforecast");

if (response.IsSuccessStatusCode) 
{
    var jsonString = await response.Content.ReadAsStringAsync();

    using (JsonDocument jsonDocument = JsonDocument.Parse(jsonString))
    {
        JsonElement root = jsonDocument.RootElement;

        Console.WriteLine(root.ValueKind);

        foreach (var item in root.EnumerateArray())
        {
            Console.WriteLine(item.GetProperty("summary").ToString());

        }

    }
}
else
{
    Console.WriteLine($"Whoops! Error {response.StatusCode}");
}