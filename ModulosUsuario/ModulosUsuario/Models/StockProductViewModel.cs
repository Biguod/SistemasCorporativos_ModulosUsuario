using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class StockProductViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public decimal AverageCost { get; set; }

        [Required]
        public int StockId { get; set; }
    }
}