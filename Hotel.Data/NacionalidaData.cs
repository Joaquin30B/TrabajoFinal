using Hotel.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel.Data
{
    public class NacionalidaData
    {

        string cadenaConexion = "server=localhost\\SQLEXPRESS; database=Hotel; Integrated Security=true";
        public List<Nacionalida> Listar()
        {
            var listado = new List<Nacionalida>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Nacionalida", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Nacionalida Nac;
                            while (lector.Read())
                            {
                                Nac = new Nacionalida();
                                Nac.IdNacionalida = int.Parse(lector[0].ToString());
                                Nac.pais = lector[1].ToString();
                                Nac.nacionalidad = lector[2].ToString();

                                listado.Add(Nac);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public Nacionalida BuscarPorId(int id)
        {
            var nacionalida = new Nacionalida();
            return nacionalida;
        }

        public bool Insertar()
        {
            return true;
        }
    }
}
