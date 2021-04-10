using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}