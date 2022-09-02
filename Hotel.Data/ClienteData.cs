using Hotel.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel.Data
{
    public class ClienteData
    {
        string cadenaConexion = "server=localhost\\SQLEXPRESS; Database=Hotel; Integrated Security = true";
        public List<Cliente> Listar()
        {
            var listado = new List<Cliente>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand(" SELECT * FROM Cliente " , conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Cliente cliente;
                            while (lector.Read())
                            {
                                cliente = new Cliente();
                                cliente.IdCliente = int.Parse(lector[0].ToString());
                                cliente.Nombre = lector[1].ToString();
                                cliente.Direccion = lector[2].ToString();
                                cliente.DNI = int.Parse(lector[3].ToString());
                                cliente.Telefono = lector[4].ToString();

                                listado.Add(cliente);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public Cliente BuscarPorId(int id)
        {
            Cliente cliente = new Cliente();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand(" SELECT * FROM Cliente WHERE IdCliente = @IdCliente ", conexion))
                {
                    comando.Parameters.AddWithValue("@IdCliente", id);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            lector.Read();
                            cliente.IdCliente = int.Parse(lector[0].ToString());
                            cliente.Nombre = lector[1].ToString();
                            cliente.Direccion = lector[2].ToString();
                            cliente.DNI = int.Parse(lector[3].ToString());
                            cliente.Telefono = lector[4].ToString();


                        }
                    }
                }
            }
            return cliente;
        }

        public bool Insertar(Cliente cliente)
        {
            int filasInsertadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = " INSERT INTO Cliente(Nombre,Direccion,DNI,Telefono) " +
                    " VALUES(@Nombre,@Direccion,@DNI,@Telefono) ";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    comando.Parameters.AddWithValue("@DNI", cliente.DNI);
                    comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                    filasInsertadas = comando.ExecuteNonQuery();

                }
            }
            return filasInsertadas > 0;
        }

        public bool Actualizar(Cliente cliente)
        {
            int filasActualizadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = " UPDATE Cliente SET Nombre = @Nombre, Direccion = @Direccion," +
                    " DNI = @DNI ,Telefono = @Telefono " +
                    " WHERE IdCliente = @IdCliente ";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    comando.Parameters.AddWithValue("@DNI", cliente.DNI);
                    comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    comando.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);

                    filasActualizadas = comando.ExecuteNonQuery();
                }
            }
            return filasActualizadas > 0;
        }

        public bool Eliminar(int id)
        {
            int filasEiminadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = " DELETE FROM Cliente WHERE IdCliente = @IdCliente ";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@IdCliente", id);
                    filasEiminadas = comando.ExecuteNonQuery();
                }
            }
            return filasEiminadas > 0;
        }




    }
}
