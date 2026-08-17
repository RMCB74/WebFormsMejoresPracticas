using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsSoapService.Interfaces;
using WebFormsSoapService.Models;

namespace WebFormsSoapService.Services
{
    public class ContactoServiceImpl : IContactoService
    {
        private readonly IContactoRepository _contactoRepository;

        public ContactoServiceImpl(
            IContactoRepository contactoRepository)
        {
            _contactoRepository = contactoRepository;
        }

        public ContactoDto ObtenerPorId(int id)
        {
            var contacto = _contactoRepository.ObtenerPorId(id);

            if (contacto == null)
                return null;

            return ConvertirDto(contacto);
        }

        public List<ContactoDto> ObtenerTodos()
        {
            var contactos = _contactoRepository.ObtenerTodos();

            return contactos
                .Select(ConvertirDto)
                .ToList();
        }

        public List<ContactoDto> ObtenerPorCliente(int clienteId)
        {
            var contactos =
                _contactoRepository.ObtenerPorCliente(clienteId);

            return contactos
                .Select(ConvertirDto)
                .ToList();
        }

        public int Crear(Contacto contacto)
        {
            ValidarContacto(contacto);

            return _contactoRepository.Crear(contacto);
        }
        public bool Actualizar(Contacto contacto)
        {
            ValidarContacto(contacto);

            if (contacto.Id <= 0)
                throw new ArgumentException("El Id del contacto es obligatorio.");

            return _contactoRepository.Actualizar(contacto);
        }

        public bool Eliminar(int id)
        {
            return _contactoRepository.Eliminar(id);
        }

        private ContactoDto ConvertirDto(Contacto contacto)
        {
            return new ContactoDto
            {
                Id = contacto.Id,
                ClienteId = contacto.ClienteId,
                TipoContactoId = contacto.TipoContactoId,
                Valor = contacto.Valor,

                ClienteNombre =
                    contacto.Cliente != null
                        ? contacto.Cliente.Nombre
                        : null,

                TipoContactoDescripcion =
                    contacto.TipoContacto != null
                        ? contacto.TipoContacto.Descripcion
                        : null
            };
        }
        private void ValidarContacto(Contacto contacto)
        {
            if (contacto == null)
                throw new ArgumentException("El contacto es obligatorio.");

            if (contacto.ClienteId <= 0)
                throw new ArgumentException("El ClienteId es obligatorio.");

            if (contacto.TipoContactoId <= 0)
                throw new ArgumentException("El TipoContactoId es obligatorio.");

            if (string.IsNullOrWhiteSpace(contacto.Valor))
                throw new ArgumentException("El valor del contacto es obligatorio.");
        }



    }
}