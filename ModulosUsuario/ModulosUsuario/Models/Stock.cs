using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        [Required]
        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }
    }
}