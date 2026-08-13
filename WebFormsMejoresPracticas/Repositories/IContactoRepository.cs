using System.Collections.Generic;
using WebFormsMejoresPracticas.Models;

namespace WebFormsMejoresPracticas.Repositories
{
    public interface IContactoRepository
    {
        List<Contacto> ObtenerTodos();

        Contacto ObtenerPorId(int id);

        void Insertar(Contacto contacto);

        void Actualizar(Contacto contacto);

        void Eliminar(int id);
    }
}