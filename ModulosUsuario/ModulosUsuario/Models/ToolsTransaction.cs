using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class ToolsTransaction
    {
        [Key]
        public int ToolsTransactionId { get; set; }

        [Required]
        public int ToolId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnityValue { get; set; }

        [Required]
        public int TransactionTypeId { get; set; }

        [Required]
        public int StockId { get; set; }

        public TransactionType TransactionType { get; set; }

        public Stock Stock { get; set; }

        public Tools Tool { get; set; }
    }
}