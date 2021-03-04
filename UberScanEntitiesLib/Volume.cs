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
        [Column("volumeID")]
        public long VolumeId { get; set; }
        [Column("volumeNum")]
        public long VolumeNum { get; set; }
        [Required]
        [Column("volumeSynopsis")]
        public string VolumeSynopsis { get; set; }
        [Required]
        [Column("publicationDate", TypeName = "NUMERIC")]
        public byte[] PublicationDate { get; set; }
        [Required]
        [Column("linkVolume")]
        public string LinkVolume { get; set; }
        [Column("numberConsult")]
        public long NumberConsult { get; set; }
        [Column("mangaID")]
        public long MangaId { get; set; }

        [ForeignKey(nameof(MangaId))]
        [InverseProperty("Volumes")]
        public virtual Manga Manga { get; set; }
    }
}
