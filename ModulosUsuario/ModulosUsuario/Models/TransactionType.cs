using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class TransactionType
    {
        [Key]
        public int TransactionTypeId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsIncoming { get; set; }
    }
}
