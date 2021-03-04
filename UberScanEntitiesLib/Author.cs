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
        [Column("authorID")]
        public long AuthorId { get; set; }
        [Required]
        [Column("authorFirstName")]
        public string AuthorFirstName { get; set; }
        [Required]
        [Column("authorLastName")]
        public string AuthorLastName { get; set; }
        [Required]
        [Column("birthDate", TypeName = "NUMERIC")]
        public byte[] BirthDate { get; set; }
        [Required]
        [Column("nationality")]
        public string Nationality { get; set; }
        [Required]
        [Column("authorDescription")]
        public string AuthorDescription { get; set; }

        [InverseProperty(nameof(Manga.Author))]
        public virtual ICollection<Manga> Mangas { get; set; }
    }
}
