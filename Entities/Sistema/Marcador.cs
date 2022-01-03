using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class Marcador : MessageHandler
    {
        public Marcador()
        { }

        [NotMapped]

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(45)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public int IdModulo { get; set; }

        [Required]
        [Display(Name = "Módulo")]
        public string Modulo { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public int Tipo { get; set; }

        [Display(Name = "Tipo")]
        public bool TipoCheck { get; set; }

        [Display(Name = "Tipo")]
        public string TipoNombre { get; set; }

        //public int CreadoPor { get; set; }

        //public DateTime FechaRegistro { get; set; }

        //public int ModificadoPor { get; set; }

        //public DateTime FechaModificacion { get; set; }

        //[Display(Name = "Estatus")]
        //public int Activo { get; set; }

        //[Display(Name = "Estatus")]
        //public string ActivoString { get; set; }

        //[Display(Name = "Estatus")]
        //public bool ActivoCheck { get; set; }

        //public int IdUsuario { get; set; }

        //[Display(Name = "Creado por")]
        //public string UsuarioCreo { get; set; }

        //[Display(Name = "Modificado por")]
        //public string UsuarioModifico { get; set; }

        //[Display(Name = "Fecha creación")]
        //public string FechaCreacion { get; set; }

        //[Display(Name = "Fecha modificación")]
        //public string FechaModificado { get; set; }
    }
}
