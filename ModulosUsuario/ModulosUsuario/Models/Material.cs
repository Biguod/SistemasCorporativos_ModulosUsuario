﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required]
        public int Unity { get; set; }

        [Required]
        public int UnityTypeId { get; set; }

        [Required]
        public decimal PriceCost { get; set; }

        public virtual UnityType UnityType { get; set; }
    }
}
