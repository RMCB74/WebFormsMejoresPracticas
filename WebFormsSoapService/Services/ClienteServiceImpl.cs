using System.Collections.Generic;
using WebFormsSoapService.Interfaces;
using WebFormsSoapService.Models;

namespace WebFormsSoapService.Services
{
    public class ClienteServiceImpl : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServiceImpl(
            IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente ObtenerPorId(int id)
        {
            return _clienteRepository.ObtenerPorId(id);
        }

        public List<Cliente> ObtenerTodos()
        {
            return _clienteRepository.ObtenerTodos();
        }

        public int Crear(Cliente cliente)
        {
            return _clienteRepository.Crear(cliente);
        }


        public bool Actualizar(Cliente cliente)
        {
            return _clienteRepository.Actualizar(cliente);
        }


        public bool Eliminar(int id)
        {
            return _clienteRepository.Eliminar(id);
        }


    }
}