using System.Collections.Generic;

namespace ModulosUsuario.Models
{
    public class StocksViewModel
    {
        public Stock Stock { get; set; }
        public List<StockProductViewModel> StockProducts { get; set; }
        public List<StockMaterialViewModel> StockMaterials { get; set; }
        public List<StockToolViewModel> StockTools { get; set; }
    }
}