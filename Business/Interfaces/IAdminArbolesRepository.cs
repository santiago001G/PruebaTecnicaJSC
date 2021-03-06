using Business.Models;

namespace Business.Interfaces
{
    public interface IAdminArbolesRepository
    {
        Task<IEnumerable<TipoIdentificacion>> ConsultarTiposIdentificacion();

        Task<IEnumerable<ArbolPais>> ConsultarArbolPais();

        Task<IEnumerable<ArbolDepartamento>> ConsultarDepartamentos(int idPais);

        Task<IEnumerable<ArbolDivision>> ConsultarDivisiones(int idDepartamento);
    }
}
