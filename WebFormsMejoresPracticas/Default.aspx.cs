using Microsoft.Extensions.DependencyInjection;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebFormsMejoresPracticas.Exceptions;
using WebFormsMejoresPracticas.Models;
using WebFormsMejoresPracticas.Services;

namespace WebFormsMejoresPracticas
{
    public partial class _Default : Page
    {
        private IClienteService _clienteService;

        protected void Page_Init(object sender, EventArgs e)
        {
            var scope = HttpContext.Current.Items["DI.Scope"]
                as IServiceScope;

            _clienteService = scope.ServiceProvider
                .GetRequiredService<IClienteService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            lblTituloFormulario.Text = "Nuevo cliente";

            OcultarMensaje();

            AbrirModalCliente();
        }

        protected void gvClientes_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarCliente")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                //var cliente = _clienteService.ObtenerPorId(id);
                var resultado = _clienteService.ObtenerPorId(id);

                //if (cliente == null)
                //{
                //    MostrarMensaje("No se encontró el cliente.");
                //    return;
                //}
                if (!resultado.Exitoso)
                {
                    MostrarMensaje(resultado.Mensaje);
                    return;
                }


                var cliente = resultado.Datos;

                hfClienteId.Value = cliente.Id.ToString();

                txtNombre.Text = cliente.Nombre;

                lblTituloFormulario.Text = "Editar cliente";

                OcultarMensaje();

                AbrirModalCliente();
            }
            else if (e.CommandName == "EliminarCliente")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                try
                {
                    _clienteService.Eliminar(id);

                    CargarClientes();

                    OcultarFormulario();

                    MostrarMensajeExito(
                        "El cliente se eliminó correctamente.");
                }
                catch (ClienteTieneContactosException ex)
                {
                    MostrarMensaje(ex.Message);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;

                if (!string.IsNullOrWhiteSpace(hfClienteId.Value))
                {
                    id = Convert.ToInt32(hfClienteId.Value);
                }

                var cliente = new Cliente
                {
                    Id = id,
                    Nombre = txtNombre.Text.Trim()
                };

                if (id == 0)
                {
                    _clienteService.Crear(cliente);

                    MostrarMensajeExito(
                        "El cliente se creó correctamente.");
                }
                else
                {
                    _clienteService.Actualizar(cliente);

                    MostrarMensajeExito(
                        "El cliente se actualizó correctamente.");
                }

                CargarClientes();

                OcultarFormulario();
            }
            catch (ArgumentException ex)
            {
                MostrarMensaje(ex.Message);
                 }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            OcultarFormulario();

            OcultarMensaje();
        }

        //private void CargarClientes()
        //{
        //    var clientes = _clienteService.ObtenerTodos();

        //    gvClientes.DataSource = clientes;
        //    gvClientes.DataBind();
        //}

        private void CargarClientes()
        {
            var resultado = _clienteService.ObtenerTodos();

            gvClientes.DataSource = resultado.Datos;//cambio
            gvClientes.DataBind();
        }

        private void LimpiarFormulario()
        {
            hfClienteId.Value = string.Empty;

            txtNombre.Text = string.Empty;
        }

        private void OcultarFormulario()
        {
            //pnlCliente.Visible = false;

            LimpiarFormulario();
        }

        private void MostrarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;

            lblMensaje.CssClass = "alert alert-danger d-block";

            lblMensaje.Visible = true;
        }

        private void MostrarMensajeExito(string mensaje)
        {
            lblMensaje.Text = mensaje;

            lblMensaje.CssClass = "alert alert-success d-block";

            lblMensaje.Visible = true;
        }

        private void OcultarMensaje()
        {
            lblMensaje.Text = string.Empty;

            lblMensaje.Visible = false;

            lblMensaje.CssClass = "mensaje-error";
        }


        //private void AbrirModalCliente()
        //{
        //    ScriptManager.RegisterStartupScript(
        //        this,
        //        GetType(),
        //        "AbrirModalCliente",
        //        "var modal = new bootstrap.Modal(document.getElementById('clienteModal')); modal.show();",
        //        true);
        //}

        //private void AbrirModalCliente()
        //{
        //    ScriptManager.RegisterStartupScript(
        //        this,
        //        GetType(),
        //        "AbrirModalCliente",
        //        "var modal = new bootstrap.Modal(document.getElementById('clienteModal')); modal.show();",
        //        true);
        //}


        private void AbrirModalCliente()
        {
            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "AbrirModalCliente",
                @"
            window.addEventListener('load', function () {
                var elemento = document.getElementById('clienteModal');

                if (elemento) {
                    var boton = document.createElement('button');
                    boton.type = 'button';
                    boton.setAttribute('data-bs-toggle', 'modal');
                    boton.setAttribute('data-bs-target', '#clienteModal');
                    document.body.appendChild(boton);
                    boton.click();
                    boton.remove();
                }
            });
        ",
                true);
        }


        private void CerrarModalCliente()
        {
            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "CerrarModalCliente",
                @"
            window.addEventListener('load', function () {
                var elemento = document.getElementById('clienteModal');

                if (elemento) {
                    var boton = document.createElement('button');
                    boton.type = 'button';
                    boton.setAttribute('data-bs-dismiss', 'modal');
                    document.body.appendChild(boton);
                    boton.click();
                    boton.remove();
                }
            });
        ",
                true);
        }

        protected void gvClientes_PageIndexChanging(
        object sender,
        GridViewPageEventArgs e)
            {
                gvClientes.PageIndex = e.NewPageIndex;
                    CargarClientes();
            }


    }
}