using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace TodoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<ToDo> ToDos => Set<ToDo>();

    }
}