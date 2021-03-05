using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UberScan.Shared
{
    [Table("linkFavouriteManga")]
    public partial class LinkFavouriteManga
    {
        [Key]
        [Column("favouriteMangaID", TypeName = "Int")]
        public long FavouriteMangaID { get; set; }
        [Key]
        [Column("mangaID", TypeName = "Int")]
        public long MangaID { get; set; }

        [ForeignKey(nameof(FavouriteMangaID))]
        [InverseProperty("LinkFavouriteMangas")]
        public virtual FavouriteManga FavouriteManga { get; set; }
        [ForeignKey(nameof(MangaID))]
        [InverseProperty("LinkFavouriteMangas")]
        public virtual Manga Manga { get; set; }
    }
}
