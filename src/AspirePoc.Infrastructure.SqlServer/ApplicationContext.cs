using AspirePoc.Core.Entities;
using AspirePoc.Core.Helpers;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookReadModel> BooksReadModel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Book>(x =>
        {
            x.HasIndex(c => c.Guid).IsUnique();
        });
        
        modelBuilder.Entity<BookReadModel>(entity =>
        {
            entity.ToTable("Books_Read");

            entity.HasKey(e => e.Guid);

            entity.HasIndex(e => e.Id)
                .IsUnique();

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.Description)
                .IsRequired();

            entity.Property(e => e.SerializedObject)
                .IsRequired();

        });

        modelBuilder.Entity<Book>().HasData(DefaultEntities.DefaultBooks);
        //modelBuilder.Entity<BookReadModel>().HasData(DefaultEntities.DefaultBooks);
        modelBuilder.Entity<Category>().HasData(DefaultEntities.DefaultCategories);

        base.OnModelCreating(modelBuilder);
    }
}
