using System.Collections.Generic;
using System.Linq;
using WebFormsSoapService.Data;
using WebFormsSoapService.Interfaces;
using WebFormsSoapService.Models;

namespace WebFormsSoapService.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        public Cliente ObtenerPorId(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Clientes
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Cliente> ObtenerTodos()
        {
            using (var context = new AppDbContext())
            {
                return context.Clientes
                    .OrderBy(x => x.Nombre)
                    .ToList();
            }
        }

        public int Crear(Cliente cliente)
        {
            using (var context = new AppDbContext())
            {
                context.Clientes.Add(cliente);

                context.SaveChanges();

                return cliente.Id;
            }
        }

        public bool Actualizar(Cliente cliente)
        {
            using (var context = new AppDbContext())
            {
                var clienteExistente = context.Clientes
                    .FirstOrDefault(x => x.Id == cliente.Id);

                if (clienteExistente == null)
                    return false;

                clienteExistente.Nombre = cliente.Nombre;

                context.SaveChanges();

                return true;
            }
        }

        public bool Eliminar(int id)
        {
            using (var context = new AppDbContext())
            {
                var cliente = context.Clientes
                    .FirstOrDefault(x => x.Id == id);

                if (cliente == null)
                    return false;

                context.Clientes.Remove(cliente);

                context.SaveChanges();

                return true;
            }
        }

    }
}