using EventosAPI.Entidades;
using EventosAPI.Servicios;
using EventosAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventosAPI.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController: ControllerBase
    {
        private UsuarioServicio _usuariosServicio;
        private OrganizadoresServicio _organizadoresServicio;
        public EventosServicio _eventosServicio;

        public UsuarioController(UsuarioServicio usuariosServicio)
        {
            _usuariosServicio = usuariosServicio;
        }

        //Agregar datos del usuario
        [HttpPost("agregar-usuario")]
        public IActionResult AgregarUsuario([FromBody] Usuario_VM usuario)
        {
            _usuariosServicio.AgregarUsuario(usuario);
            return Ok();
        }

        [HttpGet("mostrar-todos-usuarios")]
        public IActionResult GetAllUsuarios()
        {
            var allUsuarios = _usuariosServicio.GetAllUsuarios();
            return Ok(allUsuarios);
        }

       

        [HttpDelete("eliminar-usuario/{id}")]
        public IActionResult DeleteUsuarioById(int id)
        {
            _usuariosServicio.DeleteUsuarioById(id);
            return Ok();
        }



        /*
         * [HttpPut("contactar-organizador/{id}")]
        public IActionResult UpdateOrganizadorById(int id, [FromBody] OrganizadorUVM organizador)
        {
            var updateOrganizador = _usuariosServicio.UpdateOrganizadorById(id, organizador);
            return Ok();
        }

        //Context
        public readonly ApplicationDbContext _context;
        //Constructor
        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Servicios requeridos
        public EventosServicio _eventosServicio;
        public OrganizadoresServicio _organizadoresServicio;
        
        
        //Guardar
        [HttpPost("agregar-usuario")]
        public async Task<ActionResult> Post(Usuario usuario) //Espera un JSON con los atributos que tiene el evento
        {
            _context.Add(usuario); //Guardado hasta el contexto
            await _context.SaveChangesAsync(); //guardar de manera ascincrona
            return Ok();//Sin errores
        }
        //Actualizar
        //string para nombre
        [HttpPut("{id:int}")]
        //Validacion para saber si existe
        public async Task<ActionResult> Put(Usuario usuario, int id)
        {
            if (usuario.Id != id)
            {
                return BadRequest("El id no coincide con el de la URL");
            }

            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Eliminar
        [HttpDelete("{id:int}")]
        //Cualquier id que coincida
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.Usuarios.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No se encontro elemento en la base de datos");
            }
            //Obj a enviar es instancia que solo tenga el valor de id
            _context.Remove(new Usuario() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();

        }

        //Obtener todos los eventos
        [HttpGet("todos-eventos")]
        public IActionResult GetAllEventos()
        {
            var allEventos = _eventosServicio.GetAllEventos();
            return Ok(allEventos);
        }


        /*Obtener organizador por id para mandar comentario
        [HttpGet("lista-organizadores/{id:int}")]
        public IActionResult GetOrganizadorById(int id)
        {
            var organizador = _organizadoresServicio.GetOrganizadorById();
            return Ok(organizador);
        }*/
    }
}
