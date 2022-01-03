using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class Marca : MessageHandler
    {
        public Marca()
        { }

        [NotMapped]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Marca")]
        [StringLength(255)]
        public string Nombre { get; set; }

    }
}
