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
            MangaLinkFavourites = new HashSet<MangaLinkFavourite>();
            MangaTags = new HashSet<MangaTag>();
            Volumes = new HashSet<Volume>();
        }

        [Key]
        [Column("mangaID")]
        public long MangaId { get; set; }
        [Required]
        [Column("mangaNameLat")]
        public string MangaNameLat { get; set; }
        [Required]
        [Column("mangaNameJap")]
        public string MangaNameJap { get; set; }
        [Required]
        [Column("mangaSynopsis")]
        public string MangaSynopsis { get; set; }
        [Required]
        [Column("publicationDate", TypeName = "NUMERIC")]
        public byte[] PublicationDate { get; set; }
        [Column("uberScanNote")]
        public long UberScanNote { get; set; }
        [Required]
        [Column("status")]
        public string Status { get; set; }
        [Column("publisherID")]
        public long PublisherId { get; set; }
        [Column("authorID")]
        public long AuthorId { get; set; }
        [Column("tranlatorID")]
        public long TranlatorId { get; set; }
        [Column("categoryID")]
        public long CategoryId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        [InverseProperty("Mangas")]
        public virtual Author Author { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Mangas")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(PublisherId))]
        [InverseProperty("Mangas")]
        public virtual Publisher Publisher { get; set; }
        [ForeignKey(nameof(TranlatorId))]
        [InverseProperty(nameof(FrTranslator.Mangas))]
        public virtual FrTranslator Tranlator { get; set; }
        [InverseProperty(nameof(MangaLinkFavourite.Manga))]
        public virtual ICollection<MangaLinkFavourite> MangaLinkFavourites { get; set; }
        [InverseProperty(nameof(MangaTag.Manga))]
        public virtual ICollection<MangaTag> MangaTags { get; set; }
        [InverseProperty(nameof(Volume.Manga))]
        public virtual ICollection<Volume> Volumes { get; set; }
    }
}
