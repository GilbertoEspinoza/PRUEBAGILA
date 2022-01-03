using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class Usuario : MessageHandler
    {
        [NotMapped]

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [StringLength(45)]
        [Display(Name = "Usuario")]
        public string UsuarioName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }

        [StringLength(255)]
        [Display(Name = "Nueva contraseña")]
        public string NewClave { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; }

        [Display(Name = "Cambiar contraseña")]
        public int Cambiar { get; set; }

        [Display(Name = "Cambiar contraseña")]
        public string CambiarString { get; set; }

        [Display(Name = "Cambiar contraseña")]
        public bool CambiarCheck { get; set; }

        [Required]
        [Display(Name = "Tipo usuario")]
        public int Tipo { get; set; }

        [Display(Name = "Tipo usuario")]
        public string TipoString { get; set; }

        //public int CreadoPor { get; set; }

        //public DateTime FechaRegistro { get; set; }

        //public int ModificadoPor { get; set; }

        //public DateTime FechaModificacion { get; set; }

        public Perfil Perfil { get; set; }

        [Display(Name = "Perfil")]
        public string PerfilString { get; set; }

        public Modulo Modulos { get; set; }

        //[Display(Name = "Estatus")]
        //public int Activo { get; set; }

        //[Display(Name = "Estatus")]
        //public string ActivoString { get; set; }

        //[Display(Name = "Estatus")]
        //public bool ActivoCheck { get; set; }


        //public int IdUsuario { get; set; }

        //[Display(Name = "Usuario creo")]
        //public string UsuarioCreo { get; set; }

        //[Display(Name = "Usuario modifico")]
        //public string UsuarioModifico { get; set; }

        //[Display(Name = "Fecha creación")]
        //public string FechaCreacion { get; set; }

        //[Display(Name = "Fecha modificación")]
        //public string FechaModificado { get; set; }
        public List<Modulo> ListaModulo { get; set; }
        public List<Perfil> ListaPerfil { get; set; }
    }
}
