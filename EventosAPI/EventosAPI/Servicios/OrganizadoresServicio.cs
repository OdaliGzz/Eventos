using EventosAPI.Entidades;
using EventosAPI.Migrations;
using EventosAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EventosAPI.Servicios
{
    public class OrganizadoresServicio
    {
        private ApplicationDbContext _context;
        //Constructor
        public OrganizadoresServicio(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AgregarOrganizador(OrganizadorVM organizador)
        {
            var _organizador = new Organizador()
            {
                Nombre = organizador.Nombre,
                //Comentarios = organizador.Comentarios,

            };
            _context.Organizadores.Add(_organizador); //guardar de manera ascincrona
            _context.SaveChanges();
        }
        public UsuarioConEventosVM GetUsuarioConEventos(int usuarioId)
        {
            var _usuario = _context.Usuarios.Where(n => n.Id == usuarioId).Select(n => new UsuarioConEventosVM
            {
                Nombre = n.Nombre,
                EventoNombre = n.Evento_Usuarios.Select(n => n.Evento.Nombre).ToList()
            }).FirstOrDefault();

            return _usuario;
        }
        public OrganizadorConEventosyUsuariosVM GetOrganizadorData(int organizadorId)
        {
            var _organizadorData = _context.Organizadores.Where(n => n.Id == organizadorId).Select(n => new OrganizadorConEventosyUsuariosVM()
            {
                Nombre = n.Nombre,
                EventoUsuarios = n.Eventos.Select(n => new EventoUsuarioVM()
                {
                    EventoNombre = n.Nombre,
                    EventoUsuario = n.Evento_Usuarios.Select(n => n.Usuario.Nombre).ToList()
                }).ToList()
            }).FirstOrDefault();

            return _organizadorData;
        }
        public List<Organizador> GetAllOrganizadores() => _context.Organizadores.ToList();
        
        public Organizador GetOrganizadorById(int organizadorId) => _context.Organizadores.FirstOrDefault(n => n.Id == organizadorId);
        
        public void DeleteOrganizadorById(int id)
        {
            var _organizador = _context.Organizadores.FirstOrDefault(n => n.Id == id);

            if(_organizador != null)//Si no esta vacia la tabla
            {
                _context.Organizadores.Remove(_organizador);
                _context.SaveChanges();
            }
        }

        public void DeleteEventoById(int id)
        {
            var _evento = _context.Eventos.FirstOrDefault(n => n.Id == id);

            if (_evento != null)//Si no esta vacia la tabla
            {
                _context.Eventos.Remove(_evento);
                _context.SaveChanges();
            }
            
        }

        public Evento UpdateEventoById(int eventoId, EventoVM evento)
        {
            var _evento = _context.Eventos.FirstOrDefault(n => n.Id == eventoId);
            if (_evento != null)
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





        /*
         * 
         * public Usuario UpdateUsuarioById(int usuarioId, UsuarioVM usuario)
        {
            var _usuario = _context.Usuarios.FirstOrDefault(n => n.Id == usuarioId);
            if (_usuario != null)
            {
                _usuario.Nombre = _usuario.Nombre;
                _usuario.Correo = _usuario.Correo;
                _usuario.Notificado = _usuario.Notificado;

                _context.SaveChanges();


            }
            return _usuario;
        }
         * 
         * public Organizador UpdateOrganizadorById(int organizadorId, OrganizadorUVM organizador)
        {
            var _organizador = _context.Organizadores.FirstOrDefault(n => n.Id == organizadorId);
            if (_organizador != null)
            {
                _organizador.Comentarios = _organizador.Comentarios;
                _context.SaveChanges();


            }
            return _organizador;
        }

        public Organizador GetOrganizadorById(int organizadorId) => _context.Organizadores.FirstOrDefault(n => n.Id == organizadorId);
        public List<Organizador> GetAllOrganizadores() => _context.Organizadores.ToList();
        */

    }
}
