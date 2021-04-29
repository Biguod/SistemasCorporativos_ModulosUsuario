using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Models
{
    public class StockMaterialViewModel
    {
        [Required]
        public int MaterialId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal AverageCost { get; set; }

        [Required]
        public int StockId { get; set; }
    }
}
