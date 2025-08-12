using Microsoft.AspNetCore.Mvc;
using Salvation.Interfaces;

namespace Salvation.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
