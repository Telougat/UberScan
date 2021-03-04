using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UberScan.Shared
{
    [Table("FrTranslator")]
    public partial class FrTranslator
    {
        public FrTranslator()
        {
            Mangas = new HashSet<Manga>();
        }

        [Key]
        [Column("tranlatorID")]
        public long TranlatorId { get; set; }
        [Required]
        [Column("translatorName")]
        public string TranslatorName { get; set; }

        [InverseProperty(nameof(Manga.Tranlator))]
        public virtual ICollection<Manga> Mangas { get; set; }
    }
}
