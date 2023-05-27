using System.ComponentModel.DataAnnotations;

namespace EventosAPI.Entidades
{
    public class Organizador
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")] //
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        public string Nombre { get; set; }
        public string Comentarios { get; set; }
        /*
        public int EventoId { get; set; }
        //Obtiene la informacion del evento relacionada al usuario
        public Evento evento { get; set; }
        */

        public List<Evento> Eventos { get; set; }
        //public List<Usuario> Usuarios { get; set; }

    }
}
