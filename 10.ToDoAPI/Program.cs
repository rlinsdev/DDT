using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using ToDoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ToDoDB"));
builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLCon")));

var app = builder.Build();

app.MapGet("api/todo", async (AppDbContext context) => {
    var items = await context.ToDos.ToListAsync();

    return Results.Ok(items);
});

app.MapPost("api/todo", async (AppDbContext context, ToDo toDo) => {

    // TODO: Validate object here!
    await context.ToDos.AddAsync(toDo);
    await context.SaveChangesAsync();
    return Results.Created($"api/todo/{toDo.Id}", toDo);
});

using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
        Console.WriteLine("DataBase migrated successfully");

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Could not migrate DB: "ex.Message);
    }
}

app.Run();

