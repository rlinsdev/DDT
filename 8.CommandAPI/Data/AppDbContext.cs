using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Command> commands => Set<Command>();

    }
}