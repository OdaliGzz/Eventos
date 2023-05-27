namespace EventosAPI.ViewModels
{
    public class Usuario_VM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
    }

    public class UsuarioVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public bool Notificado { get; set; }
    }

    public class UsuarioConEventosVM
    {
        public string Nombre { get; set; }
        public List<String> EventoNombre { get; set; }

    }
}
