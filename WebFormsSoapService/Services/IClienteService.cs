using System.Collections.Generic;
using WebFormsSoapService.Models;
 


namespace WebFormsSoapService.Services
{
    public interface IClienteService
    {
        Cliente ObtenerPorId(int id);

        List<Cliente> ObtenerTodos();


        int Crear(Cliente cliente);

        bool Actualizar(Cliente cliente);

        bool Eliminar(int id);
    }

 
}
 