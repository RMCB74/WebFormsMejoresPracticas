using Microsoft.Extensions.DependencyInjection;
using System;
using WebFormsMejoresPracticas.Models;
using WebFormsMejoresPracticas.Services;

using System.Web.UI.WebControls;


namespace WebFormsMejoresPracticas
{
    public partial class Contactos : System.Web.UI.Page
    {
        private IContactoService _contactoService;

        private IClienteService _clienteService;
        private ITipoContactoService _tipoContactoService;


        private int ContactoId
        {
            get
            {
                return ViewState["ContactoId"] == null
                    ? 0
                    : (int)ViewState["ContactoId"];
            }
            set
            {
                ViewState["ContactoId"] = value;
            }
        }


        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    _contactoService =
        //        Global.ServiceProvider
        //            .GetRequiredService<IContactoService>();

        //    if (!IsPostBack)
        //    {
        //        CargarContactos();
        //    }
        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            _contactoService =
                Global.ServiceProvider
                    .GetRequiredService<IContactoService>();

            _clienteService =
                Global.ServiceProvider
                    .GetRequiredService<IClienteService>();

            _tipoContactoService =
                Global.ServiceProvider
                    .GetRequiredService<ITipoContactoService>();

            if (!IsPostBack)
            {
                CargarClientes();
                CargarTiposContacto();
                CargarContactos();
            }
        }


        private void CargarContactos()
        {
            var contactos = _contactoService.ObtenerTodos();

            gvContactos.DataSource = contactos;
            gvContactos.DataBind();
        }

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    var contacto = new Contacto
        //    {
        //        ClienteId = Convert.ToInt32(ddlCliente.SelectedValue),

        //        TipoContactoId =
        //            Convert.ToInt32(ddlTipoContacto.SelectedValue),

        //        Valor = txtValor.Text
        //    };

        //    _contactoService.Insertar(contacto);

        //    CargarContactos();

        //    txtValor.Text = string.Empty;
        //}
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = string.Empty;
                
                var contacto = new Contacto
                {
                    ClienteId = Convert.ToInt32(ddlCliente.SelectedValue),

                    TipoContactoId =
                        Convert.ToInt32(ddlTipoContacto.SelectedValue),

                    Valor = txtValor.Text.Trim()
                };

                if (ContactoId == 0)
                {
                    _contactoService.Insertar(contacto);

                    lblMensaje.Text =
                        "Contacto creado correctamente.";
                    lblMensaje.Visible = true;
                }
                else
                {
                    contacto.Id = ContactoId;

                    _contactoService.Actualizar(contacto);

                    ContactoId = 0;

                    lblMensaje.Text =
                        "Contacto actualizado correctamente.";

                    lblMensaje.Visible = true;

                }

                CargarContactos();

                ddlCliente.SelectedIndex = 0;
                ddlTipoContacto.SelectedIndex = 0;
                txtValor.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblMensaje.Text =
                    "Ocurrió un error al guardar el contacto.";

                // Aquí puedes registrar el error si deseas
                // mediante ILogger en la página.
            }
        }


        private void CargarClientes()
        {
            var clientes = _clienteService.ObtenerTodos();

            ddlCliente.DataSource = clientes;
            ddlCliente.DataTextField = "Nombre";
            ddlCliente.DataValueField = "Id";
            ddlCliente.DataBind();

            ddlCliente.Items.Insert(
                0,
                new ListItem("-- Seleccione cliente --", "0"));
        }

        private void CargarTiposContacto()
        {
            var tiposContacto = _tipoContactoService.ObtenerTodos();

            ddlTipoContacto.DataSource = tiposContacto;
            ddlTipoContacto.DataTextField = "Descripcion";
            ddlTipoContacto.DataValueField = "Id";
            ddlTipoContacto.DataBind();

            ddlTipoContacto.Items.Insert(
                0,
                new ListItem("-- Seleccione tipo --", "0"));
        }
        protected void gvContactos_RowCommand(
    object sender,
    GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            lblMensaje.Text = string.Empty;
            lblMensaje.Visible = false;

            if (e.CommandName == "EditarContacto")
            {
                var contacto =
                    _contactoService.ObtenerPorId(id);

                if (contacto != null)
                {
                    ContactoId = contacto.Id;

                    ddlCliente.SelectedValue =
                        contacto.ClienteId.ToString();

                    ddlTipoContacto.SelectedValue =
                        contacto.TipoContactoId.ToString();

                    txtValor.Text =
                        contacto.Valor;
                }
            }

            if (e.CommandName == "EliminarContacto")
            {
                _contactoService.Eliminar(id);

                CargarContactos();

                ContactoId = 0;

                ddlCliente.SelectedIndex = 0;
                ddlTipoContacto.SelectedIndex = 0;
                txtValor.Text = string.Empty;


                lblMensaje.Text =
                    "Contacto eliminado  correctamente.";

                lblMensaje.Visible = true;

            }
        }


    }
}
