//using System.Collections.Generic;
using WebFormsMejoresPracticas.Models;

namespace WebFormsMejoresPracticas.Services
{
    public interface IContactoService
    {
        //List<Contacto> ObtenerTodos();
        ResultadoLista<Contacto> ObtenerTodos();


        //Contacto ObtenerPorId(int id);
        Resultado<Contacto> ObtenerPorId(int id);

        void Insertar(Contacto contacto);

        void Actualizar(Contacto contacto);

        void Eliminar(int id);
    }
}