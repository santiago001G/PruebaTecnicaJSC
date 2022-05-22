using Business.Interfaces;
using Business.Models;
using Data.Database;
using System.Data.SqlClient;

namespace Data.Repository.AdminCliente
{
    public class AdminArbolesRepository : IAdminArbolesRepository
    {
        private readonly IPruebaDatabase _db;

        public AdminArbolesRepository(IPruebaDatabase db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ArbolPais>> ConsultarArbolPais()
        {
            List<ArbolPais> tiposIdentificacion = new List<ArbolPais>();

            try
            {
                SqlCommand command = new SqlCommand("pr_consultar_arbol_pais", _db.ObtenerConexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (var lector = await command.ExecuteReaderAsync())
                {
                    while (await lector.ReadAsync())
                    {
                        tiposIdentificacion.Add(new ArbolPais()
                        {
                            Id = (short)lector["PaisCodigo"],
                            PaisIso = (string)lector["PaisIso1"],
                            PaisNombre = (string)lector["PaisNombre"],
                        });
                    }

                    return tiposIdentificacion;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _db.Dispose();
            }
        }

        public async Task<IEnumerable<TipoIdentificacion>> ConsultarTiposIdentificacion()
        {
            List<TipoIdentificacion> tiposIdentificacion = new List<TipoIdentificacion>();

            try
            {
                SqlCommand command = new SqlCommand("pr_consultar_tipos_identificacion", _db.ObtenerConexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (var lector = await command.ExecuteReaderAsync())
                {
                    while (await lector.ReadAsync())
                    {
                        tiposIdentificacion.Add(new TipoIdentificacion()
                        {
                            TipoIdnId = (short)lector["TpoIdnId"],
                            TipoIdnNombre = (string)lector["TpoIdnNombre"],
                            TipoIdnDescripcion = (string)lector["TpoIdnDescripcion"],
                            TipoIdnCodigo = (string)lector["TpoIdnCodigo"],
                            TipoIdnPaisCodigo = (short)lector["TpoIdnPaisCodigo"]
                        });
                    }

                    return tiposIdentificacion;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _db.Dispose();
            }
        }
    }
}
