using DiApi.Data;

var builder = WebApplication.CreateBuilder(args);
// Registring Repo here
builder.Services.AddScoped<IDataRepo, SqlDataRepo>();

var app = builder.Build();

app.UseHttpsRedirection();

// Passing Interface by param
app.MapGet("/getdata", (IDataRepo repo) =>
{

    repo.ReturnData();
    return Results.Ok();
});

app.Run();

