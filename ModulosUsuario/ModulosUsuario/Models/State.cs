using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}