using CommandApi.Data;
using Microsoft.EntityFrameworkCore;
using CommandAPI.Models;
using CommandAPI.Data;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQL
builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLDbConnection")));

// Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(opt => 
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection")));

// SQL
// builder.Services.AddScoped<ICommandRepo, SqlCommandRepo>();
// Redis
builder.Services.AddScoped<ICommandRepo, RedisCommandRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// GET Multi
app.MapGet("api/v1/commands", async(ICommandRepo repo) => {
    var commands = await repo.GetAllCommandsAsync();
    return Results.Ok(commands);
});

// Get Simple
app.MapGet("api/v1/commands/{commandId}", async(ICommandRepo repo, string commandId) => {

    var commands = await repo.GetCommandByIdAsync(commandId);

    if (commands == null)
        return Results.NotFound();

    return Results.Ok(commands); 
});

// Create
app.MapPost("api/v1/commands", async(ICommandRepo repo, Command cmd) => {
    await repo.CreateCommandAsync(cmd);
    await repo.SaveChangesAsync();
     
    return Results.Created($"api/v1/commands/{cmd.CommandId}", cmd);
});

// Update 
app.MapPut("api/v1/commands/{commandId}", async(ICommandRepo repo, string commandId, Command cmd) => {
    var commands = await repo.GetCommandByIdAsync(commandId);

    if (commands == null)
        return Results.NotFound();

    commands.HowTo = cmd.HowTo;
    commands.CommandLine = cmd.CommandLine;
    commands.Platform = cmd.Platform;

     await repo.SaveChangesAsync();

    return Results.NoContent();
});

// Delete
app.MapDelete("api/v1/commands/{commandId}", async(ICommandRepo repo, string commandId) => {
    var commands = await repo.GetCommandByIdAsync(commandId);

    if (commands == null)
        return Results.NotFound();

    repo.DeleteCommand(commands);
    await repo.SaveChangesAsync(); 

    return Results.Ok();
});

app.Run();
