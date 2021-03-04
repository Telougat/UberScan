using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UberScan.Shared
{
    [Table("mangaLinkFavourite")]
    public partial class MangaLinkFavourite
    {
        [Key]
        [Column("favouriteMangaID")]
        public long FavouriteMangaId { get; set; }
        [Key]
        [Column("mangaID")]
        public long MangaId { get; set; }

        [ForeignKey(nameof(FavouriteMangaId))]
        [InverseProperty("MangaLinkFavourites")]
        public virtual FavouriteManga FavouriteManga { get; set; }
        [ForeignKey(nameof(MangaId))]
        [InverseProperty("MangaLinkFavourites")]
        public virtual Manga Manga { get; set; }
    }
}
