using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class ProductTransaction
    {
        [Key]
        public int ProductTransactionId { get; set; }

        [Required]
        [Display(Name = "Produto")]
        public int ProductId { get; set; }

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

        [Required]
        public int UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual User User { get; set; }
    }
}