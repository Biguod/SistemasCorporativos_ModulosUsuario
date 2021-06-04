using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Models
{
    public class PaymentMethods
    {
        [Key]
        public int PaymentMethodId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
