using Microsoft.EntityFrameworkCore;
using TodoCRUD.Models;

namespace TodoCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>(entity =>
            {
                entity.ToTable("todo");
                entity.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("id");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.type)
                .IsRequired()
                .HasColumnName("type");

            });
        }
    }
}
