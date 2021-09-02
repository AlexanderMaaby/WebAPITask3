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

        //Configure the service passing objects
        public MovieCharacterDbContext(DbContextOptions options) :base(options)
        { 
        }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Data Source = ND-5CG8473X7Q\\SQLEXPRESS01; Initial Catalog = MovieCharacterDB; Integrated Security = True;");
        //}

        //seeding the data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasData(
                new Movie { Id = 1, Title = "Captain America", Genre = "Action", ReleaseYear = 2011, PictureUrl = "https://www.imdb.com/title/tt0458339/mediaviewer/rm2438905344/", TrailerUrl = "https://www.imdb.com/video/vi2912787481/?ref_=tt_vi_i_1",FranchiseId = 2 });
            modelBuilder.Entity<Movie>()
               .HasData(
               new Movie { Id = 2, Title = "Iron man", Genre = "Action", ReleaseYear = 2018, PictureUrl = "https://www.imdb.com/title/tt0371746/mediaviewer/rm1544850432/", TrailerUrl = "https://www.imdb.com/video/vi447873305/?ref_=tt_vi_i_1", FranchiseId = 2});
            modelBuilder.Entity<Movie>()
               .HasData(
               new Movie { Id = 3, Title = "The Avengers", Genre = "Action", ReleaseYear = 2012, PictureUrl = "https://www.imdb.com/title/tt0848228/mediaviewer/rm3955117056/", TrailerUrl = "https://www.imdb.com/video/vi1891149081/?ref_=tt_vi_i_1", FranchiseId = 2});
            modelBuilder.Entity<Movie>()
              .HasData(
              new Movie { Id = 4, Title = "Batman The Dark Knight", Genre = "Action", ReleaseYear = 2012, PictureUrl = "", FranchiseId = 1 });




            modelBuilder.Entity<Character>()
               .HasData(
               new Character { Id = 1, Name = "Steve Rogers", Alias = "Captain America", Gender = "Male", PictureUrl = "https://www.imdb.com/title/tt0458339/mediaviewer/rm2508504832/"});
            modelBuilder.Entity<Character>()
               .HasData(
               new Character { Id = 2, Name = "Tony Stark", Alias = "Iron man", Gender = "Male", PictureUrl = "https://www.imdb.com/title/tt0371746/mediaviewer/rm286559232/" });
            modelBuilder.Entity<Character>()
               .HasData(
               new Character { Id = 3, Name = "Bruce Wayne", Alias = "Batman", Gender = "Male", PictureUrl = "" });

            modelBuilder.Entity<Franchise>()
               .HasData(
               new Franchise { Id = 1, Name = "DC", Description = "DC Comics, Inc. is an American comic book publisher and the flagship unit of DC Entertainment, a subsidiary of the Warner Bros. Global Brands and Experiences division of Warner Bros., which itself is a subsidiary of AT&T's WarnerMedia through its Studios & Networks division."});
            modelBuilder.Entity<Franchise>()
               .HasData(
               new Franchise { Id = 2, Name = "Marvel", Description = "Marvel Comics is the brand name and primary imprint of Marvel Worldwide Inc., formerly Marvel Publishing, Inc. and Marvel Comics Group, a publisher of American comic books and related media. In 2009, The Walt Disney Company acquired Marvel Entertainment, Marvel Worldwide's parent company."});
            modelBuilder.Entity<Franchise>()
               .HasData(
               new Franchise { Id = 3, Name = "Disney", Description = "The Walt Disney Company, commonly known as Disney, is an American diversified multinational mass media and entertainment conglomerate headquartered at the Walt Disney Studios complex in Burbank, California."});

            
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Characters)
                .WithMany(c => c.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieCharacter",
                    r => r.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    je =>
                    {
                        je.HasKey("CharacterId", "MovieId");
                        je.HasData(
                            new { MovieId = 1, CharacterId = 1 },
                            new { MovieId = 2, CharacterId = 2 },
                            new { MovieId = 3, CharacterId = 1 },
                            new { MovieId = 3, CharacterId = 2 },
                            new { MovieId = 4, CharacterId = 3 }
                        );
                    });



        }
    }
}
