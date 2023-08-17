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
    var commands = await context.commands.ToListAsync();

    return Results.Ok(commands);
});

// Get Simple
app.MapGet("api/v1/commands/{commandId}", async(AppDbContext context, string commandId) => {
    var commands = await context.commands.FirstOrDefaultAsync(c => c.CommandId == commandId);

    if (commands == null)
        return Results.NotFound();

    return Results.Ok(commands); 
});

// Create
app.MapPost("api/v1/commands", async(AppDbContext context, Command cmd) => {
    await context.commands.AddAsync(cmd);
    await context.SaveChangesAsync();

    return Results.Created($"api/v1/commands/{cmd.CommandId}", cmd);
});

// // Update 
// app.MapGet("api/v1/commands", async(AppDbContext context) => {

// });

// // Delete
// app.MapGet("api/v1/commands", async(AppDbContext context) => {

// });

app.Run();
