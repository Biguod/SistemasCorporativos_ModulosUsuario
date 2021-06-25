using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();

        Sale Create(Sale sale);

        Sale Update(Sale sale);

        Sale GetById(int saleId);

        Sale GetByProductTransactionId(int productTransactionId);

        List<Sale> GetAllReservedByUserId(int userId);
    }
}