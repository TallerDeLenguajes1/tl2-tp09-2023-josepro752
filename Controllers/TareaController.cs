using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_josepro752.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase {

    private readonly ILogger<TareaController> _logger;
    private ITareaRepository tareaRepository;
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }

    [HttpPost]
    public ActionResult AddUsuario(Tarea tarea) {
        tareaRepository.AddTarea(tarea);
        return Ok();
    }

    [HttpPut("{id}/Nombre/{Nombre}")]
    public ActionResult <Tarea> UpdateTarea(int id, string Nombre) {
        var tarea = tareaRepository.GetTarea(id);
        if (tarea != null) {
            tarea.Nombre = Nombre;
            tareaRepository.UpdateTarea(id,tarea);
        }
        return Ok(tarea);
    }

    [HttpPut("{id}/Estado/{Estado}")]
    public ActionResult <Tarea> UpdateTarea(int id, EstadoTarea Estado) {
        var tarea = tareaRepository.GetTarea(id);
        if (tarea != null) {
            tarea.Estado = Estado;
            tareaRepository.UpdateTarea(id,tarea);
        }
        return Ok(tarea);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteTarea(int id) {
        tareaRepository.DeleteTarea(id);
        return Ok();
    }

    [HttpGet("{estado}")]
    public ActionResult <int> GetAllTareaForEstado(EstadoTarea estado) {
        var tareas = tareaRepository.GetAllTareas().Count(tarea => tarea.Estado == estado);
        return Ok(tareas);
    }

    [HttpGet("Usuario/{id}")]
    public ActionResult <List<Tarea>> GetAllTareaForUsuario(int id) {
        var tareas = tareaRepository.GetAllTareasForUsuario(id);
        return Ok(tareas);
    }
    [HttpGet("Tablero/{id}")]
    public ActionResult <List<Tarea>> GetAllTareaForTablero(int id) {
        var tareas = tareaRepository.GetAllTareasForTablero(id);
        return Ok(tareas);
    }
}