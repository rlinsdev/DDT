using Microsoft.EntityFrameworkCore;
using PersonAPI.Data;

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

app.MapGet("api/v1/people", async (AppDbContext context) => {
    var people = await context.People.ToListAsync();

    return Results.Ok(people);
});

app.MapGet("api/vi/people/{id}", async (AppDbContext context, int id) => {
    var person = await context.People.FindAsync(id);

    if (person == null)
        return Results.NotFound();

    return Results.Ok(person);
});

app.Run();
