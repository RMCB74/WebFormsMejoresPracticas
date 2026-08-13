using Microsoft.Extensions.DependencyInjection;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebFormsMejoresPracticas.Models;
using WebFormsMejoresPracticas.Services;

namespace WebFormsMejoresPracticas
{
    public partial class TiposContacto : Page
    {
        private ITipoContactoService _tipoContactoService;

        protected void Page_Init(object sender, EventArgs e)
        {
            var scope = HttpContext.Current.Items["DI.Scope"]
                as IServiceScope;

            _tipoContactoService = scope.ServiceProvider
                .GetRequiredService<ITipoContactoService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTiposContacto();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            lblTituloFormulario.Text = "Nuevo tipo de contacto";

            pnlTipoContacto.Visible = true;

            OcultarMensaje();
        }

        protected void gvTiposContacto_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarTipoContacto")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                var tipoContacto =
                    _tipoContactoService.ObtenerPorId(id);

                if (tipoContacto == null)
                {
                    MostrarMensaje(
                        "No se encontró el tipo de contacto.");

                    return;
                }

                hfTipoContactoId.Value =
                    tipoContacto.Id.ToString();

                txtDescripcion.Text =
                    tipoContacto.Descripcion;

                lblTituloFormulario.Text =
                    "Editar tipo de contacto";

                pnlTipoContacto.Visible = true;

                OcultarMensaje();
            }
            else if (e.CommandName == "EliminarTipoContacto")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                try
                {
                    _tipoContactoService.Eliminar(id);

                    CargarTiposContacto();

                    OcultarFormulario();

                    MostrarMensajeExito(
                        "El tipo de contacto se eliminó correctamente.");
                }
                catch (Exception ex)
                {
                    MostrarMensaje(ex.Message);
                }
            }
        }

        protected void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                int id = 0;

                if (!string.IsNullOrWhiteSpace(
                    hfTipoContactoId.Value))
                {
                    id = Convert.ToInt32(
                        hfTipoContactoId.Value);
                }

                var tipoContacto = new TipoContacto
                {
                    Id = id,
                    Descripcion = txtDescripcion.Text.Trim()
                };

                if (id == 0)
                {
                    _tipoContactoService.Crear(
                        tipoContacto);

                    MostrarMensajeExito(
                        "El tipo de contacto se creó correctamente.");
                }
                else
                {
                    _tipoContactoService.Actualizar(
                        tipoContacto);

                    MostrarMensajeExito(
                        "El tipo de contacto se actualizó correctamente.");
                }

                CargarTiposContacto();

                OcultarFormulario();
            }
            catch (ArgumentException ex)
            {
                MostrarMensaje(ex.Message);
            }
        }

        protected void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            OcultarFormulario();

            OcultarMensaje();
        }

        private void CargarTiposContacto()
        {
            var tiposContacto =
                _tipoContactoService.ObtenerTodos();

            gvTiposContacto.DataSource = tiposContacto;

            gvTiposContacto.DataBind();
        }

        private void LimpiarFormulario()
        {
            hfTipoContactoId.Value = string.Empty;

            txtDescripcion.Text = string.Empty;
        }

        private void OcultarFormulario()
        {
            pnlTipoContacto.Visible = false;

            LimpiarFormulario();
        }

        //private void MostrarMensaje(string mensaje)
        //{
        //    lblMensaje.Text = mensaje;

        //    lblMensaje.CssClass = "mensaje-error";

        //    lblMensaje.Visible = true;
        //}
        private void MostrarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;

            lblMensaje.CssClass = "alert alert-danger d-block";

            lblMensaje.Visible = true;
        }

        //private void MostrarMensajeExito(string mensaje)
        //{
        //    lblMensaje.Text = mensaje;

        //    lblMensaje.CssClass = "mensaje-exito";

        //    lblMensaje.Visible = true;
        //}

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
        }
    }
}