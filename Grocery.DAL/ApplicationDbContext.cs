using Grocery.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Grocery.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        
        public DbSet<Item> Item { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(builder =>
            {
                builder.ToTable("Item").HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                //builder.Property(x => x.Price).HasColumnType("int");
            });

            

            modelBuilder.Entity<User>(builder => 
            {
                builder.HasData(new User()
                {
                    Id = 1,
                    Name = "San_Okk",
                    Password = "12345",
                    Role = Domain.Enum.Role.Admin
                }) ;
                builder.ToTable("Users").HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

                builder.Property(x => x.Password).IsRequired().HasMaxLength(30);
            
            });
        }

    }
}