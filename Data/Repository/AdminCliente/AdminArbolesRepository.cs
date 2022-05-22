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

        public async Task<IEnumerable<ArbolDepartamento>> ConsultarDepartamentos(int idPais)
        {
            List<ArbolDepartamento> arbolDepartamentos = new List<ArbolDepartamento>();

            try
            {
                SqlCommand command = new SqlCommand("pr_consultar_arbol_departamento", _db.ObtenerConexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parametroId = new SqlParameter
                {
                    ParameterName = "@DptColPaisCodigo",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = idPais,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(parametroId);

                using (var lector = await command.ExecuteReaderAsync())
                {
                    while (await lector.ReadAsync())
                    {
                        arbolDepartamentos.Add(new ArbolDepartamento()
                        {
                            DptColCodigo = (int)lector["DptColCodigo"],
                            DptColCodigoDane = (int)lector["DptColCodigoDane"],
                            DptColNombredelDepartamento =(string)lector["DptColNombredelDepartamento"],
                            DptColPaisCodigo = (short)lector["DptColPaisCodigo"]
                        });
                    }

                    return arbolDepartamentos;
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

        public async Task<IEnumerable<ArbolDivision>> ConsultarDivisiones(int idDepartamento)
        {
            List<ArbolDivision> arbolDivision = new List<ArbolDivision>();

            try
            {
                SqlCommand command = new SqlCommand("pr_consultar_arbol_division", _db.ObtenerConexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parametroId = new SqlParameter
                {
                    ParameterName = "@DvsPltColDptColCodigoDane",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = idDepartamento,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(parametroId);

                using (var lector = await command.ExecuteReaderAsync())
                {
                    while (await lector.ReadAsync())
                    {
                        arbolDivision.Add(new ArbolDivision()
                        {
                            DvsPltColCodigo = (int)lector["DvsPltColCodigo"],
                            DvsPltColCodigoDane = (int)lector["DvsPltColCodigoDane"],
                            DvsPltColNombreMunicipio = (string)lector["DvsPltColNombreMunicipio"],
                            DvsPltColDepartamento = (string)lector["DvsPltColDepartamento"],
                            DvsPltColDptColCodigoDane = (int)lector["DvsPltColDptColCodigoDane"],
                        });
                    }

                    return arbolDivision;
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
