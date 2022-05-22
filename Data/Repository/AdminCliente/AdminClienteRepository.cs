using Business.Interfaces;
using Business.Models;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.AdminCliente
{
    public class AdminClienteRepository : IAdminClienteRepository
    {
        private readonly IPruebaDatabase _db;

        public AdminClienteRepository(IPruebaDatabase db)
        {
            _db = db;
        }

        public async Task<Cliente> ConsultarClienteId(int idCliente)
        {
            Cliente clienteConsultado = new Cliente();

            try
            {
                SqlCommand command = new SqlCommand("pr_consultar_cliente_id", _db.ObtenerConexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parametroId = new SqlParameter
                {
                    ParameterName = "@IdCliente",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = idCliente,
                    Direction = System.Data.ParameterDirection.Input
                };

                command.Parameters.Add(parametroId);

                using (var lector = await command.ExecuteReaderAsync())
                {
                    while (await lector.ReadAsync())
                    {
                        clienteConsultado = new Cliente()
                        {
                            Id = (int)lector["Clnid"],
                            TipoIdentificacion = (short)lector["ClnTpoIdnId"],
                            NumeroIdentificacion = (string)lector["ClNumeroIdentificacion"],
                            RazonSocial = (string)lector["ClRazonSocial"],
                            PaisCodigo = (short)lector["ClPaisCodigo"],
                            DepartamentoCodigo = (int)lector["ClDptColCodigoDane"],
                            MunicipioCodigo = (int)lector["ClDvsPltColCodigoDane"],
                            NombreTipoIdentificacion = (string)lector["TpoIdnNombre"],
                            Pais = (string)lector["PaisNombre"],
                            Departamento = (string)lector["DptColNombredelDepartamento"],
                            Municipio = (string)lector["DvsPltColNombreMunicipio"]
                        };
                    }
                }

                return clienteConsultado;
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

        public async Task<IEnumerable<Cliente>> ConsultarClientes()
        {
            List<Cliente> clientesConsultados = new List<Cliente>();

            try
            {
                SqlCommand command = new SqlCommand("pr_consultar_clientes_detalle", _db.ObtenerConexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (var lector = await command.ExecuteReaderAsync())
                {
                    while (await lector.ReadAsync())
                    {
                        clientesConsultados.Add(new Cliente()
                        {
                            Id = (int)lector["Clnid"],
                            TipoIdentificacion = (short)lector["ClnTpoIdnId"],
                            NumeroIdentificacion = (string)lector["ClNumeroIdentificacion"],
                            RazonSocial = (string)lector["ClRazonSocial"],
                            PaisCodigo = (short)lector["ClPaisCodigo"],
                            DepartamentoCodigo = (int)lector["ClDptColCodigoDane"],
                            MunicipioCodigo = (int)lector["ClDvsPltColCodigoDane"],
                            NombreTipoIdentificacion = (string)lector["TpoIdnNombre"],
                            Pais = (string)lector["PaisNombre"],
                            Departamento = (string)lector["DptColNombredelDepartamento"],
                            Municipio = (string)lector["DvsPltColNombreMunicipio"]
                        });
                    }

                    return clientesConsultados;
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

        public async Task CrearActualizarCliente(Cliente cliente)
        {
            try
            {
                SqlCommand command = new SqlCommand("pr_registrar_actualizar_cliente", _db.ObtenerConexion());
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var parametros = parametrosInsercionCliente(cliente);

                command.Parameters.AddRange(parametros.ToArray());
                await command.ExecuteReaderAsync();
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

        private List<SqlParameter> parametrosInsercionCliente(Cliente cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@idCliente",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.Id,
                    Direction = System.Data.ParameterDirection.Input
                },
                new SqlParameter()
                {
                    ParameterName = "@tipoIdentificacion",
                    SqlDbType = System.Data.SqlDbType.SmallInt,
                    Value = cliente.TipoIdentificacion,
                    Direction = System.Data.ParameterDirection.Input
                },
                new SqlParameter()
                {
                    ParameterName = "@numeroIdentificacion",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 30,
                    Value = cliente.NumeroIdentificacion,
                    Direction = System.Data.ParameterDirection.Input
                },
                new SqlParameter()
                {
                    ParameterName = "@razonSocial",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.RazonSocial,
                    Size = 150,
                    Direction = System.Data.ParameterDirection.Input
                },
                new SqlParameter()
                {
                    ParameterName = "@codigoPais",
                    SqlDbType = System.Data.SqlDbType.SmallInt,
                    Value = cliente.PaisCodigo,
                    Direction = System.Data.ParameterDirection.Input
                },
                new SqlParameter()
                {
                    ParameterName = "@codigoDepartamento",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.DepartamentoCodigo,
                    Direction = System.Data.ParameterDirection.Input
                },
                 new SqlParameter()
                {
                    ParameterName = "@codigoDivision",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.MunicipioCodigo,
                    Direction = System.Data.ParameterDirection.Input
                }
            };

            return parametros;
        }
    }
}
