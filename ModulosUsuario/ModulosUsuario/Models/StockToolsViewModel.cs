using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class StockToolsViewModel
    {
        [Required]
        public Tools Tools { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal AverageCost { get; set; }

        [Required]
        public Stock Stock { get; set; }
    }
}
