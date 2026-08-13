using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebFormsMejoresPracticas.Models;
using WebFormsMejoresPracticas.Repositories;

namespace WebFormsMejoresPracticas.Services
{
    public class ContactoService : IContactoService
    {
        private readonly IContactoRepository _contactoRepository;
        private readonly ILogger<ContactoService> _logger;

        public ContactoService(
            IContactoRepository contactoRepository,
            ILogger<ContactoService> logger)
        {
            _contactoRepository = contactoRepository;
            _logger = logger;
        }

        public List<Contacto> ObtenerTodos()
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando consulta de contactos.");

                return _contactoRepository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al obtener los contactos.");

                throw;
            }
        }

        public Contacto ObtenerPorId(int id)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando consulta de contacto. Id: {ContactoId}",
                    id);

                return _contactoRepository.ObtenerPorId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al obtener contacto. Id: {ContactoId}",
                    id);

                throw;
            }
        }

        public void Insertar(Contacto contacto)
        {
            try
            {
                _logger.LogInformation(
                    "Iniciando validación creación de contacto.");

                if (contacto == null)
                    throw new ArgumentNullException(nameof(contacto));

                if (contacto.ClienteId <= 0)
                    throw new ArgumentException(
                        "Debe seleccionar un cliente.");

                if (contacto.TipoContactoId <= 0)
                    throw new ArgumentException(
                        "Debe seleccionar un tipo de contacto.");

                if (string.IsNullOrWhiteSpace(contacto.Valor))
                    throw new ArgumentException(
                        "El valor del contacto es obligatorio.");

                _logger.LogInformation(
                 "Iniciando creación de contacto.");


                _contactoRepository.Insertar(contacto);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al crear contacto.");

                throw;
            }
        }

        public void Actualizar(Contacto contacto)
        {
            try
            {

                _logger.LogInformation(
                    "Iniciando v alidación actualización de contacto. Id: {ContactoId}",
                    contacto.Id);


                if (contacto == null)
                    throw new ArgumentNullException(nameof(contacto));

                if (contacto.Id <= 0)
                    throw new ArgumentException(
                        "El contacto no es válido.");

                if (contacto.ClienteId <= 0)
                    throw new ArgumentException(
                        "Debe seleccionar un cliente.");

                if (contacto.TipoContactoId <= 0)
                    throw new ArgumentException(
                        "Debe seleccionar un tipo de contacto.");

                if (string.IsNullOrWhiteSpace(contacto.Valor))
                    throw new ArgumentException(
                        "El valor del contacto es obligatorio.");

                _logger.LogInformation(
                    "Iniciando actualización de contacto. Id: {ContactoId}",
                    contacto.Id);

                _contactoRepository.Actualizar(contacto);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al actualizar contacto. Id: {ContactoId}",
                    contacto?.Id);

                throw;
            }
        }

        //public void Eliminar(int id)
        //{
        //    try
        //    {
        //        _logger.LogInformation(
        //            "Iniciando eliminación de contacto. Id: {ContactoId}",
        //            id);

        //        _contactoRepository.Eliminar(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(
        //            ex,
        //            "Error al eliminar contacto. Id: {ContactoId}",
        //            id);

        //        throw;
        //    }
        //}

        public void Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException(
                        "El Id del contacto no es válido.");

                _logger.LogInformation(
                    "Iniciando eliminación de contacto. Id: {ContactoId}",
                    id);

                _contactoRepository.Eliminar(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al eliminar contacto. Id: {ContactoId}",
                    id);

                throw;
            }
        }

    }
}