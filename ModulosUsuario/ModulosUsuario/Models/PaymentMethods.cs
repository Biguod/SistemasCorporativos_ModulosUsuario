using System.ComponentModel.DataAnnotations;

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
