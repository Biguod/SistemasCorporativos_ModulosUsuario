using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class StockProductViewModel
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal AverageCost { get; set; }

        [Required]
        public Stock Stock { get; set; }
    }
}
