using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class StockMaterialViewModel
    {
        [Required]
        public int MaterialId { get; set; }

        [Required]
        public string MaterialName { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public decimal AverageCost { get; set; }

        [Required]
        public int StockId { get; set; }
    }
}