using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class AddressUser
    {
        [Key]
        public int AddressId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string District { get; set; }
        public User User { get; set; }
    }
}