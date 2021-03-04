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
        [Column("categoryID")]
        public long CategoryId { get; set; }
        [Required]
        [Column("categoryLabel")]
        public string CategoryLabel { get; set; }
        [Required]
        [Column("categoryDescription")]
        public string CategoryDescription { get; set; }

        [InverseProperty(nameof(Manga.Category))]
        public virtual ICollection<Manga> Mangas { get; set; }
    }
}
