using CV.Infrastructure.Entities;
using CV.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CV.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Film> Films { get; set; }

        public DbSet<Screenshot> Screenshots { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<FilmGenre> FilmGenres { get; set; }

        public DbSet<FilmActor> FilmActors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            SQLitePCL.Batteries_V2.Init();

            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmGenre>()
             .HasKey(fg => new { fg.FilmId, fg.GenreId });

            modelBuilder.Entity<FilmGenre>()
                .HasOne(fg => fg.Film)
                .WithMany(f => f.FilmGenres)
                .HasForeignKey(fg => fg.FilmId);

            modelBuilder.Entity<FilmGenre>()
                .HasOne(fg => fg.Genre)
                .WithMany(g => g.FilmGenres)
                .HasForeignKey(fg => fg.GenreId);

            modelBuilder.Entity<Film>()
                .HasMany(sc => sc.Screenshots)
                .WithOne(f => f.Film)
                .HasForeignKey(k => k.FilmId)
                .IsRequired();

            modelBuilder.Entity<Actor>()
                .HasMany(sc => sc.Photos)
                .WithOne(f => f.Actor)
                .HasForeignKey(k => k.ActorId)
                .IsRequired();

            modelBuilder.Entity<FilmActor>()
                .HasKey(fa => new { fa.FilmId, fa.ActorId });

            modelBuilder.Entity<FilmActor>()
                .HasOne(fa => fa.Film)
                .WithMany(f => f.FilmActors)
                .HasForeignKey(fa => fa.FilmId);

            modelBuilder.Entity<FilmActor>()
                .HasOne(fa => fa.Actor)
                .WithMany(a => a.FilmActors)
                .HasForeignKey(fa => fa.ActorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
