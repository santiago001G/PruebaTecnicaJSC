using Business.Models;

namespace Business.Business.AdminArboles
{
    public interface IAdminArbolesBusiness
    {
        Task<IEnumerable<TipoIdentificacion>> ConsultarListaTiposIdentificacion();
    }
}
