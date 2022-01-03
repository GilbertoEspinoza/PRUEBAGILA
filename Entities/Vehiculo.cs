using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    public partial class Vehiculo : MessageHandler
    {
        [NotMapped]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(45)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Linea")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una linea.")]
        public int IdLinea { get; set; }

        [Display(Name = "Linea")]
        public string LineaString { get; set; }

        [Display(Name = "Marca")]
        public int IdMarca { get; set; }

        [Display(Name = "Marca")]
        public string MarcaString { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        [StringLength(45)]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un tipo.")]
        public int IdTipo { get; set; }

        [Display(Name = "Tipo")]
        public string TipoString { get; set; }

        [Required]
        [Display(Name = "Tipo uso")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un tipo uso.")]
        public int IdTipoUso { get; set; }

        [Display(Name = "Tipo uso")]
        public string TipoUsoString { get; set; }

        [Required]
        [Display(Name = "Tipo combustible")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un tipo de combustible.")]
        public int IdTipoCombustible { get; set; }

        [Display(Name = "Tipo combustible")]
        public string TipoCombustibleString { get; set; }

        [Display(Name = "Accesorio")]
        public int IdAccesorio { get; set; }

        [Display(Name = "Accesorio")]
        public string AccesorioString { get; set; }

        [Display(Name = "Placas")]
        [StringLength(8)]
        public string Placas { get; set; }

        [Display(Name = "N° Serial")]
        [StringLength(18)]
        public string Serial { get; set; }

        [Required]
        public int Llantas { get; set; }

        [Required]
        [Display(Name = "Potencia Motor")]
        public int Potencia { get; set; }


    }
}
