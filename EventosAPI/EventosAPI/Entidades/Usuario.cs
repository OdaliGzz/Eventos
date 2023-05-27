using System.ComponentModel.DataAnnotations;

namespace EventosAPI.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        public string Nombre { get; set; }

        public string Correo { get; set; }
        public bool Notificado { get; set; }
        public List<Evento_Usuario> Evento_Usuarios { get; set; }


        /*
        //BD donde se guarda el id del evento
        public int EventoId { get; set; }
        //Obtiene la informacion del evento relacionada al usuario
        public Evento evento { get; set; }
        public int OrganizadorId { get; set; }
        public Organizador organizador { get; set; }

        public List<Evento> Eventos { get; set; }

        public List<Organizador> Organizadores { get; set; }
        */
    }
}
