using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class Linea : MessageHandler
    {
        public Linea()
        { }

        [NotMapped]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Marca")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una marca.")]
        public int IdMarca { get; set; }

        [Required]
        [Display(Name = "Linea")]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Display(Name = "Marca")]
        public string MarcaString { get; set; }

    }
}
