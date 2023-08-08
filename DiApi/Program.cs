using DiApi.Data;
using DiApi.DataServices;
using DiApi.Middleware;
using DiApi.Utility;

var builder = WebApplication.CreateBuilder(args);

// Registring Repo here
builder.Services.AddScoped<IDataRepo, SqlDataRepo>();
builder.Services.AddScoped<IDataService, HttpDataService>();

builder.Services.AddTransient<IOperationTransient, Operation>();
builder.Services.AddScoped<IOperationScoped, Operation>();
builder.Services.AddSingleton<IOperationSingleTon, Operation>();

var app = builder.Build();

app.UseCustomMiddleware();

app.UseHttpsRedirection();

// Passing Interface by param
// app.MapGet("/getdata", (IDataRepo repo) =>
app.MapGet("/getdata", (IOperationTransient transient, IOperationScoped scoped, IOperationSingleTon singleton) =>
{
     Console.WriteLine($"Endpoint: TransientId: {transient.OperationId}; ScopeId: {scoped.OperationId}; Singleton: {singleton.OperationId}");
    // repo.ReturnData();
    return Results.Ok();
});

app.Run();

