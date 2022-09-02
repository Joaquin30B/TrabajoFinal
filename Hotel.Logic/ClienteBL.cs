using Hotel.Data;
using Hotel.Dominio;
using System.Collections.Generic;

namespace Hotel.Logic
{
    public class ClienteBL
    {
        public static List<Cliente> Listar()
        {
            var clienteData = new ClienteData();
            return clienteData.Listar();
        }

        public static Cliente BuscarPorId(int id)
        {
            var clienteData = new ClienteData();
            return clienteData.BuscarPorId(id);
        }

        public static bool Insertar(Cliente cliente)
        {
            var clienteData = new ClienteData();
            return clienteData.Insertar(cliente);
        }

        public static bool Actualizar(Cliente cliente)
        {
            var clienteData = new ClienteData();
            return clienteData.Actualizar(cliente);
        }

        public static bool Eliminar(int nombre)
        {
            var clienteData = new ClienteData();
            return clienteData.Eliminar(nombre);
        }
    }
}
