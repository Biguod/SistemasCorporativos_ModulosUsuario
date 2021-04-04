using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class AddressUser
    {
        [Key]
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string District { get; set; }
        public User User { get; set; }
    }
}
