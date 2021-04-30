using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class StockMaterialViewModel
    {
        [Required]
        public Material Material { get; set; }

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
