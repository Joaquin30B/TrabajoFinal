using Hotel.Data;
using Hotel.Dominio;
using System.Collections.Generic;

namespace Hotel.Logic
{
    public class HabitacionBLcs
    {
        public static List<Habitacion> Listar()
        {
            var habitacionData = new HabitacionData();
            return habitacionData.Listar();
        }
    }
}
