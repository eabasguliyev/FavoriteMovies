﻿// <auto-generated />
using FavoriteMovies.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FavoriteMovies.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FavoriteMovies.Domain.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieAndActor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieAndActors");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieAndCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieAndCountry");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieAndDirector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieAndDirectors");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieAndGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieAndGenres");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieAndLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieAndLanguages");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieAndWriter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("WriterId");

                    b.ToTable("MovieAndWriters");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImdbId")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Plot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterLink")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieAndActor", b =>
                {
                    b.HasOne("FavoriteMovies.Domain.Models.Person", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FavoriteMovies.Domain.Models.MovieDetail", "Movie")
                        .WithMany("Actors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieAndCountry", b =>
                {
                    b.HasOne("FavoriteMovies.Domain.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FavoriteMovies.Domain.Models.MovieDetail", "Movie")
                        .WithMany("Countries")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieAndDirector", b =>
                {
                    b.HasOne("FavoriteMovies.Domain.Models.Person", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FavoriteMovies.Domain.Models.MovieDetail", "Movie")
                        .WithMany("Directors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieAndGenre", b =>
                {
                    b.HasOne("FavoriteMovies.Domain.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FavoriteMovies.Domain.Models.MovieDetail", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieAndLanguage", b =>
                {
                    b.HasOne("FavoriteMovies.Domain.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FavoriteMovies.Domain.Models.MovieDetail", "Movie")
                        .WithMany("Languages")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieAndWriter", b =>
                {
                    b.HasOne("FavoriteMovies.Domain.Models.MovieDetail", "Movie")
                        .WithMany("Writers")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FavoriteMovies.Domain.Models.Person", "Writer")
                        .WithMany()
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("FavoriteMovies.Domain.Models.MovieDetail", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("Countries");

                    b.Navigation("Directors");

                    b.Navigation("Genres");

                    b.Navigation("Languages");

                    b.Navigation("Writers");
                });
#pragma warning restore 612, 618
        }
    }
}
