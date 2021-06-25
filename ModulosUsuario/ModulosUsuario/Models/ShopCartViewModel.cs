using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Models
{
    public class ShopCartViewModel
    {
        public List<Sale> Products { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
