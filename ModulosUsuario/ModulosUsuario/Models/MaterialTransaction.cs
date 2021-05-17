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
        [Display(Name = "Quantidade")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Valor unitário")]
        public decimal UnityValue { get; set; }

        [Required]
        public int TransactionTypeId { get; set; }

        [Required]
        public int StockId { get; set; }

        public Stock Stock { get; set; }

        public TransactionType TransactionType { get; set; }

        public Material Material { get; set; }
    }
}