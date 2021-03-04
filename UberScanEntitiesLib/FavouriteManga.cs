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
            MangaLinkFavourites = new HashSet<MangaLinkFavourite>();
        }

        [Key]
        [Column("favouriteMangaID")]
        public long FavouriteMangaId { get; set; }
        [Column("userID")]
        public long UserId { get; set; }

        [InverseProperty(nameof(MangaLinkFavourite.FavouriteManga))]
        public virtual ICollection<MangaLinkFavourite> MangaLinkFavourites { get; set; }
    }
}
