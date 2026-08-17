using System.Collections.Generic;
using WebFormsSoapService.Models;

namespace WebFormsSoapService.Services
{
    public interface IContactoService
    {
        ContactoDto ObtenerPorId(int id);

        List<ContactoDto> ObtenerTodos();

        List<ContactoDto> ObtenerPorCliente(int clienteId);

        int Crear(Contacto contacto);

        bool Actualizar(Contacto contacto);

        bool Eliminar(int id);
    }
}