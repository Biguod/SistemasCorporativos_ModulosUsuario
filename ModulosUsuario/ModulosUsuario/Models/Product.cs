using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string SKU { get; set; } // Sepa string ?

        [Required]
        public string Description { get; set; }

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
        public decimal PriceList { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual UnityType UnityType { get; set; }

        public List<ProductTransaction> ProductTransactions { get; set; }
    }
}
