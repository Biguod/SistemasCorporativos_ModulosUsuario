using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Models
{
    public class CreditCardViewModel
    {
        [Required(ErrorMessage = "Numero de cartão inválido!")]
        [MinLength(16)]
        [MaxLength(16)]
        public string CardNumber { get; set; }

        [Required]
        public CreditCardFlag CreditCardFlag { get; set; }

        [Required(ErrorMessage = "Numero de CVV inválido!")]
        [MinLength(3)]
        [MaxLength(3)]
        public string CVV { get; set; }

        [Required]
        public string CreditCardOwner { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")]
        public DateTime CardExpiryDate { get; set; }

    }
}
