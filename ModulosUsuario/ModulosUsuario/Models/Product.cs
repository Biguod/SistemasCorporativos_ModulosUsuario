using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Models
{
    public class Product // Adicionar UnityType no banco de dados (Kg, L, Fardo, mL)
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public int SKU { get; set; } // Sepa string ?

        [Required]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public int Unity { get; set; }

        [Required]
        public decimal PriceList { get; set; } // Fazer alteração no banco
    }
}
