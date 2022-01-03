using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class UsuarioModulo : MessageHandler
    {
        public UsuarioModulo()
        { }

        [NotMapped]

        [Key]
        public int Idusuariomodulo { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        public int IdModulo { get; set; }

        public string Modulo { get; set; }

        public string Modifico { get; set; }

        public string Check { get; set; }


        public string CreadoPorUsuario { get; set; }

        public string NombreUsuario { get; set; }

        [Display(Name = "Agregar")]
        public int Agregar { get; set; }

        [Display(Name = "Agregar")]
        public string AgregarString { get; set; }

        [Display(Name = "Agregar")]
        public bool AgregarCheck { get; set; }

        [Display(Name = "Modificar")]
        public int Modificar { get; set; }

        [Display(Name = "Modificar")]
        public string ModificarString { get; set; }

        [Display(Name = "Modificar")]
        public bool ModificarCheck { get; set; }

        [Display(Name = "Eliminar")]
        public int Eliminar { get; set; }

        [Display(Name = "Eliminar")]
        public string EliminarString { get; set; }

        [Display(Name = "Eliminar")]
        public bool EliminarCheck { get; set; }

        [Display(Name = "Consultar")]
        public int Consultar { get; set; }

        [Display(Name = "Consultar")]
        public string ConsultarString { get; set; }

        [Display(Name = "Consultar")]
        public bool ConsultarCheck { get; set; }

        [Display(Name = "Autorizar")]
        public int Autorizar { get; set; }

        [Display(Name = "Autorizar")]
        public string AutorizarString { get; set; }

        [Display(Name = "Autorizar")]
        public bool AutorizarCheck { get; set; }

        [Display(Name = "Zona")]
        public int Zona { get; set; }

        [Display(Name = "Zona")]
        public string ZonaString { get; set; }

        [Display(Name = "Zona")]
        public bool ZonaCheck { get; set; }

        [Display(Name = "Asignar")]
        public int Asignar { get; set; }

        [Display(Name = "Asignar")]
        public string AsignarString { get; set; }

        [Display(Name = "Asignar")]
        public bool AsignarCheck { get; set; }

        [Display(Name = "Imprimir")]
        public int Imprimir { get; set; }

        [Display(Name = "Imprimir")]
        public string ImprimirString { get; set; }

        [Display(Name = "Imprimir")]
        public bool ImprimirCheck { get; set; }

    }
}
