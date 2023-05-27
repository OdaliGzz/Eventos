using EventosAPI.Entidades;
using EventosAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EventosAPI.Servicios
{
    public class UsuarioServicio
    {
        private ApplicationDbContext _context;
        public UsuarioServicio(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AgregarUsuario(Usuario_VM usuario)
        {
            var _usuario = new Usuario()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo

            };
            _context.Usuarios.Add(_usuario);
            _context.SaveChanges();
        }
        
        public List<Usuario> GetAllUsuarios() => _context.Usuarios.ToList();


        public void DeleteUsuarioById(int id)
        {
            var _usuario = _context.Usuarios.FirstOrDefault(n => n.Id == id);

            if (_usuario != null)//Si no esta vacia la tabla
            {
                _context.Usuarios.Remove(_usuario);
                _context.SaveChanges();
            }
        }

        



    }
}
/*
 public Organizador UpdateOrganizadorById(int organizadorId, OrganizadorUVM organizador)
        {
            var _organizador = _context.Organizadores.FirstOrDefault(n => n.Id == organizadorId);
            if (_organizador != null)
            {
                _organizador.Comentarios = _organizador.Comentarios;
                _context.SaveChanges();


            }
            return _organizador;
        }
 */
//Va en actualizar, Notificado = objeto.Notificado ? objeto.Notificado.Value : null
