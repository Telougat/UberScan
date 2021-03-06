﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UberScan.Shared
{
    public partial class MangaTag
    {
        [Key]
        [Column("mangaID", TypeName = "Int")]
        public long MangaID { get; set; }
        [Key]
        [Column("tagID", TypeName = "Int")]
        public long TagID { get; set; }

        [ForeignKey(nameof(MangaID))]
        [InverseProperty("MangaTags")]
        public virtual Manga Manga { get; set; }
        [ForeignKey(nameof(TagID))]
        [InverseProperty("MangaTags")]
        public virtual Tag Tag { get; set; }
    }
}
