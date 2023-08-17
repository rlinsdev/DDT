using CommandApi.Data;
using Microsoft.EntityFrameworkCore;
using CommandAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLDbConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// GET Multi
app.MapGet("api/v1/commands", async(AppDbContext context) => {
    var commands = await context.Commands.ToListAsync();

    return Results.Ok(commands);
});

// Get Simple
app.MapGet("api/v1/commands/{commandId}", async(AppDbContext context, string commandId) => {
    var commands = await context.Commands.FirstOrDefaultAsync(c => c.CommandId == commandId);

    if (commands == null)
        return Results.NotFound();

    return Results.Ok(commands); 
});

// Create
app.MapPost("api/v1/commands", async(AppDbContext context, Command cmd) => {
    await context.Commands.AddAsync(cmd);
    await context.SaveChangesAsync();

    return Results.Created($"api/v1/commands/{cmd.CommandId}", cmd);
});

// Update 
app.MapPut("api/v1/commands/{commandId}", async(AppDbContext context, string commandId, Command cmd) => {
    var commands = await context.Commands.FirstOrDefaultAsync(c => c.CommandId == commandId);

    if (commands == null)
        return Results.NotFound();

    commands.HowTo = cmd.HowTo;
    commands.CommandLine = cmd.CommandLine;
    commands.Platform = cmd.Platform;

    await context.SaveChangesAsync();

    return Results.NoContent();
});

// Delete
app.MapDelete("api/v1/commands/{commandId}", async(AppDbContext context, string commandId) => {
    var commands = await context.Commands.FirstOrDefaultAsync(c => c.CommandId == commandId);

    if (commands == null)
        return Results.NotFound();

    context.Commands.Remove(commands);
    await context.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
