using System.Collections.Generic;
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
        public decimal TotalValue { get; set; }

        [Required]
        public TransactionType TransactionTypeId { get; set; }

        [Required]
        public List<Stock> Stocks { get; set; }

        public Tools Tool { get; set; }
    }
}