using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UberScan.Shared
{
    [Table("FavouriteManga")]
    public partial class FavouriteManga
    {
        public FavouriteManga()
        {
            LinkFavouriteMangas = new HashSet<LinkFavouriteManga>();
        }

        [Key]
        [Column("favouriteMangaID", TypeName = "Int")]
        public long FavouriteMangaID { get; set; }
        [Column("userID", TypeName = "Int")]
        public long UserID { get; set; }

        [InverseProperty(nameof(LinkFavouriteManga.FavouriteManga))]
        public virtual ICollection<LinkFavouriteManga> LinkFavouriteMangas { get; set; }
    }
}
