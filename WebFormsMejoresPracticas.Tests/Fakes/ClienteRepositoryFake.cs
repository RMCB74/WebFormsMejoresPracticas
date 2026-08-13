using System.Collections.Generic;
using System.Linq;
using WebFormsMejoresPracticas.Models;
using WebFormsMejoresPracticas.Repositories;

namespace WebFormsMejoresPracticas.Tests.Fakes
{
    public class ClienteRepositoryFake : IClienteRepository
    {
        private readonly List<Cliente> _clientes =
            new List<Cliente>();

        private int _siguienteId = 1;

        public int Crear(Cliente cliente)
        {
            cliente.Id = _siguienteId++;

            _clientes.Add(new Cliente
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre
            });

            return cliente.Id;
        }

        public Cliente ObtenerPorId(int id)
        {
            return _clientes
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Cliente> ObtenerTodos()
        {
            return _clientes.ToList();
        }

        public void Actualizar(Cliente cliente)
        {
            var existente =
                _clientes.FirstOrDefault(x => x.Id == cliente.Id);

            if (existente != null)
            {
                existente.Nombre = cliente.Nombre;
            }
        }

        public void Eliminar(int id)
        {
            var cliente =
                _clientes.FirstOrDefault(x => x.Id == id);

            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
        }
    }
}
