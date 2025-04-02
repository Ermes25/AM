using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AM.Models
{
    [Table("Armamentos")]
    public class Armamento
    {
        [Key]
        public int IdArma { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Tipo { get; set; }
        [Required]
        public int? Año { get; set; }
        [Required]
        [MaxLength(1)]
        public string? Letra { get; set; }
        [Required]
        [MaxLength(50)]
        public string? NSerie { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
