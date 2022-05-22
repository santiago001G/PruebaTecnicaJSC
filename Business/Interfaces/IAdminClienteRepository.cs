using Business.Models;

namespace Business.Interfaces
{
    public interface IAdminClienteRepository
    {
        Task<IEnumerable<Cliente>> ConsultarClientes();

        Task<Cliente> ConsultarClienteId(int idCliente);

        Task CrearActualizarCliente(Cliente cliente);
    }
}
