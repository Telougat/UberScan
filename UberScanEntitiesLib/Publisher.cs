using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UberScan.Shared
{
    [Table("Publisher")]
    public partial class Publisher
    {
        public Publisher()
        {
            Mangas = new HashSet<Manga>();
        }

        [Key]
        [Column("publisherID", TypeName = "Int")]
        public long PublisherID { get; set; }
        [Required]
        [Column("publisherName", TypeName = "Varchar (40)")]
        [StringLength(40)]
        public string PublisherName { get; set; }
        [Column("nationality", TypeName = "Varchar (40)")]
        [StringLength(40)]
        public string Nationality { get; set; }
        [Required]
        [Column("creationDate", TypeName = "Date")]
        public DateTime CreationDate { get; set; }
        [Column("headOffice", TypeName = "Varchar (100)")]
        [StringLength(100)]
        public string HeadOffice { get; set; }
        [Column("webSite", TypeName = "Varchar (255)")]
        [StringLength(255)]
        public string WebSite { get; set; }

        [InverseProperty(nameof(Manga.Publisher))]
        public virtual ICollection<Manga> Mangas { get; set; }
    }
}
