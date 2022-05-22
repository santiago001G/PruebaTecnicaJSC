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
        public async Task<ActionResult<Cliente>> Get(int idCliente)
        {
            var clienteConsultados = await _business.ConsultarClienteId(idCliente);

            return clienteConsultados;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Post(Cliente cliente)
        {
            if (cliente.Id==default(int))
            {
                await _business.ActualizarCrearCliente(cliente);

                return Ok();
            }

            return Problem();
        }

        [HttpPut]
        public async Task<ActionResult<Cliente>> Put(Cliente cliente)
        {
            if (cliente.Id > default(int))
            {
                await _business.ActualizarCrearCliente(cliente);

                return Ok();
            }
            return Problem();
        }

    }
}
