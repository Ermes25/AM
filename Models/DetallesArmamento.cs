using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Models
{
    [Table("DetallesArmamento")]
    public class DetallesArmamento
    {
        [Key]
        public long? IdDetalle { get; set; }
        public int? IdArma { get; set; }
        [Required]
        [MaxLength(50)]
        public string NPiston { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string NCierre { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Cargador { get; set; } = string.Empty;
        public bool Activo { get; set; }

    }
}
