using System.Collections.Generic;

using WebFormsSoapService.Models;

namespace WebFormsSoapService.Interfaces
{
    public interface ITipoContactoRepository
    {

        TipoContacto ObtenerPorId(int id);

        List<TipoContacto> ObtenerTodos();

        int Crear(TipoContacto tipoContacto);


        bool Actualizar(TipoContacto tipoContacto);

        bool Eliminar(int id);

    }
     
}
