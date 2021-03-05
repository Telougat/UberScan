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
        [Column("tagID", TypeName = "Int")]
        public long TagID { get; set; }
        [Required]
        [Column("tagLabel", TypeName = "Varchar (40)")]
        [StringLength(40)]
        public string TagLabel { get; set; }
        [Required]
        [Column("tagDescription", TypeName = "Varchar (255)")]
        [StringLength(255)]
        public string TagDescription { get; set; }

        [InverseProperty(nameof(MangaTag.Tag))]
        public virtual ICollection<MangaTag> MangaTags { get; set; }
    }
}
