using System.Collections.Generic;
using WebFormsSoapService.Interfaces;
using WebFormsSoapService.Models;



namespace WebFormsSoapService.Tests.Fakes
{
    public class ClienteRepositoryFake : IClienteRepository
    {
        //public Cliente ObtenerPorId(int id)
        //{
        //    return null;
        //}

        public Cliente ObtenerPorId(int id)
        {
            return new Cliente
            {
                Id = id,
                Nombre = "Cliente Fake"
            };
        }
        public List<Cliente> ObtenerTodos()
        {
            return new List<Cliente>();
        }

        public int Crear(Cliente cliente)
        {
            return 1;
        }

        public bool Actualizar(Cliente cliente)
        {
            return true;
        }

        public bool Eliminar(int id)
        {
            return true;
        }
    }
}