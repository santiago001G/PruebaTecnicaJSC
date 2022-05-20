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

        public async Task<IEnumerable<Cliente>> ConsultarClientes()
        {
            return  await _repository.ConsultarClientes();
        }
    }
}
