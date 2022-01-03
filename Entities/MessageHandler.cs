using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities
{
    public class MessageHandler
    {
        private string _mensajeExito = "";

        private string _mensajeError = "";
        /// <summary>
        /// Mensaje que contiene el resultado de la operación si esta fue exitosa, 
        /// tambien puede contener mensajes de error hacia el usuario.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string MensajeExito
        {
            get { return _mensajeExito; }
            set { _mensajeExito = value; }
        }
        /// <summary>
        /// Mensaje que contiene el error si es que se presento uno durante la operación.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string MensajeError
        {
            get { return _mensajeError; }
            set { _mensajeError = value; }
        }

        public int CreadoPor { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int ModificadoPor { get; set; }

        public DateTime FechaModificacion { get; set; }

        [Display(Name = "Estatus")]
        public int Activo { get; set; }

        [Display(Name = "Estatus")]
        public string ActivoString { get; set; }

        [Display(Name = "Estatus")]
        public bool ActivoCheck { get; set; }

        public int IdUsuario { get; set; }

        [Display(Name = "Creado por")]
        public string UsuarioCreo { get; set; }

        [Display(Name = "Modificado por")]
        public string UsuarioModifico { get; set; }

        [Display(Name = "Fecha creación")]
        public string FechaCreacion { get; set; }

        [Display(Name = "Fecha modificación")]
        public string FechaModificado { get; set; }
    }
}
