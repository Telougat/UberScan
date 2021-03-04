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
        public virtual DbSet<Manga> Mangas { get; set; }
        public virtual DbSet<MangaLinkFavourite> MangaLinkFavourites { get; set; }
        public virtual DbSet<MangaTag> MangaTags { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Volume> Volumes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=../UberScan.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();
            });

            modelBuilder.Entity<FavouriteManga>(entity =>
            {
                entity.Property(e => e.FavouriteMangaId).ValueGeneratedNever();
            });

            modelBuilder.Entity<FrTranslator>(entity =>
            {
                entity.Property(e => e.TranlatorId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Manga>(entity =>
            {
                entity.Property(e => e.MangaId).ValueGeneratedNever();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Mangas)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Mangas)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Mangas)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tranlator)
                    .WithMany(p => p.Mangas)
                    .HasForeignKey(d => d.TranlatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MangaLinkFavourite>(entity =>
            {
                entity.HasKey(e => new { e.FavouriteMangaId, e.MangaId });

                entity.HasOne(d => d.FavouriteManga)
                    .WithMany(p => p.MangaLinkFavourites)
                    .HasForeignKey(d => d.FavouriteMangaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Manga)
                    .WithMany(p => p.MangaLinkFavourites)
                    .HasForeignKey(d => d.MangaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MangaTag>(entity =>
            {
                entity.HasKey(e => new { e.MangaId, e.TagId });

                entity.HasOne(d => d.Manga)
                    .WithMany(p => p.MangaTags)
                    .HasForeignKey(d => d.MangaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.MangaTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.PublisherId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TagId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Volume>(entity =>
            {
                entity.Property(e => e.VolumeId).ValueGeneratedNever();

                entity.HasOne(d => d.Manga)
                    .WithMany(p => p.Volumes)
                    .HasForeignKey(d => d.MangaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });*/

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
