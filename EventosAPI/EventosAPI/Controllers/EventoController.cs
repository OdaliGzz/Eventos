using EventosAPI.Entidades;
using EventosAPI.Servicios;
using EventosAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventosAPI.Controllers
{
    [ApiController]
    [Route("api/eventos")]
    public class EventoController : ControllerBase
    {
        //Servicio
        public EventosServicio _eventosServicio;
        public EventoController(EventosServicio eventosServicio)
        {
            _eventosServicio = eventosServicio;

        }

        [HttpGet("mostrar-todos-eventos")]
        public IActionResult GetAllEventos()
        {
            var allEventos = _eventosServicio.GetAllEventos();
            return Ok(allEventos);
        }
        

        [HttpGet("mostrar-por-id/{id}")]
        public IActionResult GetEventoById(int id)
        {
            var evento = _eventosServicio.GetEventoById(id);
            return Ok(evento);
        }


        
        [HttpPost("agregar-evento-con-usuarios")]
        public IActionResult AgregarEventoConUsuarios([FromBody] EventoVM evento)
        {
            _eventosServicio.AgregarEventoConUsuarios(evento);
            return Ok();
        }




        /*
         [HttpPost("agregar-evento")]
        public IActionResult AgregarEvento([FromBody] Evento_VM evento)
        {
            _eventosServicio.AgregarEvento(evento);
            return Ok();
        }
        //Context
        public readonly ApplicationDbContext _context;
        //Constructor
        public EventoController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]//Para obtener lista de eventos sin tener una base de datos
        public ActionResult<List<Evento>> Get()
        {
            return new List<Evento>(){
                new Evento {Id = 1, Nombre = "Evento Enero", Descripcion = "Evento de dia", Fecha = DateTime.Now, Ubicacion = "Monterrey", Capacidad = 100},
                new Evento {Id = 2, Nombre = "Evento Febrero", Descripcion = "Evento al aire libre", Fecha = DateTime.Now, Ubicacion = "San Nicolas", Capacidad = 2000}
            };
        }

        

        //Guardar
        [HttpPost("agregar-evento")]
        public async Task<ActionResult> Post(Evento evento) //Espera un JSON con los atributos que tiene el evento
        {
            _context.Add(evento); //Guardado hasta el contexto
            await _context.SaveChangesAsync(); //guardar de manera ascincrona
            return Ok();//Sin errores
        }

        //Obtener todos los eventos
        [HttpGet("lista-eventos")]
        public async Task<ActionResult<List<Evento>>> GetAll()
        {
            return await _context.Eventos.Include(x => x.Usuarios).ToListAsync();
        }
        */

    }
}
