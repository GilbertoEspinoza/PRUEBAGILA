using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class Modulo : MessageHandler
    {
        public Modulo()
        { }

        [NotMapped]

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Modulo")]
        [StringLength(45)]
        public string ModuloName { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(45)]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Menu")]
        public int Menu { get; set; }

        [Display(Name = "Menu")]
        public string MenuString { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public int Tipo { get; set; }

        [Display(Name = "Tipo")]
        public string TipoString { get; set; }

        [Display(Name = "MenuP")]
        public string MenuP { get; set; }

        [Display(Name = "TipoP")]
        public int TipoP { get; set; }

        [Display(Name = "Tag")]
        public string Tag { get; set; }

        [Display(Name = "Controller")]
        public string Controller { get; set; }

        [Display(Name = "ControllerTag")]
        public string ControllerTag { get; set; }

        [Display(Name = "Action")]
        public string Action { get; set; }

        [Display(Name = "Css Class")]
        public string CssClass { get; set; }

        [Display(Name = "Css ClassP")]
        public string CssClassP { get; set; }

        [Display(Name = "Icon")]
        public string Icon { get; set; }

        [Display(Name = "IconP")]
        public string IconP { get; set; }

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

        [Display(Name = "Cancelar")]
        public int Cancel { get; set; }

        [Display(Name = "Cancelar")]
        public string CancelString { get; set; }

        [Display(Name = "Cancelar")]
        public bool CancelCheck { get; set; }

        [Display(Name = "Validar")]
        public int Validar { get; set; }

        [Display(Name = "Validar")]
        public string ValidarString { get; set; }

        [Display(Name = "Validar")]
        public bool ValidarCheck { get; set; }

        [Display(Name = "Ver documento")]
        public int Viewdoc { get; set; }

        [Display(Name = "Ver documento")]
        public string ViewdocString { get; set; }

        [Display(Name = "Ver documento")]
        public bool ViewdocCheck { get; set; }

        [Display(Name = "Cargar")]
        public int Updaload { get; set; }

        [Display(Name = "Cargar")]
        public string UpdaloadString { get; set; }

        [Display(Name = "Cargar")]
        public bool UpdaloadCheck { get; set; }

        [Display(Name = "Descargar")]
        public int Download { get; set; }

        [Display(Name = "Descargar")]
        public string DownloadString { get; set; }

        [Display(Name = "Descargar")]
        public bool DownloadCheck { get; set; }

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
        //public bool ActivoCheck { get; set; }

        //[Display(Name = "Estatus")]
        //public string ActivoString { get; set; }

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
