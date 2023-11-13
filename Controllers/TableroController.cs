using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_josepro752.Controllers;

[ApiController]
[Route("[api/controller]")]
public class TableroController : ControllerBase {

    private readonly ILogger<UsuarioController> _logger;
    private ITableroRepository tableroRepository;
    public TableroController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }

    [HttpPost]
    public ActionResult AddTablero(Tablero tablero) {
        tableroRepository.AddTablero(tablero);
        return Ok();
    }

    [HttpGet]
    public ActionResult <List<Tablero>> GetAllTablero() {
        var tableros = tableroRepository.GetAllTableros();
        return Ok(tableros);
    }
}