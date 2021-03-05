using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UberScan.Shared
{
    [Table("Author")]
    public partial class Author
    {
        public Author()
        {
            Mangas = new HashSet<Manga>();
        }

        [Key]
        [Column("authorID", TypeName = "Int")]
        public long AuthorID { get; set; }
        [Required]
        [Column("authorFirstName", TypeName = "Varchar (40)")]
        [StringLength(40)]
        public string AuthorFirstName { get; set; }
        [Required]
        [Column("authorLastName", TypeName = "Varchar (40)")]
        [StringLength(40)]
        public string AuthorLastName { get; set; }
        [Required]
        [Column("birthDate", TypeName = "Date")]
        public DateTime? BirthDate { get; set; }
        [Column("nationality", TypeName = "Varchar (40)")]
        [StringLength(40)]
        public string Nationality { get; set; }
        [Column("authorDescription", TypeName = "Longtext")]
        public string AuthorDescription { get; set; }

        [InverseProperty(nameof(Manga.Author))]
        public virtual ICollection<Manga> Mangas { get; set; }
    }
}
