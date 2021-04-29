using System;
using System.ComponentModel.DataAnnotations;

namespace ModulosUsuario.Models
{
    public class ToolsLog
    {
        [Key]
        public int ToolsLogId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ToolsId { get; set; }

        [Required]
        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }

        [Required]
        public Tools Tool { get; set; }
    }
}