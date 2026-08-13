using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using WebFormsMejoresPracticas.Models;

namespace WebFormsMejoresPracticas.Repositories
{
    public interface IClienteRepository
    {
        Cliente ObtenerPorId(int id);

        List<Cliente> ObtenerTodos();

        int Crear(Cliente cliente);

        void Actualizar(Cliente cliente);

        void Eliminar(int id);
    }
}
