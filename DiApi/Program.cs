using DiApi.Data;
using DiApi.DataServices;

var builder = WebApplication.CreateBuilder(args);

// Registring Repo here
builder.Services.AddScoped<IDataRepo, SqlDataRepo>();
builder.Services.AddScoped<IDataService, HttpDataService>();

var app = builder.Build();

app.UseHttpsRedirection();

// Passing Interface by param
app.MapGet("/getdata", (IDataRepo repo) =>
{

    repo.ReturnData();
    return Results.Ok();
});

app.Run();

