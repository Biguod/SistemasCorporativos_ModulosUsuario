using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class Permissions
    {
        [Key]
        public int PermissionId { get; set; }

        [Required]
        public string Description { get; set; }

        public List<UsersPermissions> UserPermissions { get; set; }
    }
}
