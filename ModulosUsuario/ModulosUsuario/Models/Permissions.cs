using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
