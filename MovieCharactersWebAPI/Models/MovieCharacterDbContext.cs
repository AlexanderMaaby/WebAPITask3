using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharactersWebAPI.Models
{
    public class MovieCharacterDbContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Franchise> Franchise { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = ND-5CG8473X7Q\\SQLEXPRESS01; Initial Catalog = MovieCharacterDB; Integrated Security = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasData(
                new Movie { Id = 1, Title = "", Genre = "", ReleaseYear = 1111, PictureUrl = "", TrailerUrl = "", Franchise = "", Characters = "" });
            modelBuilder.Entity<Movie>()
               .HasData(
               new Movie { Id = 1, Title = "", Genre = "", ReleaseYear = 1111, PictureUrl = "", TrailerUrl = "", Franchise = "", Characters = "" });
            modelBuilder.Entity<Movie>()
               .HasData(
               new Movie { Id = 1, Title = "", Genre = "", ReleaseYear = 1111, PictureUrl = "", TrailerUrl = "", Franchise = "", Characters = "" });

            modelBuilder.Entity<Character>()
               .HasData(
               new Character { Id = 1, Name = "", Alias = "", Gender = 1111, PictureUrl = "", Movies = "");
            modelBuilder.Entity<Character>()
               .HasData(
               new Character { Id = 1, Name = "", Alias = "", Gender = 1111, PictureUrl = "", Movies = "");
            modelBuilder.Entity<Character>()
               .HasData(
               new Character { Id = 1, Name = "", Alias = "", Gender = 1111, PictureUrl = "", Movies = "");

            modelBuilder.Entity<Franchise>()
               .HasData(
               new Franchise { Id = 1, Name = "", Description = "", Movies = 1111 });
            modelBuilder.Entity<Franchise>()
               .HasData(
               new Franchise { Id = 1, Name = "", Description = "", Movies = 1111 });
            modelBuilder.Entity<Franchise>()
               .HasData(
               new Franchise { Id = 1, Name = "", Description = "", Movies = 1111 });


        }
    }
}
