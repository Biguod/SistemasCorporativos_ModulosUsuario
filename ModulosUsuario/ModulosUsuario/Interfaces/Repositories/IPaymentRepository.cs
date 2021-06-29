using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        IEnumerable<PaymentMethods> GetAllPaymentMethods();
        PaymentMethods CreatePaymentMethod(PaymentMethods payment);

        PaymentMethods UpdatePaymentMethod(PaymentMethods payment);

        PaymentMethods GetPaymentMethodById(int paymentId);
    }
}
