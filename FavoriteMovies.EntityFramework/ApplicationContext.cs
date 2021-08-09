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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", false)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FavoriteMovies"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Person>().Property(p => p.Name).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Genre>().Property(g => g.Name).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<Language>().ToTable("Languages");
            modelBuilder.Entity<Language>().Property(l => l.Name).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Country>().Property(c => c.Name).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<MovieDetail>().Property(m => m.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<MovieDetail>().Property(m => m.ImdbId).HasMaxLength(255);
            modelBuilder.Entity<MovieDetail>().Property(m => m.PosterLink).HasMaxLength(255);
            modelBuilder.Entity<MovieDetail>().Property(m => m.CountryId).IsRequired();
            modelBuilder.Entity<MovieDetail>().Property(m => m.DirectorId).IsRequired();
            modelBuilder.Entity<MovieDetail>().Property(m => m.LanguageId).IsRequired();

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
