using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UberScan.Shared
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Mangas = new HashSet<Manga>();
        }

        [Key]
        [Column("categoryID", TypeName = "Int")]
        public long CategoryID { get; set; }
        [Required]
        [Column("categoryLabel", TypeName = "Varchar (40)")]
        [StringLength(40)]
        public string CategoryLabel { get; set; }
        [Required]
        [Column("categoryDescription", TypeName = "Longtext")]
        public string CategoryDescription { get; set; }

        [InverseProperty(nameof(Manga.Category))]
        public virtual ICollection<Manga> Mangas { get; set; }
    }
}
