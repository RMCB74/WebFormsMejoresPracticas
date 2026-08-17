using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using WebFormsSoapService.Models;

namespace WebFormsSoapService.Interfaces
{
    public interface IClienteRepository
    {
        Cliente ObtenerPorId(int id);

        List<Cliente> ObtenerTodos();

        int Crear(Cliente cliente);


        bool Actualizar(Cliente cliente);

        bool Eliminar(int id);

    }
}