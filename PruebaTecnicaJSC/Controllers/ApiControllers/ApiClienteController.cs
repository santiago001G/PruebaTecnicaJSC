using Business.Business.AdminClientes;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnicaJSC.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiClienteController : ControllerBase
    {
        private readonly IAdminClientesBusiness _business;

        public ApiClienteController(IAdminClientesBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            List<Cliente> dataRetorno = new List<Cliente>();
            var clientesConsultados = await _business.ConsultarClientes();

            dataRetorno.AddRange(clientesConsultados);

            return dataRetorno;
        }

    }
}
