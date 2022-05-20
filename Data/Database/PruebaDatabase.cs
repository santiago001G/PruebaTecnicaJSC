using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class PruebaDatabase : IPruebaDatabase
    {
        private string _cadenaConexion;
        private SqlConnection conexion;

        public PruebaDatabase(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public SqlConnection ObtenerConexion()
        {
            try
            {
                conexion = new SqlConnection(_cadenaConexion);
                conexion.Open();

                return conexion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            conexion.Close();
        }
    }
}
