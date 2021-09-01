﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieCharactersWebAPI.Models;

namespace MovieCharactersWebAPI.Migrations
{
    [DbContext(typeof(MovieCharacterDbContext))]
    [Migration("20210901111128_AddDataSeeding")]
    partial class AddDataSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieCharacter", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCharacter");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            MovieId = 1
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 2
                        },
                        new
                        {
                            CharacterId = 1,
                            MovieId = 3
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 3
                        },
                        new
                        {
                            CharacterId = 3,
                            MovieId = 4
                        });
                });

            modelBuilder.Entity("MovieCharactersWebAPI.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PictureUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Captain America",
                            Gender = "Male",
                            Name = "Steve Rogers",
                            PictureUrl = "https://www.imdb.com/title/tt0458339/mediaviewer/rm2508504832/"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Iron man",
                            Gender = "Male",
                            Name = "Tony Stark",
                            PictureUrl = "https://www.imdb.com/title/tt0371746/mediaviewer/rm286559232/"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Batman",
                            Gender = "Male",
                            Name = "Bruce Wayne",
                            PictureUrl = ""
                        });
                });

            modelBuilder.Entity("MovieCharactersWebAPI.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Franchise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "DC Comics, Inc. is an American comic book publisher and the flagship unit of DC Entertainment, a subsidiary of the Warner Bros. Global Brands and Experiences division of Warner Bros., which itself is a subsidiary of AT&T's WarnerMedia through its Studios & Networks division.",
                            Name = "DC"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Marvel Comics is the brand name and primary imprint of Marvel Worldwide Inc., formerly Marvel Publishing, Inc. and Marvel Comics Group, a publisher of American comic books and related media. In 2009, The Walt Disney Company acquired Marvel Entertainment, Marvel Worldwide's parent company.",
                            Name = "Marvel"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The Walt Disney Company, commonly known as Disney, is an American diversified multinational mass media and entertainment conglomerate headquartered at the Walt Disney Studios complex in Burbank, California.",
                            Name = "Disney"
                        });
                });

            modelBuilder.Entity("MovieCharactersWebAPI.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PictureUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrailerUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FranchiseId = 2,
                            Genre = "Action",
                            PictureUrl = "https://www.imdb.com/title/tt0458339/mediaviewer/rm2438905344/",
                            ReleaseYear = 2011,
                            Title = "Captain America",
                            TrailerUrl = "https://www.imdb.com/video/vi2912787481/?ref_=tt_vi_i_1"
                        },
                        new
                        {
                            Id = 2,
                            FranchiseId = 2,
                            Genre = "Action",
                            PictureUrl = "https://www.imdb.com/title/tt0371746/mediaviewer/rm1544850432/",
                            ReleaseYear = 2018,
                            Title = "Iron man",
                            TrailerUrl = "https://www.imdb.com/video/vi447873305/?ref_=tt_vi_i_1"
                        },
                        new
                        {
                            Id = 3,
                            FranchiseId = 2,
                            Genre = "Action",
                            PictureUrl = "https://www.imdb.com/title/tt0848228/mediaviewer/rm3955117056/",
                            ReleaseYear = 2012,
                            Title = "The Avengers",
                            TrailerUrl = "https://www.imdb.com/video/vi1891149081/?ref_=tt_vi_i_1"
                        },
                        new
                        {
                            Id = 4,
                            FranchiseId = 1,
                            Genre = "Action",
                            PictureUrl = "",
                            ReleaseYear = 2012,
                            Title = "Batman The Dark Knight"
                        });
                });

            modelBuilder.Entity("MovieCharacter", b =>
                {
                    b.HasOne("MovieCharactersWebAPI.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieCharactersWebAPI.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieCharactersWebAPI.Models.Movie", b =>
                {
                    b.HasOne("MovieCharactersWebAPI.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("MovieCharactersWebAPI.Models.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
