using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.AdminClientes
{
    public class AdminClientesBusiness : IAdminClientesBusiness
    {
        private readonly IAdminClienteRepository _repository;

        public AdminClientesBusiness(IAdminClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task ActualizarCrearCliente(Cliente cliente)
        {
            await _repository.CrearActualizarCliente(cliente);
        }

        public async Task<Cliente> ConsultarClienteId(int idCliente)
        {
            if (idCliente > default(int))
            {
                return await _repository.ConsultarClienteId(idCliente);
            }

            return new Cliente();
        }

        public async Task<IEnumerable<Cliente>> ConsultarClientes()
        {
            return  await _repository.ConsultarClientes();
        }
    }
}
