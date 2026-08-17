using System.Collections.Generic;
using WebFormsSoapService.Interfaces;
using WebFormsSoapService.Models;

namespace WebFormsSoapService.Tests.Fakes
{
    public class TipoContactoRepositoryFake : ITipoContactoRepository
    {
        public TipoContacto ObtenerPorId(int id)
        {
            return new TipoContacto
            {
                Id = id,
                Descripcion = "Correo"
            };
        }

        public List<TipoContacto> ObtenerTodos()
        {
            return new List<TipoContacto>
            {
                new TipoContacto
                {
                    Id = 1,
                    Descripcion = "Correo"
                },
                new TipoContacto
                {
                    Id = 2,
                    Descripcion = "Teléfono"
                }
            };
        }

        public int Crear(TipoContacto tipoContacto)
        {
            return 1;
        }

        public bool Actualizar(TipoContacto tipoContacto)
        {
            return true;
        }

        public bool Eliminar(int id)
        {
            return true;
        }
    }
}
