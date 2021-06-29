using Microsoft.EntityFrameworkCore;
using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DatabaseContext context;
        public PaymentRepository(DatabaseContext context) 
        {
            this.context = context;
        }

        public PaymentMethods CreatePaymentMethod(PaymentMethods payment)
        {
            context.Add(payment);
            context.SaveChanges();
            return payment;
        }

        public IEnumerable<PaymentMethods> GetAllPaymentMethods()
        {
            return context.PaymentMethods.ToList(); 
        }

        public PaymentMethods UpdatePaymentMethod(PaymentMethods payment)
        {
            context.Update(payment);
            context.SaveChanges();
            return payment;
        }

        public PaymentMethods GetPaymentMethodById(int paymentId)
        {            
            return context.PaymentMethods.Find(paymentId);
        }
    }
}
