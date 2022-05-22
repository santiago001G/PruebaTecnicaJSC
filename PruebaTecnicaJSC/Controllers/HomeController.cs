using Business.Business.AdminClientes;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaJSC.Models;
using System.Diagnostics;

namespace PruebaTecnicaJSC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdminClientesBusiness _business;

        public HomeController(ILogger<HomeController> logger, IAdminClientesBusiness business)
        {
            _logger = logger;
            _business = business;
        }

        public async Task<IActionResult> Index()
        {
            var listaClientes = await _business.ConsultarClientes();

            return View(listaClientes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}