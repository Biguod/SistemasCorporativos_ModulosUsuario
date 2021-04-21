using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public int Unity { get; set; }

        [Required]
        public decimal PriceCost { get; set; } //Arrumar no banco para decimal
    }
}
