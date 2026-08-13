using System.Collections.Generic;
using WebFormsMejoresPracticas.Models;

namespace WebFormsMejoresPracticas.Repositories
{
    public interface ITipoContactoRepository
    {
        TipoContacto ObtenerPorId(int id);

        List<TipoContacto> ObtenerTodos();

        int Crear(TipoContacto tipoContacto);

        void Actualizar(TipoContacto tipoContacto);

        void Eliminar(int id);
    }
}