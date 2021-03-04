using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UberScan.Shared
{
    [Table("mangaTags")]
    public partial class MangaTag
    {
        [Key]
        [Column("mangaID")]
        public long MangaId { get; set; }
        [Key]
        [Column("tagID")]
        public long TagId { get; set; }

        [ForeignKey(nameof(MangaId))]
        [InverseProperty("MangaTags")]
        public virtual Manga Manga { get; set; }
        [ForeignKey(nameof(TagId))]
        [InverseProperty("MangaTags")]
        public virtual Tag Tag { get; set; }
    }
}
