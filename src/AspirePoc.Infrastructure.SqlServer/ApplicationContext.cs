using AspirePoc.Core.Entities;
using AspirePoc.Core.Helpers;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Category>().HasData(DefaultEntities.DefaultCategories);
        modelBuilder.Entity<Book>().HasData(DefaultEntities.DefaultBooks);

        base.OnModelCreating(modelBuilder);
    }
}
