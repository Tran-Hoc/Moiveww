using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web_xemphim.Data
{
    public partial class MovieContext : DbContext
    {
        public MovieContext()
        {
        }

        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<AdminsAccount> AdminsAccounts { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Keyword> Keywords { get; set; } = null!;
        public virtual DbSet<KeywordMovie> KeywordMovies { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MovieActor> MovieActors { get; set; } = null!;
        public virtual DbSet<MovieGenre> MovieGenres { get; set; } = null!;
        public virtual DbSet<National> Nationals { get; set; } = null!;
        public virtual DbSet<NationalMovie> NationalMovies { get; set; } = null!;
        public virtual DbSet<ReleaseYear> ReleaseYears { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersMovie> UsersMovies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DbMovie");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");

                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.Property(e => e.Checked).HasColumnName("checked");
            });

            modelBuilder.Entity<AdminsAccount>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__AdminsAc__719FE4E8B17E30C7");

                entity.ToTable("AdminsAccount");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Checked).HasColumnName("checked");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("Director");

                entity.Property(e => e.DirectorId).HasColumnName("DirectorID");

                entity.Property(e => e.Checked).HasColumnName("checked");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenresId)
                    .HasName("PK__Genres__1F6A92D47DCAFF7F");

                entity.Property(e => e.GenresId).HasColumnName("GenresID");

                entity.Property(e => e.Checked).HasColumnName("checked");
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.ToTable("Keyword");

                entity.Property(e => e.KeywordId).HasColumnName("KeywordID");

                entity.Property(e => e.Word).HasColumnName("word");
            });

            modelBuilder.Entity<KeywordMovie>(entity =>
            {
                entity.ToTable("KeywordMovie");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KeywordId).HasColumnName("KeywordID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.HasOne(d => d.Keyword)
                    .WithMany(p => p.KeywordMovies)
                    .HasForeignKey(d => d.KeywordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KeywordMo__Keywo__5FB337D6");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.KeywordMovies)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KeywordMo__Movie__60A75C0F");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.Checked).HasColumnName("checked");

                entity.Property(e => e.DirectorId).HasColumnName("DirectorID");

                entity.Property(e => e.KeywordId).HasColumnName("KeywordID");

                entity.Property(e => e.ReleaseYearId).HasColumnName("ReleaseYearID");

                entity.Property(e => e.Views).HasColumnName("views");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MoviesDirector");

                entity.HasOne(d => d.ReleaseYear)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ReleaseYearId)
                    .HasConstraintName("FK_MoviesReleaseYear");
            });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MovieActor");

                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.HasOne(d => d.Actor)
                    .WithMany()
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovieActo__Actor__3F466844");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovieActo__Movie__3E52440B");
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.GenresId).HasColumnName("GenresID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.HasOne(d => d.Genres)
                    .WithMany()
                    .HasForeignKey(d => d.GenresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovieGenr__Genre__4222D4EF");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovieGenr__Movie__412EB0B6");
            });

            modelBuilder.Entity<National>(entity =>
            {
                entity.HasKey(e => e.NationalsId)
                    .HasName("PK__National__20E314B39BC9A1BC");

                entity.Property(e => e.NationalsId).HasColumnName("NationalsID");
            });

            modelBuilder.Entity<NationalMovie>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NationalMovie");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.NationalsId).HasColumnName("NationalsID");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NationalM__Movie__66603565");

                entity.HasOne(d => d.Nationals)
                    .WithMany()
                    .HasForeignKey(d => d.NationalsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NationalM__Natio__656C112C");
            });

            modelBuilder.Entity<ReleaseYear>(entity =>
            {
                entity.ToTable("ReleaseYear");

                entity.Property(e => e.ReleaseYearId).HasColumnName("ReleaseYearID");

                entity.Property(e => e.YearRelease)
                    .HasColumnType("datetime")
                    .HasColumnName("yearRelease");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__Users__A349B042134CA5EA");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.Property(e => e.Checked).HasColumnName("checked");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");
            });

            modelBuilder.Entity<UsersMovie>(entity =>
            {
                entity.ToTable("UsersMovie");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Commment).HasColumnName("commment");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.Property(e => e.Viewingtime).HasColumnName("viewingtime");

                entity.Property(e => e.Vote).HasColumnName("vote");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.UsersMovies)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsersMovi__Movie__45F365D3");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.UsersMovies)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsersMovi__Users__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
