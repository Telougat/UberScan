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
        [Column("publisherID")]
        public long PublisherId { get; set; }
        [Required]
        [Column("publisherName")]
        public string PublisherName { get; set; }
        [Required]
        [Column("nationality")]
        public string Nationality { get; set; }
        [Required]
        [Column("creationDate", TypeName = "NUMERIC")]
        public byte[] CreationDate { get; set; }
        [Required]
        [Column("headOffice")]
        public string HeadOffice { get; set; }
        [Required]
        [Column("webSite")]
        public string WebSite { get; set; }

        [InverseProperty(nameof(Manga.Publisher))]
        public virtual ICollection<Manga> Mangas { get; set; }
    }
}
