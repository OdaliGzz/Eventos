namespace EventosAPI.ViewModels
{
    public class OrganizadorUVM
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
    }
    public class OrganizadorVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Comentarios { get; set; }
    }

    public class OrganizadorConEventosyUsuariosVM
    {
        public string Nombre { get; set; }
        public List<EventoUsuarioVM> EventoUsuarios { get; set; }
    }

    public class EventoUsuarioVM
    {
        
        public string EventoNombre { get; set; }
        public List<string> EventoUsuario { get; set; }
    }
}
