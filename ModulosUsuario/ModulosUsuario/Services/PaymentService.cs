using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;

namespace ModulosUsuario.Services
{
    public class PaymentService : IPaymentService
    {
        public readonly IPaymentRepository paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        public bool CreditCardPayment(CreditCardViewModel creditCard)
        {
            if(creditCard == null || creditCard.CardNumber.Length != 16 || creditCard.CVV.Length != 3 || creditCard.CardExpiryDate < DateTime.Now)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<PaymentMethods> GetPaymentMethods()
        {
            return paymentRepository.GetAllPaymentMethods();
        }
    }
}

//Cartão de crédito
//    - numero do cartão 16 digitos
//    - data de validade do cartão mes/ano
//    - nome registrado no cartão
//    - cvv 3 digitos
//    - bandeira do cartão

//pix 
//    - mostrar na tela o cnpj da empresa
//    - mostrar o nome da empresa q deve aparecer
//    - mostrar QR Code

//transferencia bancaria
//    - Mostrar na tela a conta para fazer o deposito
//    - mostrar o banco para realizar o deposito
//    - mostrar a agencia
//    - mostrar nome da empresa

//boleto
//    - mostrar o botão de imprimir boleto
//    - mostrar os digitos do codigo de barras

