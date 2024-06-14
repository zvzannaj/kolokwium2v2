using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Items> Items { get; set; }
    public DbSet<Titles> Titles { get; set; }
    public DbSet<CharactersTitles> CharactersTitles { get; set; }
    public DbSet<Characters?> Characters { get; set; }
    public DbSet<Backpacks> Backpacks { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<CharactersTitles>().HasData(new List<CharactersTitles>
            {
                new CharactersTitles {
                    CharacterId = 1,
                    TitleId = 1,
                    AcquiredAt = DateTime.Parse("2024-05-28")
                },
                new CharactersTitles {
                    CharacterId = 2,
                    TitleId = 2,
                    AcquiredAt = DateTime.Parse("2024-05-29")
                },
            });

            modelBuilder.Entity<Titles>().HasData(new List<Titles>
            {
                new Titles {
                    Id = 1,
                    Name = "Bbcsdugckdsfuc"
                },
                new Titles {
                    Id = 2,
                    Name = "Bbcsduhbckfhfsda"
                },
            });

            modelBuilder.Entity<Items>().HasData(new List<Items>
            {
                new Items
                {
                    Id = 1,
                    Name = "Książka",
                    Weight = 10
                },
                new Items
                {
                    Id = 2,
                    Name = "Woda",
                    Weight = 2
                },
                new Items
                {
                    Id = 3,
                    Name = "Kanapka",
                    Weight = 1
                },
            });

            modelBuilder.Entity<Characters>().HasData(new List<Characters>
            {
                new Characters
                {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    CurrentWeight = 80,
                    MaxWeight = 90,
                },
                new Characters
                {
                    Id = 2,
                    FirstName = "Marcin",
                    LastName = "Bąk",
                    CurrentWeight = 100,
                    MaxWeight = 110,
                },
                new Characters
                {
                    Id = 3,
                    FirstName = "Aleksandra",
                    LastName = "Sowa",
                    CurrentWeight = 50,
                    MaxWeight = 60,
                }
            });

            modelBuilder.Entity<Backpacks>().HasData(new List<Backpacks>
            {
                new Backpacks
                {
                    CharacterId = 1,
                    ItemId = 1,
                    Amount = 3,
                },
                new Backpacks
                {
                    CharacterId = 1,
                    ItemId = 3,
                    Amount = 4,
                },
                new Backpacks
                {
                    CharacterId = 2,
                    ItemId = 2,
                    Amount = 2
                },
                new Backpacks
                {
                    CharacterId = 2,
                    ItemId = 1,
                    Amount = 12
                }
            });
    }
}
