using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Services
{
    public interface IPaymentService
    {
        IEnumerable<PaymentMethods> GetPaymentMethods();
    }
}