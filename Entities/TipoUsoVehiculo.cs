﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class TipoUsoVehiculo : MessageHandler
    {
        public TipoUsoVehiculo()
        { }

        [NotMapped]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(255)]
        public string Nombre { get; set; }

    }
}
