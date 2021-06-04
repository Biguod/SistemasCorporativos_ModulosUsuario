using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class SaleViewModel
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public int StockQuantity { get; set; }

        public decimal AverageCost { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public int Quantity { get; set; }

        public Stock Stock { get; set; }

        public int StockId { get; set; }

        public int UserId { get; set; }
    }
}