using System.Collections.Generic;
using WebFormsMejoresPracticas.Models;

namespace WebFormsMejoresPracticas.Services
{
    public interface ITipoContactoService
    {
        //TipoContacto ObtenerPorId(int id);

        Resultado<TipoContacto> ObtenerPorId(int id);

        // List<TipoContacto> ObtenerTodos();
        ResultadoLista<TipoContacto> ObtenerTodos();

        int Crear(TipoContacto tipoContacto);

        void Actualizar(TipoContacto tipoContacto);

        void Eliminar(int id);
    }
}