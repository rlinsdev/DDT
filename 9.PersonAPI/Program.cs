using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonAPI.Data;
using PersonAPI.Dtos;
using PersonAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlDbConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Get all
app.MapGet("api/v1/people", async (AppDbContext context, IMapper mapper) => {
    var people = await context.People.ToListAsync();

    return Results.Ok(mapper.Map<IEnumerable<PersonReadDto>>(people));
});

// Get Single
app.MapGet("api/v1/people/{id}", async (AppDbContext context, int id, IMapper mapper) => {
    var personModel = await context.People.FindAsync(id);

    if (personModel == null)
        return Results.NotFound();

    var personDto = mapper.Map<PersonReadDto>(personModel);

    // var personDto = new PersonDto {
    //     Id = personModel.Id,
    //     FullName = personModel.FullName,
    //     Telephone = personModel.Telephone
    // };

    return Results.Ok(personDto);
});

// Create
app.MapPost("api/v1/people", async (AppDbContext context, PersonCreateDto personCreateDto, IMapper mapper) => {

    // Map PersonModelDto to PersonModel
    var personModel = mapper.Map<Person>(personCreateDto);

    await context.People.AddAsync(personModel);
    await context.SaveChangesAsync();

    return Results.Created($"/api/v1/people/{personModel.Id}", mapper.Map<PersonReadDto>(personModel));
});

// Update
app.MapPut("api/v1/people/{Id}", async (AppDbContext context, int id, Person person) => {
    var personModel = await context.People.FindAsync(id);

    if (personModel == null)
        return Results.NotFound();

    personModel.FullName = person.FullName;
    personModel.Telephone = person.Telephone;
    personModel.DoB = person.DoB;

    await context.SaveChangesAsync();
    return Results.NoContent();
});

// delete
app.MapDelete("api/v1/people/{id}",  async (AppDbContext context, int id) => {
    var personModel = await context.People.FindAsync(id);

    if (personModel == null)
        return Results.NotFound();

    context.People.Remove(personModel);

    await context.SaveChangesAsync();

    // Best practices return a register removed
    return Results.Ok(personModel);
});

app.Run();
