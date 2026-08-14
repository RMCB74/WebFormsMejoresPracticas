<%@ Page
    Title="Clientes"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="WebFormsMejoresPracticas._Default" %>


<asp:Content
    ID="BodyContent"
    ContentPlaceHolderID="MainContent"
    runat="server">

    

        <!-- Título -->

        <div class="mb-4">
            <h2 class="fw-bold">
                Gestión de Clientes
            </h2>

            <p class="text-muted">
                Administración de clientes
            </p>
        </div>


        <!-- Mensaje -->
<asp:Label
    ID="lblMensaje"
    runat="server"
    Visible="false"
    CssClass="alert alert-success d-block">
</asp:Label>

        <!-- Botón nuevo -->

        <div class="mb-3">

          <button
                type="button"
                class="btn btn-primary mb-3"
                data-bs-toggle="modal"
                data-bs-target="#clienteModal"
                onclick="limpiarCliente();">
                + Nuevo cliente
            </button>

<%--            <asp:Button
                ID="btnNuevo"
                runat="server"
                Text="+ Nuevo cliente"
                CssClass="btn btn-primary mb-3"
                OnClick="btnNuevo_Click"
                CausesValidation="false" />--%>

          <%-- <asp:Button
                ID="btnNuevo"
                runat="server"
                Text="+ Nuevo cliente"
                CssClass="btn btn-primary"
                OnClick="btnNuevo_Click" />
              --%>
        

          <%--  <button
                type="button"
                class="btn btn-primary mb-3"
                data-bs-toggle="modal"
                data-bs-target="#clienteModal">
                + Nuevo cliente
            </button>--%>
       </div>

<div
    class="modal fade"
    id="clienteModal"
    tabindex="-1"
    aria-labelledby="clienteModalLabel"
    aria-hidden="true">

    <div class="modal-dialog modal-dialog-centered">

        <div class="modal-content">

            <div class="modal-header">
                <h5
                    class="modal-title"
                    id="clienteModalLabel">

                    <asp:Label
                        ID="lblTituloFormulario"
                        runat="server"
                        Text="Nuevo cliente">
                    </asp:Label>

                </h5>

                <button
                    type="button"
                    class="btn-close"
                    data-bs-dismiss="modal"
                    aria-label="Cerrar">
                </button>
            </div>

            <div class="modal-body">

                <asp:HiddenField
                    ID="hfClienteId"
                    runat="server" />

                <div class="mb-3">

                    <asp:Label
                        ID="lblNombre"
                        runat="server"
                        Text="Nombre"
                        CssClass="form-label">
                    </asp:Label>

                    <asp:TextBox
                        ID="txtNombre"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>

                </div>

            </div>

            <div class="modal-footer">

                <asp:Button
                    ID="btnGuardar"
                    runat="server"
                    Text="Guardar"
                    CssClass="btn btn-primary"
                    OnClick="btnGuardar_Click" />

                <button
                    type="button"
                    class="btn btn-secondary"
                    data-bs-dismiss="modal">
                    Cancelar
                </button>

            </div>

        </div>

    </div>

</div>
        <div class="container py-4">

        <!-- Grid -->

        <div class="card shadow-sm mb-4">

            <div class="card-header">

                <h5 class="mb-0">
                    Clientes registrados
                </h5>

            </div>

            <div class="card">
            <div class="card-header">
                <div class="row">
                    <div class="col-md-6">
                        <h5 class="mb-0">Contactos</h5>
                    </div>

                    <div class="col-md-6">
                        <asp:TextBox
                            ID="txtBuscar"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Buscar contacto en esta pág n_n+1..."
                            onkeyup="filtrarContactos()" />
                    </div>
                </div>
    </div>


            <div class="card-body p-0">

                <div class="table-responsive">

                    <asp:GridView
                        ID="gvClientes"
                        runat="server"
                        AutoGenerateColumns="false"
                        OnRowCommand="gvClientes_RowCommand"
                        CssClass="table table-hover table-striped mb-0"
                        GridLines="None"
                        
                        AllowPaging="true"
                        PageSize="10"
                        OnPageIndexChanging="gvClientes_PageIndexChanging"
                        >

                        <Columns>

                            <asp:BoundField
                                DataField="Id"
                                HeaderText="Id" />

                            <asp:BoundField
                                DataField="Nombre"
                                HeaderText="Nombre" />

                            <asp:TemplateField
                                HeaderText="Acciones">

                                <ItemTemplate>

                                    <asp:Button
                                        ID="btnEditar"
                                        runat="server"
                                        Text="Editar"
                                        CssClass="btn btn-sm btn-outline-primary me-1"
                                        CommandName="EditarCliente"
                                        CommandArgument='<%# Eval("Id") %>'
                                        CausesValidation="false" />

                                    <asp:Button
                                        ID="btnEliminar"
                                        runat="server"
                                        Text="Eliminar"
                                        CssClass="btn btn-sm btn-outline-danger"
                                        CommandName="EliminarCliente"
                                        CommandArgument='<%# Eval("Id") %>'
                                        CausesValidation="false"
                                        OnClientClick="return confirm('¿Está seguro de eliminar este cliente?');" />

                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>

            </div>

        </div>


        <!-- Formulario -->


</div>

    </div>

        <script>
    function limpiarCliente() {

        document.getElementById('<%= hfClienteId.ClientID %>').value = '';

        document.getElementById('<%= txtNombre.ClientID %>').value = '';

        document.getElementById('<%= lblTituloFormulario.ClientID %>').innerText =
            'Nuevo cliente';
    }


    function filtrarContactos() {

                const texto = document
                    .getElementById('<%= txtBuscar.ClientID %>')
        .value
        .toLowerCase();

        const grid = document.getElementById('<%= gvClientes.ClientID %>');

        const filas = grid.getElementsByTagName("tr");

                for (let i = 1; i < filas.length; i++) {

                    const contenido = filas[i].innerText.toLowerCase();

                    filas[i].style.display =
                        contenido.includes(texto) ? "" : "none";
                }
            }



        </script>


</asp:Content>