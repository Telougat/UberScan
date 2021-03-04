using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UberScan.Shared
{
    [Table("Tag")]
    public partial class Tag
    {
        public Tag()
        {
            MangaTags = new HashSet<MangaTag>();
        }

        [Key]
        [Column("tagID")]
        public long TagId { get; set; }
        [Required]
        [Column("tagLabel")]
        public string TagLabel { get; set; }
        [Required]
        [Column("tagDescription")]
        public string TagDescription { get; set; }

        [InverseProperty(nameof(MangaTag.Tag))]
        public virtual ICollection<MangaTag> MangaTags { get; set; }
    }
}
