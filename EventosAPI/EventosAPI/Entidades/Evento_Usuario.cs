namespace EventosAPI.Entidades
{
    public class Evento_Usuario
    {
        public int Id { get; set; }

        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
