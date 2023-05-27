using EventosAPI.Entidades;
using EventosAPI.Servicios;
using EventosAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventosAPI.Controllers
{
    [ApiController]
    [Route("api/organizadores")]
    public class OrganizadorController: ControllerBase
    {
        public OrganizadoresServicio _organizadoresServicio;
        public EventosServicio _eventosServicio;
        public OrganizadorController(OrganizadoresServicio organizadoresServicio)
        {
            _organizadoresServicio = organizadoresServicio;

        }
        [HttpPost("agregar-organizador")]
        public IActionResult AgregarOrganizador([FromBody] OrganizadorVM organizador)
        {
            _organizadoresServicio.AgregarOrganizador(organizador);
            return Ok();
        }
        [HttpGet("mostrar-todos-organizadores")]
        public IActionResult GetAllOrganizadores()
        {
            var allOrganizadores = _organizadoresServicio.GetAllOrganizadores();
            return Ok(allOrganizadores);
        }

        [HttpGet("mostrar-eventos-y-usuarios/{id}")]
        public IActionResult GetOrganizadorData(int id)
        {
            var _response = _organizadoresServicio.GetOrganizadorData(id);
            return Ok(_response);
        }
        [HttpGet("mostrar-usuarios-con-eventos/{id}")]
        public IActionResult GetUsuarioConEventos(int id)
        {
            var response = _organizadoresServicio.GetUsuarioConEventos(id);
            return Ok(response);
        }

        [HttpDelete("eliminar-organizador/{id}")]
        public IActionResult DeleteOrganizadorById(int id)
        {
            _organizadoresServicio.DeleteOrganizadorById(id);
            return Ok();
        }

        [HttpGet("mostrar-por-id/{id}")]
        public IActionResult GetOrganizadorById(int id)
        {
            var organizador = _organizadoresServicio.GetOrganizadorById(id);
            return Ok(organizador);
        }

        [HttpPut("actualizar-evento/{id}")]
        public IActionResult UpdateEventoById(int id, [FromBody] EventoVM evento)
        {
            var updateEvento = _organizadoresServicio.UpdateEventoById(id, evento);
            return Ok();
        }

        [HttpDelete("eliminar-evento/{id}")]
        public IActionResult DeleteEventoById(int id)
        {
            _organizadoresServicio.DeleteEventoById(id);
            return Ok();
        }


        /*
         * [HttpPut("contactar-usuario/{id}")]
        public IActionResult UpdateUsuarioById(int id, [FromBody] UsuarioVM usuario)
        {
            var updateUsuario = _organizadoresServicio.UpdateUsuarioById(id, usuario);
            return Ok();
        }

        //Context
        public readonly ApplicationDbContext _context;
        //Constructor
        public OrganizadorController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Servicio
        
        

        //Guardar
        [HttpPost("agregar-organizador")]
        public async Task<ActionResult> Post(Organizador organizador) //Espera un JSON con los atributos que tiene el evento
        {
            _context.Add(organizador); //Guardado hasta el contexto
            await _context.SaveChangesAsync(); //guardar de manera ascincrona
            return Ok();//Sin errores
        }

        //Obtener todos los eventos                             Include(x => x.Usuarios).ToListAsync();
        [HttpGet("lista-organizadores")]
        public async Task<ActionResult<List<Organizador>>> GetAll()
        {
            return await _context.Organizadores.ToListAsync();
        }


        //Actualizar
        //string para nombre
        [HttpPut("{id:int}")]
        //Validacion para saber si existe
        public async Task<ActionResult> Put(Evento evento, int id)
        {
            if (evento.Id != id)
            {
                return BadRequest("El id no coincide con el de la URL");
            }

            _context.Update(evento);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Eliminar
        [HttpDelete("{id:int}")]
        //Cualquier id que coincida
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.Eventos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No se encontro elemento en la base de datos");
            }
            //Obj a enviar es instancia que solo tenga el valor de id
            _context.Remove(new Evento() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();

        }*/
    }
}
