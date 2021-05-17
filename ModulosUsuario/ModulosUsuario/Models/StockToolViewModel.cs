using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class StockToolViewModel
    {
        [Required]
        public int ToolId { get; set; }

        [Required]
        public string ToolName { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public decimal AverageCost { get; set; }

        [Required]
        public int StockId { get; set; }
    }
}