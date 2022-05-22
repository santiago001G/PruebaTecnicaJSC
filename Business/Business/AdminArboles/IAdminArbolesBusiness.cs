using Business.Models;

namespace Business.Business.AdminArboles
{
    public interface IAdminArbolesBusiness
    {
        Task<IEnumerable<TipoIdentificacion>> ConsultarListaTiposIdentificacion();
        Task<IEnumerable<ArbolPais>> ConsultarListaPaises();
        Task<IEnumerable<ArbolDepartamento>> ConsultarListaDepartamentos(int idPais);
        Task<IEnumerable<ArbolDivision>> ConsultarListaDivisiones(int idDepartamento);
    }
}
