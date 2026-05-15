using Microsoft.AspNetCore.Mvc;
using LittleTigerV2.Models;
using LittleTigerV2.Services;

namespace LittleTigerV2.Controllers
{
    public class TigrinhoController : Controller
    {
        private readonly ISorteioService _service;
        public TigrinhoController(ISorteioService service) => _service = service;

        public IActionResult Index() 
        {
            string ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1";
            var modelo = _service.ObterEstadoAtual(ip);
            return View(modelo);
        }

        [HttpPost]
        public IActionResult Girar() 
        {
            string ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1";
    
            _service.RealizarSorteio(ip);

            return RedirectToAction("Index");
        }
    }
}