using Business.Business.AdminClientes;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnicaJSC.Controllers
{
    public class AdminClienteController : Controller
    {
        private readonly IAdminClientesBusiness _business;

        public AdminClienteController(IAdminClientesBusiness business)
        {
            _business = business;
        }

        public async Task<IActionResult> CrearEditarCliente(int idCliente)
        {
            if (idCliente > default(int))
            {
                 var modelo = await _business.ConsultarClienteId(idCliente);

                return View (modelo);
            }

            return View();
        }
    }
}
