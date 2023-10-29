using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulity> Difficulities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Difficulity>();

            //Seed data for Difficulty

            var difficulties = new List<Difficulity>()
            {
                new Difficulity()
                {
                    Id= Guid.Parse("6ca6a6d9-7bc9-428c-88f0-b50a6bd1a2da"),
                    Name = "Easy",

                },
                new Difficulity()
                {
                    Id= Guid.Parse("5055e124-4c80-4b55-8832-222fc2c3598d"),
                    Name = "Medium",

                },
                new Difficulity()
                {
                    Id= Guid.Parse("b1b4d2ed-6392-4324-a8bd-6afb90608b47"),
                    Name = "Hard",

                }
            };


            // Seed difficulties database
            modelBuilder.Entity<Difficulity>().HasData(difficulties);


            // Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("fee94f55-b115-40fd-a044-b2d1efb41d5b"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "Image-Url"
                },
                new Region
                {
                    Id = Guid.Parse("07845a01-4bd5-401c-b682-8accf5febae9"),
                    Name = "Southland",
                    Code = "AKL",
                    RegionImageUrl = "Image-Url"
                },
                

            };

            modelBuilder.Entity<Region>().HasData(regions);
        }


    }
}
