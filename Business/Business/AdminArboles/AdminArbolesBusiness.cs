using Business.Interfaces;
using Business.Models;

namespace Business.Business.AdminArboles
{
    public class AdminArbolesBusiness : IAdminArbolesBusiness
    {
        private readonly IAdminArbolesRepository _repository;

        public AdminArbolesBusiness(IAdminArbolesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ArbolPais>> ConsultarListaPaises()
        {
            return await _repository.ConsultarArbolPais();
        }

        public async Task<IEnumerable<TipoIdentificacion>> ConsultarListaTiposIdentificacion()
        {
            return await _repository.ConsultarTiposIdentificacion();
        }


    }
}
