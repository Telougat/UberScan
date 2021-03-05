using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UberScan.Shared
{
    public partial class UberScan : DbContext
    {
        public UberScan()
        {
        }

        public UberScan(DbContextOptions<UberScan> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<FavouriteManga> FavouriteMangas { get; set; }
        public virtual DbSet<FrTranslator> FrTranslators { get; set; }
        public virtual DbSet<LinkFavouriteManga> LinkFavouriteMangas { get; set; }
        public virtual DbSet<Manga> Mangas { get; set; }
        public virtual DbSet<MangaTag> MangaTags { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Volume> Volumes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=../UberScan/UberScan.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorID).ValueGeneratedNever();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryID).ValueGeneratedNever();
            });

            modelBuilder.Entity<FavouriteManga>(entity =>
            {
                entity.Property(e => e.FavouriteMangaID).ValueGeneratedNever();
            });

            modelBuilder.Entity<FrTranslator>(entity =>
            {
                entity.Property(e => e.TranlatorID).ValueGeneratedNever();
            });

            modelBuilder.Entity<LinkFavouriteManga>(entity =>
            {
                entity.HasKey(e => new { e.FavouriteMangaID, e.MangaID });

                entity.HasOne(d => d.FavouriteManga)
                    .WithMany(p => p.LinkFavouriteMangas)
                    .HasForeignKey(d => d.FavouriteMangaID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Manga)
                    .WithMany(p => p.LinkFavouriteMangas)
                    .HasForeignKey(d => d.MangaID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Manga>(entity =>
            {
                entity.Property(e => e.MangaID).ValueGeneratedNever();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Mangas)
                    .HasForeignKey(d => d.AuthorID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Mangas)
                    .HasForeignKey(d => d.CategoryID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Mangas)
                    .HasForeignKey(d => d.PublisherID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tranlator)
                    .WithMany(p => p.Mangas)
                    .HasForeignKey(d => d.TranlatorID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MangaTag>(entity =>
            {
                entity.HasKey(e => new { e.MangaID, e.TagID });

                entity.HasOne(d => d.Manga)
                    .WithMany(p => p.MangaTags)
                    .HasForeignKey(d => d.MangaID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.MangaTags)
                    .HasForeignKey(d => d.TagID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.PublisherID).ValueGeneratedNever();
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TagID).ValueGeneratedNever();
            });

            modelBuilder.Entity<Volume>(entity =>
            {
                entity.Property(e => e.VolumeId).ValueGeneratedNever();

                entity.HasOne(d => d.Manga)
                    .WithMany(p => p.Volumes)
                    .HasForeignKey(d => d.MangaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
