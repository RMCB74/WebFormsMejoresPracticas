using System;
using System.Collections.Generic;
 
using WebFormsMejoresPracticas.Models;
using WebFormsMejoresPracticas.Repositories;


using WebFormsMejoresPracticas.Exceptions;
using System.Data.SqlClient;

 
namespace WebFormsMejoresPracticas.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException(
                    "El Id del cliente debe ser mayor que cero.",
                    nameof(id));

            return _clienteRepository.ObtenerPorId(id);
        }

        public List<Cliente> ObtenerTodos()
        {
            return _clienteRepository.ObtenerTodos();
        }

        public int Crear(Cliente cliente)
        {
            ValidarCliente(cliente);

            return _clienteRepository.Crear(cliente);
        }

        public void Actualizar(Cliente cliente)
        {
            ValidarCliente(cliente);

            if (cliente.Id <= 0)
                throw new ArgumentException(
                    "El Id del cliente debe ser mayor que cero.",
                    nameof(cliente.Id));

            _clienteRepository.Actualizar(cliente);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException(
                    "El Id del cliente debe ser mayor que cero.",
                    nameof(id));

            try
            {
                _clienteRepository.Eliminar(id);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    throw new ClienteTieneContactosException();
                }

                throw;
            }
        }

        private void ValidarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException(
                    "El nombre del cliente es obligatorio.",
                    nameof(cliente.Nombre));
        }
    }
}