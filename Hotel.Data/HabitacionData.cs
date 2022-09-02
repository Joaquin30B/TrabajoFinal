using Hotel.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel.Data
{
    public class HabitacionData
    {
        string cadenaConexion = "server=localhost\\SQLEXPRESS; database=Hotel; Integrated Security=true";
        public List<Habitacion> Listar()
        {
            var listado = new List<Habitacion>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Habitacion", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Habitacion Hab;
                            while (lector.Read())
                            {
                                Hab = new Habitacion();
                                Hab.IdHabitacion = int.Parse(lector[0].ToString());
                                Hab.Costo = int.Parse(lector[1].ToString());
                                Hab.Descripcion = lector[2].ToString();
                                listado.Add(Hab);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public Habitacion BuscarPorId(int id)
        {
            var habitacion = new Habitacion();
            return habitacion;
        }

        public bool Insertar()
        {
            return true;
        }
    }
}
