using EventosAPI.Controllers;
using EventosAPI.Entidades;
using EventosAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EventosAPI.Servicios
{
    public class EventosServicio
    {
        private ApplicationDbContext _context; 
        public EventosServicio(ApplicationDbContext context) 
        {
            _context = context;
        }

        /*
        public void AgregarEvento(Evento_VM evento)
        {
            var _evento = new Evento()
            {
                Nombre = evento.Nombre,
                Descripcion = evento.Descripcion,
                Fecha = DateTime.Now,
                Ubicacion = evento.Ubicacion,
                Capacidad = evento.Capacidad,
                OrganizadorId = evento.OrganizadorId

            };
            _context.Eventos.Add(_evento); 
            _context.SaveChanges();
            
        }
        */
        public void AgregarEventoConUsuarios(EventoVM evento)
        {
            var _evento = new Evento()
            {
                Nombre = evento.Nombre,
                Descripcion = evento.Descripcion,
                Fecha = DateTime.Now,
                Ubicacion = evento.Ubicacion,
                Capacidad = evento.Capacidad,
                OrganizadorId = evento.OrganizadorId
                
            };
            _context.Eventos.Add(_evento); 
            _context.SaveChanges();

            foreach (var id in evento.UsuariosId)
            {
                var _evento_usuario = new Evento_Usuario()
                {
                    EventoId = _evento.Id,
                    UsuarioId = id
                };
                _context.Eventos_Usuarios.Add(_evento_usuario);
                _context.SaveChanges();
            }
        }
 

        public List<Evento> GetAllEventos() => _context.Eventos.ToList();
        public Evento GetEventoById(int eventoId) => _context.Eventos.FirstOrDefault(n => n.Id == eventoId);
        
        public EventoConUsuariosVM GetEventoConUsuariosById(int eventoId)
        {
            var _eventoConUsuarios = _context.Eventos.Where(n => n.Id == eventoId).Select(evento => new EventoConUsuariosVM()
            {
                Nombre = evento.Nombre,
                Descripcion = evento.Descripcion,
                Fecha = DateTime.Now,
                Ubicacion = evento.Ubicacion,
                Capacidad = evento.Capacidad,
                OrganizadorNombre = evento.Organizador.Nombre,
                UsuariosNombre = evento.Evento_Usuarios.Select(n => n.Usuario.Nombre).ToList()
            }).FirstOrDefault();
            return _eventoConUsuarios;

            
        }
        public Evento UpdateEventoById (int eventoId, EventoVM evento)
        {
            var _evento = _context.Eventos.FirstOrDefault(n => n.Id == eventoId);
            if(_evento != null)
            {
                _evento.Nombre = evento.Nombre;
                _evento.Descripcion = evento.Descripcion;
                _evento.Fecha = DateTime.Now;
                _evento.Ubicacion = evento.Ubicacion;
                _evento.Capacidad = evento.Capacidad;
                _context.SaveChanges();


            }
            return _evento;
        }

        public void DeleteEventoById(int eventoId)
        {
            var _evento = _context.Eventos.FirstOrDefault(n => n.Id == eventoId);
            if(_evento != null)
            {
                _context.Eventos.Remove(_evento);
                _context.SaveChanges();
            }
        }
 
    }
}
