    using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using WebFormsSoapService.Models;

using WebFormsSoapService.Services;

namespace WebFormsSoapService
{
    /// <summary>
    /// Descripción breve de ClienteService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ClienteService : System.Web.Services.WebService
    {

        //private readonly IClienteRepository _clienteRepository;
        //private readonly IClienteRepository _clienteRepository;

        private readonly IClienteService _clienteService;

        private readonly IContactoService _contactoService;
        private readonly ITipoContactoService _tipoContactoService;

        //public ClienteService()
        //{
        //    _clienteRepository = new ClienteRepository();
        //}

        //public ClienteService(IClienteRepository clienteRepository)
        //{
        //    _clienteRepository = clienteRepository;
        //}

        //public ClienteService()
        //{
        //    var provider =
        //        (ServiceProvider)System.Web.HttpContext.Current
        //            .Application["ServiceProvider"];

        //    _clienteRepository =
        //        provider.GetRequiredService<IClienteRepository>();
        //}

        //public ClienteService()
        //{
        //    var scope =
        //        (IServiceScope)HttpContext.Current.Items["DI.Scope"];

        //    _clienteRepository =
        //        scope.ServiceProvider
        //             .GetRequiredService<IClienteRepository>();

        //}


        public ClienteService()
        {
            var scope =
                (IServiceScope)HttpContext.Current.Items["DI.Scope"];

            _clienteService =
                scope.ServiceProvider
                     .GetRequiredService<IClienteService>();


            _contactoService =
                scope.ServiceProvider
                    .GetRequiredService<IContactoService>();

            _tipoContactoService =
                scope.ServiceProvider
                    .GetRequiredService<ITipoContactoService>();

        }


        //[WebMethod]
        //public Cliente ObtenerCliente(int id)
        //{
        //    return _clienteRepository.ObtenerPorId(id);
        //}

        //[WebMethod]
        //public List<Cliente> ObtenerClientes()
        //{
        //    return _clienteRepository.ObtenerTodos();
        //}


        [WebMethod]
        public Cliente ObtenerCliente(int id)
        {
            return _clienteService.ObtenerPorId(id);
        }

        [WebMethod]
        public List<Cliente> ObtenerClientes()
        {
            return _clienteService.ObtenerTodos();
        }

        [WebMethod]
        public int CrearCliente(Cliente cliente)
        {
            return _clienteService.Crear(cliente);
        }

        [WebMethod]
        public bool ActualizarCliente(Cliente cliente)
        {
            return _clienteService.Actualizar(cliente);
        }


        [WebMethod]
        public bool EliminarCliente(int id)
        {
            return _clienteService.Eliminar(id);
        }

        [WebMethod]
        public List<ContactoDto> ObtenerContactos()
        {
            return _contactoService.ObtenerTodos();
        }


        [WebMethod]
        public List<TipoContacto> ObtenerTiposContacto()
        {
            return _tipoContactoService.ObtenerTodos();
        }


        [WebMethod]
        public int CrearContacto(Contacto contacto)
        {
            return _contactoService.Crear(contacto);
        }

        [WebMethod]
        public bool ActualizarContacto(Contacto contacto)
        {
            return _contactoService.Actualizar(contacto);
        }

        [WebMethod]
        public bool EliminarContacto(int id)
        {
            return _contactoService.Eliminar(id);
        }

        [WebMethod]
        public TipoContacto ObtenerTipoContacto(int id)
        {
            return _tipoContactoService.ObtenerPorId(id);
        }
         

        [WebMethod]
        public int CrearTipoContacto(TipoContacto tipoContacto)
        {
            return _tipoContactoService.Crear(tipoContacto);
        }

        [WebMethod]
        public bool ActualizarTipoContacto(TipoContacto tipoContacto)
        {
            return _tipoContactoService.Actualizar(tipoContacto);
        }

        [WebMethod]
        public bool EliminarTipoContacto(int id)
        {
            return _tipoContactoService.Eliminar(id);
        }


    }
}
