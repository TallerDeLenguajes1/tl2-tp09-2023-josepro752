using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_josepro752.Controllers;

[ApiController]
[Route("[api/controller]")]
public class UsuarioController : ControllerBase {

    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository usuarioRepository;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    [HttpPost]
    public ActionResult AddUsuario(Usuario usuario) {
        usuarioRepository.AddUsuario(usuario);
        return Ok();
    }

    [HttpGet]
    public ActionResult <List<Usuario>> GetAllUsuarios() {
        var usuarios = usuarioRepository.GetAllUsuarios();
        return Ok(usuarios);
    }

    [HttpGet("/{id}")]
    public ActionResult <Usuario> GetUsuario(int id) {
        var usuario = usuarioRepository.GetUsuario(id);
        return Ok(usuario);
    }
    [HttpPut("/{id}/Nombre")]
    public ActionResult UpdateUsuario(int id, Usuario usuario) {
        usuarioRepository.UpdateUsuario(id,usuario);
        return Ok();
    }
}