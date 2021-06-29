using Microsoft.EntityFrameworkCore;
using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DatabaseContext context;
        public SaleRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public Sale Create(Sale sale)
        {
            context.Add(sale);
            context.SaveChanges();
            return sale;
        }

        public IEnumerable<Sale> GetAll()
        {
            return context.Sale.ToList();
        }

        public Sale Update(Sale sale)
        {
            context.Update(sale);
            context.SaveChanges();
            return GetById(sale.SaleId);
        }

        public void Delete(Sale sale)
        {
            context.Remove(sale);
            context.SaveChanges();
        }

        public Sale GetById(int saleId)
        {
            var sale = context.Sale
                .Where(w => w.SaleId == saleId)
                .Include(i => i.ProductTransaction)
                .Include(n => n.PaymentMethod)
                .Include("ProductTransaction.User")
                .Include("ProductTransaction.Product")
                .Include("ProductTransaction.Stock")
                .FirstOrDefault();

            if (sale == null)
                sale = new Sale();
            return sale;
        }

        public Sale GetByProductTransactionId(int productTransactionId)
        {
            var sale = context.Sale
                .Where(w => w.ProductTransactionId == productTransactionId)
                .Include(i => i.ProductTransaction)
                .Include(n => n.PaymentMethod)
                .Include("ProductTransaction.User")
                .Include("ProductTransaction.Product")
                .Include("ProductTransaction.Stock")
                .FirstOrDefault();

            if (sale == null)
                sale = new Sale(); //trhow exception

            return sale;
        }

        public List<Sale> GetAllReservedByUserId(int userId)
        {
            var sale = context.Sale
                .Where(w => w.ProductTransaction.UserId == userId && w.Status == "Reservado" && w.ExpirationDate.HasValue && w.ExpirationDate.Value.Date >= DateTime.Now)
                .Include(i => i.ProductTransaction)
                .Include("ProductTransaction.User")
                .Include("ProductTransaction.Product")
                .Include("ProductTransaction.Stock")
                .ToList();

            if (sale == null)
                sale = new List<Sale>(); //trhow exception

            return sale;
        }
    }
}
