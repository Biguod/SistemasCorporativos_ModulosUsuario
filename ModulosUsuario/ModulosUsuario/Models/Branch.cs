using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }

        [Required]
        [Display(Name = "Nome Filial")]
        public string Description { get; set; }

        public Stock Stock { get; set; }

    }
}
