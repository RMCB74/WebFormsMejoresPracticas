using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebFormsSoapService.Data;
using WebFormsSoapService.Interfaces;
using WebFormsSoapService.Models;

namespace WebFormsSoapService.Repositories
{
    public class ContactoRepository : IContactoRepository
    {
        public Contacto ObtenerPorId(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Contactos
                    .Include(x => x.Cliente)
                    .Include(x => x.TipoContacto)
                    .FirstOrDefault(x => x.Id == id);
            }
        }


        public List<Contacto> ObtenerTodos()
        {
            using (var context = new AppDbContext())
            {
                return context.Contactos
                    .Include(x => x.Cliente)
                    .Include(x => x.TipoContacto)
                    .ToList();
            }
        }

        public List<Contacto> ObtenerPorCliente(int clienteId)
        {
            using (var context = new AppDbContext())
            {
                return context.Contactos
                    .Include(x => x.Cliente)
                    .Include(x => x.TipoContacto)
                    .Where(x => x.ClienteId == clienteId)
                    .ToList();
            }
        }

        public int Crear(Contacto contacto)
        {
            using (var context = new AppDbContext())
            {
                context.Contactos.Add(contacto);

                context.SaveChanges();

                return contacto.Id;
            }
        }

        public bool Actualizar(Contacto contacto)
        {
            using (var context = new AppDbContext())
            {
                var existente = context.Contactos
                    .FirstOrDefault(x => x.Id == contacto.Id);

                if (existente == null)
                    return false;

                existente.ClienteId = contacto.ClienteId;
                existente.TipoContactoId = contacto.TipoContactoId;
                existente.Valor = contacto.Valor;

                context.SaveChanges();

                return true;
            }
        }

        public bool Eliminar(int id)
        {
            using (var context = new AppDbContext())
            {
                var contacto = context.Contactos
                    .FirstOrDefault(x => x.Id == id);

                if (contacto == null)
                    return false;

                context.Contactos.Remove(contacto);

                context.SaveChanges();

                return true;
            }
        }
    }
}