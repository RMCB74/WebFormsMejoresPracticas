using System.Collections.Generic;
using WebFormsSoapService.Models;

namespace WebFormsSoapService.Interfaces
{
    public interface IContactoRepository
    {

        Contacto ObtenerPorId(int id);

        List<Contacto> ObtenerTodos();

        List<Contacto> ObtenerPorCliente(int clienteId);

        int Crear(Contacto contacto);


        bool Actualizar(Contacto contacto);

        bool Eliminar(int id);


    }
}
