using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class Combustible : MessageHandler
    {
        public Combustible()
        { }

        [NotMapped]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

    }
}
