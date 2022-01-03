using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class UsuarioPerfil : MessageHandler
    {
        public UsuarioPerfil()
        { }

        [NotMapped]

        [Key]
        public int Idusuarioperfile { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        public int IdPerfil { get; set; }

        public string Perfil { get; set; }

        public string Descripcion { get; set; }

        public string Check { get; set; }

        public string NombreUsuario { get; set; }

    }
}
