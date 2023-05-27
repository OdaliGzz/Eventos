using System.ComponentModel.DataAnnotations;

namespace EventosAPI.Entidades
{
    public class Evento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")] //
        [StringLength(maximumLength: 150, ErrorMessage = "El campo {0} solo puede tener hasta 150 caracteres")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public string Ubicacion { get; set; }

        public int Capacidad { get; set; }

        public int OrganizadorId { get; set; }
        public Organizador Organizador { get; set; }

        public List<Evento_Usuario> Evento_Usuarios { get; set; }

        //Para cargar la lista de los usuarios registrados en el evento
        //public List<Usuario> Usuarios { get; set; }
    }
}
