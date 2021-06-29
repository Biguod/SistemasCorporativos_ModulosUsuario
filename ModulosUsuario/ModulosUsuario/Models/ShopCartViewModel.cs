using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Models
{
    public class ShopCartViewModel
    {
        public List<Sale> Products { get; set; }
        public User User { get; set; }

        [Required]
        public int AddressUserId { get; set; }

        public decimal TotalPrice { get; set; }

        public CreditCardViewModel CreditCard { get; set; }

        [Required]
        public int PaymentMethodId { get; set; }

    }
}
