using System;
using System.Collections.Generic;

using WebFormsMejoresPracticas.Models;
using WebFormsMejoresPracticas.Repositories;

namespace WebFormsMejoresPracticas.Services
{
    public class TipoContactoService : ITipoContactoService
    {
        private readonly ITipoContactoRepository _tipoContactoRepository;

        public TipoContactoService(
            ITipoContactoRepository tipoContactoRepository)
        {
            _tipoContactoRepository = tipoContactoRepository;
        }

        public TipoContacto ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException(
                    "El Id del tipo de contacto debe ser mayor que cero.",
                    nameof(id));

            return _tipoContactoRepository.ObtenerPorId(id);
        }

        public List<TipoContacto> ObtenerTodos()
        {
            return _tipoContactoRepository.ObtenerTodos();
        }

        public int Crear(TipoContacto tipoContacto)
        {
            ValidarTipoContacto(tipoContacto);

            return _tipoContactoRepository.Crear(tipoContacto);
        }

        public void Actualizar(TipoContacto tipoContacto)
        {
            ValidarTipoContacto(tipoContacto);

            if (tipoContacto.Id <= 0)
                throw new ArgumentException(
                    "El Id del tipo de contacto debe ser mayor que cero.",
                    nameof(tipoContacto.Id));

            _tipoContactoRepository.Actualizar(tipoContacto);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException(
                    "El Id del tipo de contacto debe ser mayor que cero.",
                    nameof(id));

            _tipoContactoRepository.Eliminar(id);
        }

        private void ValidarTipoContacto(TipoContacto tipoContacto)
        {
            if (tipoContacto == null)
                throw new ArgumentNullException(nameof(tipoContacto));

            if (string.IsNullOrWhiteSpace(tipoContacto.Descripcion))
                throw new ArgumentException(
                    "La descripción del tipo de contacto es obligatoria.",
                    nameof(tipoContacto.Descripcion));

            if (tipoContacto.Descripcion.Length > 50)
                throw new ArgumentException(
                    "La descripción del tipo de contacto no puede superar los 50 caracteres.",
                    nameof(tipoContacto.Descripcion));
        }
    }
}