using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class UnityType
    {
        [Key]
        public int UnityTypeId { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
