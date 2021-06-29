using System;
using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public int ProductTransactionId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? DeliveryAddressUserId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ProductTransaction ProductTransaction { get; set; }
        public virtual PaymentMethods PaymentMethod { get; set; }
    }
}
