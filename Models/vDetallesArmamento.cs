using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Models
{
    [Table("vDetallesArmamento")]
    public class vDetallesArmamento
    {
        [Key]
        public long? IdDetalle { get; set; }
        public int? IdArma {  get; set; }
        public string Tipo {  get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string NPiston { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string NCierre { get; set; } = string.Empty ;
        [Required]
        [MaxLength(50)]
        public string Cargador { get; set; } = string.Empty;
        public bool Activo { get; set; }

    }
}
