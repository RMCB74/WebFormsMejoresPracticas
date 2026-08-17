using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebFormsSoapClient.Soap;

namespace WebFormsSoapClient
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 

                var clienteService = new ClienteService.ClienteServiceSoapClient();

                clienteService.Endpoint.EndpointBehaviors.Add(
                    new WebFormsSoapClient.Soap.SoapMessageBehavior());

                var clientes = clienteService.ObtenerClientes();

                foreach (var clientel in clientes)
                {
                    Response.Write(
                        clientel.Id + " - " +
                        clientel.Nombre + "<br />");
                }

                var cliente = new ClienteService.Cliente
                {
                    Nombre =  "Cliente SOAP Prueba"
                };

                int id = clienteService.CrearCliente(cliente);

                Response.Write("Cliente creado. Id: " + id);


                var clienteCreado =     clienteService.ObtenerCliente(id);

                clienteCreado.Nombre = "Cliente SOAP Actualizado";

                bool actualizado =
                    clienteService.ActualizarCliente(clienteCreado);

                Response.Write(
                    "<br/>Actualizado: " + actualizado);

                bool eliminado =    clienteService.EliminarCliente(id);

                Response.Write(
                    "<br/>Eliminado: " + eliminado);


                Response.Write("<hr/>CONTACTOS<br/>");

                var contactos = clienteService.ObtenerContactos();

                foreach (var contacto in contactos)
                {
                    Response.Write(
                        contacto.Id + " - " +
                        contacto.ClienteNombre + " - " +
                        contacto.TipoContactoDescripcion + " - " +
                        contacto.Valor + "<br/>");
                }


                var nuevoContacto = new ClienteService.Contacto
                {
                    ClienteId = 1,
                    TipoContactoId = 1,
                    Valor = "contacto.soap@prueba.com"
                };

                int contactoId =
                    clienteService.CrearContacto(nuevoContacto);

                Response.Write(
                    "<br/>Contacto creado. Id: " + contactoId);

                nuevoContacto.Id = contactoId;
                nuevoContacto.Valor = "contacto.actualizado@prueba.com";

                bool contactoActualizado =
                    clienteService.ActualizarContacto(nuevoContacto);

                Response.Write(
                    "<br/>Contacto actualizado: " + contactoActualizado);

                bool contactoEliminado =
                    clienteService.EliminarContacto(contactoId);

                                Response.Write(
                    "<br/>Contacto eliminado: " + contactoEliminado);

                Response.Write("<hr/>TIPOS DE CONTACTO<br/>");

                var tipos = clienteService.ObtenerTiposContacto();

                foreach (var tipo in tipos)
                {
                    Response.Write(
                        tipo.Id + " - " +
                        tipo.Descripcion + "<br/>");
                }


                // CREAR
                var nuevoTipo = new ClienteService.TipoContacto
                {
                    Descripcion = "Tipo SOAP Prueba"
                };

                int tipoId =
                    clienteService.CrearTipoContacto(nuevoTipo);

                Response.Write(
                    "<br/>Tipo creado. Id: " + tipoId);


                // ACTUALIZAR
                nuevoTipo.Id = tipoId;
                nuevoTipo.Descripcion = "Tipo SOAP Actualizado";

                bool tipoActualizado =
                    clienteService.ActualizarTipoContacto(nuevoTipo);

                Response.Write(
                    "<br/>Tipo actualizado: " + tipoActualizado);


                // ELIMINAR
                bool tipoEliminado =
                    clienteService.EliminarTipoContacto(tipoId);

                Response.Write(
                    "<br/>Tipo eliminado: " + tipoEliminado);

            }
        }


    }
}