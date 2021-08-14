using System;
using System.IO;
using FavoriteMovies.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FavoriteMovies.EntityFramework
{
    public class ApplicationContext:DbContext
    {
        public DbSet<MovieDetail> Movies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MovieAndActor> MovieAndActors { get; set; }
        public DbSet<MovieAndGenre> MovieAndGenres { get; set; }
        public DbSet<MovieAndWriter> MovieAndWriters { get; set; }
        public DbSet<MovieAndLanguage> MovieAndLanguages { get; set; }
        public DbSet<MovieAndDirector> MovieAndDirectors { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", false)
                .Build();

            optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("FavoriteMovies"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<Person>().Property(p => p.Name).HasMaxLength(255).IsRequired();

            //modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Genre>().Property(g => g.Name).HasMaxLength(255).IsRequired();

            //modelBuilder.Entity<Language>().ToTable("Languages");
            modelBuilder.Entity<Language>().Property(l => l.Name).HasMaxLength(255).IsRequired();

            //modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Country>().Property(c => c.Name).HasMaxLength(255).IsRequired();

            //modelBuilder.Entity<MovieDetail>().ToTable("Movies");
            modelBuilder.Entity<MovieDetail>().Property(m => m.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<MovieDetail>().Property(m => m.ImdbId).HasMaxLength(255);
            modelBuilder.Entity<MovieDetail>().Property(m => m.PosterLink).HasMaxLength(255);
            modelBuilder.Entity<MovieDetail>().Property(m => m.CountryId).IsRequired();
            

            modelBuilder.Entity<MovieAndActor>().Property(ma => ma.MovieId).IsRequired();
            modelBuilder.Entity<MovieAndActor>().Property(ma => ma.ActorId).IsRequired();
            modelBuilder.Entity<MovieAndActor>().HasOne(ma => ma.Movie).WithMany(md => md.Actors)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MovieAndGenre>().Property(mg => mg.MovieId).IsRequired();
            modelBuilder.Entity<MovieAndGenre>().Property(mg => mg.GenreId).IsRequired();

            modelBuilder.Entity<MovieAndWriter>().Property(mw => mw.MovieId).IsRequired();
            modelBuilder.Entity<MovieAndWriter>().Property(mw => mw.WriterId).IsRequired();
            modelBuilder.Entity<MovieAndWriter>().HasOne(mw => mw.Movie).WithMany(md => md.Writers)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MovieAndDirector>().Property(md => md.MovieId).IsRequired();
            modelBuilder.Entity<MovieAndDirector>().Property(md => md.DirectorId).IsRequired();

            modelBuilder.Entity<MovieAndDirector>().HasOne(md => md.Movie).WithMany(md => md.Directors)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MovieAndLanguage>().Property(ml => ml.MovieId).IsRequired();
            modelBuilder.Entity<MovieAndLanguage>().Property(ml => ml.LanguageId).IsRequired();

            modelBuilder.Entity<MovieAndCountry>().Property(ml => ml.MovieId).IsRequired();
            modelBuilder.Entity<MovieAndCountry>().Property(ml => ml.CountryId).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
