using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Models
{
    public class Tools
    {
        [Key]
        public int ToolsId { get; set; }

        [Required]
        public string Name { get; set; } //Arrumar no banco para Name está name

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public int Unity { get; set; }

        [Required]
        public string Status { get; set; } // Talvez usar um Int para os Status e cada numero equivale a um status ?

        [Required]
        public decimal PriceCost { get; set; } //Arrumar no banco para Decimal
    }
}
