namespace ModulosUsuario.Models
{
    public class SaleListViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public int StockQuantity { get; set; }

        public decimal AverageCost { get; set; }

        public int StockId { get; set; }
    }
}