using System.Collections.Generic;
using WebFormsSoapService.Interfaces;
using WebFormsSoapService.Models;

namespace WebFormsSoapService.Tests.Fakes
{
    public class ContactoRepositoryFake : IContactoRepository
    {
        public Contacto ObtenerPorId(int id)
        {
            return new Contacto
            {
                Id = id,
                ClienteId = 1,
                TipoContactoId = 1,
                Valor = "fake@prueba.com"
            };
        }

        public List<Contacto> ObtenerTodos()
        {
            return new List<Contacto>();
        }

        //public List<Contacto> ObtenerPorCliente(int clienteId)
        //{
        //    return new List<Contacto>();
        //}

        public List<Contacto> ObtenerPorCliente(int clienteId)
        {
            return new List<Contacto>
            {
                new Contacto
                {
                    Id = 1,
                    ClienteId = clienteId,
                    TipoContactoId = 1,
                    Valor = "fake@prueba.com"
                },
                new Contacto
                {
                    Id = 2,
                    ClienteId = clienteId,
                    TipoContactoId = 2,
                    Valor = "5551234567"
                }
            };
        }


        public int Crear(Contacto contacto)
        {
            return 1;
        }

        public bool Actualizar(Contacto contacto)
        {
            return true;
        }

        public bool Eliminar(int id)
        {
            return true;
        }
    }
}