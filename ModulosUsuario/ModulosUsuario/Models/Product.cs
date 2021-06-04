using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModulosUsuario.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "SKU")]
        public string SKU { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Data de Vencimento")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required]
        [Display(Name = "Unidade")]
        public int Unity { get; set; }

        [Required]
        public int UnityTypeId { get; set; }

        [Required]
        [Display(Name = "Preço de Lista")]

        public decimal PriceList { get; set; }

        [Required]
        public bool Active { get; set; }

        [Display(Name = "Imagem do Produto")]
        public string ProductImage { get; set; }

        [Display(Name = "Imagem do Produto")]
        [NotMapped]
        public IFormFile ProductImageFile { get; set; }

        public virtual UnityType UnityType { get; set; }

        public List<ProductTransaction> ProductTransactions { get; set; }
    }
}