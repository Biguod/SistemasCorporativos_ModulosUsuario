using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class ProductTransaction
    {
        [Key]
        public int ProductTransactionId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnityValue { get; set; }

        [Required]
        public int TransactionTypeId { get; set; }

        [Required]
        public int StockId { get; set; }

        public Product Product { get; set; }
        public Stock Stock { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}