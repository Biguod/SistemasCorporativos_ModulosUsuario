using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Models
{
    public class CreditCardFlag
    {
        [Key]
        public int CreditCardFlagId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
