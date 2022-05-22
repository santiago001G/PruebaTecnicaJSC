﻿using Business.Models;

namespace Business.Interfaces
{
    public interface IAdminArbolesRepository
    {
        Task<IEnumerable<TipoIdentificacion>> ConsultarTiposIdentificacion();
    }
}
