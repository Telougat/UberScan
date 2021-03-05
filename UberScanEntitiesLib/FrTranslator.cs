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
        [Column("tranlatorID", TypeName = "Int")]
        public long TranlatorID { get; set; }
        [Required]
        [Column("translatorName", TypeName = "Varchar (40)")]
        [StringLength(40)]
        public string TranslatorName { get; set; }

        [InverseProperty(nameof(Manga.Tranlator))]
        public virtual ICollection<Manga> Mangas { get; set; }
    }
}
