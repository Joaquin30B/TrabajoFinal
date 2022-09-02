using Hotel.Data;
using Hotel.Dominio;
using System.Collections.Generic;

namespace Hotel.Logic
{
    public class NacinalidaBL
    {
        public static List<Nacionalida> Listar()
        {
            var nacionalidaData = new NacionalidaData();
            return nacionalidaData.Listar();
        }
    }
}
