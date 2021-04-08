using System.Collections.Generic;

namespace ModulosUsuario.Models
{
    public class AddressUserViewModel
    {
        public int UserId { get; set; }
        public List<AddressUser> Addresses { get; set; }
    }
}
