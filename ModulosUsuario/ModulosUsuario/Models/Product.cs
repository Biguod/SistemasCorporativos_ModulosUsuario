﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public int SKU { get; set; } // Sepa string ?

        [Required]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public int Unity { get; set; }

        [Required]
        public int UnityTypeId { get; set; }

        [Required]
        public decimal PriceList { get; set; }

        public virtual UnityType UnityType { get; set; }
    }
}