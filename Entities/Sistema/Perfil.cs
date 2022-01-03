using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class Perfil : MessageHandler
    {
        public Perfil()
        { }

        [NotMapped]

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Perfil")]
        [StringLength(45)]
        public string PerfilName { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(255)]
        public string Descripcion { get; set; }

        [Display(Name = "Seleccionado")]
        public int Check { get; set; }

        [Display(Name = "Seleccionado")]
        public string CheckString { get; set; }

        [Display(Name = "Seleccionado")]
        public bool CheckBool { get; set; }

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
