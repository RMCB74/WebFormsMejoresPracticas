using System;


using System.Collections.Generic;
using WebFormsSoapService.Interfaces;
using WebFormsSoapService.Models;

namespace WebFormsSoapService.Services
{
    public class TipoContactoServiceImpl : ITipoContactoService
    {
        private readonly ITipoContactoRepository _tipoContactoRepository;

        public TipoContactoServiceImpl(
            ITipoContactoRepository tipoContactoRepository)
        {
            _tipoContactoRepository = tipoContactoRepository;
        }

        public TipoContacto ObtenerPorId(int id)
        {
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

        public bool Actualizar(TipoContacto tipoContacto)
        {
            ValidarTipoContacto(tipoContacto);

            return _tipoContactoRepository.Actualizar(tipoContacto);
        }

        public bool Eliminar(int id)
        {
            return _tipoContactoRepository.Eliminar(id);
        }

        private void ValidarTipoContacto(TipoContacto tipoContacto)
        {
            if (tipoContacto == null)
                throw new ArgumentException("El tipo de contacto es obligatorio.");

            if (string.IsNullOrWhiteSpace(tipoContacto.Descripcion))
                throw new ArgumentException("La descripción del tipo de contacto es obligatoria.");
        }



    }
}