using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Services
{
    public interface ISaleService
    {
        IEnumerable<SaleListViewModel> GetAllProducts();
        SaleViewModel GetProductForSaleById(int stockId, int productId);
        void ReserveProduct(SaleViewModel model);
        void CancelReservedSale(int productTransactionId);
        ShopCartViewModel GetCartByCustomer(User user);
        List<Sale> FinishSale(ShopCartViewModel model);
    }
}