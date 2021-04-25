using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
