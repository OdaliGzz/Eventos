namespace EventosAPI.ViewModels
{
    /*
    public class Evento_VM
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public string Ubicacion { get; set; }

        public int Capacidad { get; set; }

    }
    */
    public class EventoUVM
    {
        public string Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public string Ubicacion { get; set; }


    }

    public class EventoVM
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public string Ubicacion { get; set; }

        public int Capacidad { get; set; }

        public int OrganizadorId { get; set; }

        public List<int> UsuariosId { get; set; }


    }

    public class EventoConUsuariosVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public string Ubicacion { get; set; }

        public int Capacidad { get; set; }


        public string OrganizadorNombre { get; set; }

        public List<string> UsuariosNombre { get; set; }


    }
}
