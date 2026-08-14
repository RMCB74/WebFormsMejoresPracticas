 
using System.Collections.Generic;
 
 
using WebFormsMejoresPracticas.Models;

namespace WebFormsMejoresPracticas.Services
{
    public interface IClienteService
    {
        //Cliente ObtenerPorId(int id);
        Resultado<Cliente> ObtenerPorId(int id);

        //List<Cliente> ObtenerTodos();
        ResultadoLista<Cliente> ObtenerTodos();

        int Crear(Cliente cliente);

        void Actualizar(Cliente cliente);

        void Eliminar(int id);
    }
}