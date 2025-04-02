using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Models
{
    [Table("Municion")]
    public class Municion
    {
        [Key]
        public int IdMunicion { get; set; }
        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Calibre { get; set; } = string.Empty ;
        [Required]
        public int CantidadDisponible { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
