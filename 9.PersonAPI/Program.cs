using Microsoft.EntityFrameworkCore;
using PersonAPI.Data;
using PersonAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlDbConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Get all
app.MapGet("api/v1/people", async (AppDbContext context) => {
    var people = await context.People.ToListAsync();

    return Results.Ok(people);
});

// Get Single
app.MapGet("api/v1/people/{id}", async (AppDbContext context, int id) => {
    var person = await context.People.FindAsync(id);

    if (person == null)
        return Results.NotFound();

    return Results.Ok(person);
});

// Create
app.MapPost("api/v1/people", async (AppDbContext context, Person person) => {

    await context.People.AddAsync(person);
    await context.SaveChangesAsync();

    return Results.Created($"/api/v1/people/{person.Id}", person);
});

app.Run();
