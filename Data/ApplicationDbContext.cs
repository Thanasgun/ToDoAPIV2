using Microsoft.EntityFrameworkCore;
using ToDoAPIV2.Models;

namespace ToDoAPIV2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ToDo> ToDo { get; set; }
    }
}
