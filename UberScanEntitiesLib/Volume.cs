using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UberScan.Shared
{
    [Table("Volume")]
    public partial class Volume
    {
        [Key]
        [Column("volumeID", TypeName = "Int")]
        public long VolumeId { get; set; }
        [Column("volumeNum", TypeName = "Int")]
        public long VolumeNum { get; set; }
        [Column("volumeSynopsis", TypeName = "Longtext")]
        public string VolumeSynopsis { get; set; }
        [Required]
        [Column("publicationDate", TypeName = "Date")]
        public byte[] PublicationDate { get; set; }
        [Column("linkVolume", TypeName = "Varchar (255)")]
        public string LinkVolume { get; set; }
        [Column("numberConsult", TypeName = "Int")]
        public long? NumberConsult { get; set; }
        [Column("linkImageVolume", TypeName = "Varchar (255)")]
        public string LinkImageVolume { get; set; }
        [Column("mangaID", TypeName = "Int")]
        public long MangaId { get; set; }

        [ForeignKey(nameof(MangaId))]
        [InverseProperty("Volumes")]
        public virtual Manga Manga { get; set; }
    }
}
