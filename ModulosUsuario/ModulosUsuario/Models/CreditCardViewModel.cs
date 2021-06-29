using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Models
{
    public class CreditCardViewModel
    {
        
        [MinLength(16)]
        [MaxLength(16)]
        public string CardNumber { get; set; }

        
        [MinLength(3)]
        [MaxLength(3)]
        public string CVV { get; set; }

        
        public string CreditCardOwner { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime? CardExpiryDate { get; set; }

    }
}
