using System.Collections.Generic;
using System.Linq;
using WebFormsSoapService.Data;
using WebFormsSoapService.Interfaces;
using WebFormsSoapService.Models;

namespace WebFormsSoapService.Repositories
{
    public class TipoContactoRepository : ITipoContactoRepository
    {
        public TipoContacto ObtenerPorId(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.TiposContacto
                    .FirstOrDefault(t => t.Id == id);
            }
        }

        public List<TipoContacto> ObtenerTodos()
        {
            using (var context = new AppDbContext())
            {
                return context.TiposContacto
                    .ToList();
            }
        }

        public int Crear(TipoContacto tipoContacto)
        {
            using (var context = new AppDbContext())
            {
                context.TiposContacto.Add(tipoContacto);

                context.SaveChanges();

                return tipoContacto.Id;
            }
        }

        public bool Actualizar(TipoContacto tipoContacto)
        {
            using (var context = new AppDbContext())
            {
                var existente = context.TiposContacto
                    .FirstOrDefault(t => t.Id == tipoContacto.Id);

                if (existente == null)
                    return false;

                existente.Descripcion = tipoContacto.Descripcion;

                context.SaveChanges();

                return true;
            }
        }

        public bool Eliminar(int id)
        {
            using (var context = new AppDbContext())
            {
                var tipoContacto = context.TiposContacto
                    .FirstOrDefault(t => t.Id == id);

                if (tipoContacto == null)
                    return false;

                context.TiposContacto.Remove(tipoContacto);

                context.SaveChanges();

                return true;
            }
        }
    }
}