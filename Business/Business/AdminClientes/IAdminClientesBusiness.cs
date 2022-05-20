using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.AdminClientes
{
    public interface IAdminClientesBusiness
    {
        Task<IEnumerable<Cliente>> ConsultarClientes();
    }
}
