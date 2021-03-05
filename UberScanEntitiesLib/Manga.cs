using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UberScan.Shared
{
    [Table("Manga")]
    public partial class Manga
    {
        public Manga()
        {
            LinkFavouriteMangas = new HashSet<LinkFavouriteManga>();
            MangaTags = new HashSet<MangaTag>();
            Volumes = new HashSet<Volume>();
        }

        [Key]
        [Column("mangaID", TypeName = "Int")]
        public long MangaID { get; set; }
        [Column("mangaNameLat", TypeName = "Varchar (255)")]
        [StringLength(255)]
        public string MangaNameLat { get; set; }
        [Column("mangaNameJap", TypeName = "Varchar (255)")]
        [StringLength(255)]
        public string MangaNameJap { get; set; }
        [Column("mangaSynopsis", TypeName = "Longtext")]
        public string MangaSynopsis { get; set; }
        [Required]
        [Column("publicationDate", TypeName = "Date")]
        public DateTime? PublicationDate { get; set; }
        [Column("uberScanNote", TypeName = "Int")]
        public long UberScanNote { get; set; }
        [Column("status", TypeName = "Varchar (20)")]
        [StringLength(20)]
        public string Status { get; set; }
        [Column("linkImageManga", TypeName = "Longtext")]
        public string LinkImageManga { get; set; }
        [Column("publisherID", TypeName = "Int")]
        public long PublisherID { get; set; }
        [Column("authorID", TypeName = "Int")]
        public long AuthorID { get; set; }
        [Column("tranlatorID", TypeName = "Int")]
        public long TranlatorID { get; set; }
        [Column("categoryID", TypeName = "Int")]
        public long CategoryID { get; set; }

        [ForeignKey(nameof(AuthorID))]
        [InverseProperty("Mangas")]
        public virtual Author Author { get; set; }
        [ForeignKey(nameof(CategoryID))]
        [InverseProperty("Mangas")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(PublisherID))]
        [InverseProperty("Mangas")]
        public virtual Publisher Publisher { get; set; }
        [ForeignKey(nameof(TranlatorID))]
        [InverseProperty(nameof(FrTranslator.Mangas))]
        public virtual FrTranslator Tranlator { get; set; }
        [InverseProperty(nameof(LinkFavouriteManga.Manga))]
        public virtual ICollection<LinkFavouriteManga> LinkFavouriteMangas { get; set; }
        [InverseProperty(nameof(MangaTag.Manga))]
        public virtual ICollection<MangaTag> MangaTags { get; set; }
        [InverseProperty(nameof(Volume.Manga))]
        public virtual ICollection<Volume> Volumes { get; set; }
    }
}
