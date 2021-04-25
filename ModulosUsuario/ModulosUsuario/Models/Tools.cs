using System;
using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class Tools
    {
        [Key]
        public int ToolsId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required]
        public int Unity { get; set; }

        [Required]
        public int UnityTypeId { get; set; }

        [Required]
        public string Status { get; set; } // Talvez usar um Int para os Status e cada numero equivale a um status ?

        [Required]
        public decimal PriceCost { get; set; }

        public virtual UnityType UnityType { get; set; }
    }
}
