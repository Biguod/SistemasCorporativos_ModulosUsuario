using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Data de vencimento")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required]
        [Display(Name = "Unidade")]
        public int Unity { get; set; }

        [Required]
        public int UnityTypeId { get; set; }

        [Required]
        [Display(Name = "Preço de custo")]
        public decimal PriceCost { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual UnityType UnityType { get; set; }

        public List<MaterialTransaction> MaterialTransactions { get; set; }
    }
}
