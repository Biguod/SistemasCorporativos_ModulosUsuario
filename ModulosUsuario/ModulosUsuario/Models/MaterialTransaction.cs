using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class MaterialTransaction
    {
        [Key]
        public int MaterialTransactionId { get; set; }

        [Required]
        public int MaterialId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnityValue { get; set; }

        [Required]
        public decimal TotalValue { get; set; }

        [Required]
        public TransactionType TransactionTypeId { get; set; }

        [Required]
        public List<Stock> Stocks { get; set; }

        public Material Material { get; set; }
    }
}