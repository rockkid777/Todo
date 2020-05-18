using Microsoft.EntityFrameworkCore;

namespace Todo.Models {
  public class TodoDbContext : DbContext {
    public TodoDbContext (DbContextOptions<TodoDbContext> options)
      : base(options)
    {
    }

    public DbSet<TodoItem> TodoItem { get; set; }
  }
}
