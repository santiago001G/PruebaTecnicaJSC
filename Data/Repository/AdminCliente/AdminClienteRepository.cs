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
    }
}
