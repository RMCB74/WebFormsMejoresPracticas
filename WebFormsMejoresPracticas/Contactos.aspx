<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Contactos.aspx.cs"
    Inherits="WebFormsMejoresPracticas.Contactos"
    MasterPageFile="~/Site.master" %>
<asp:Content
    ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="container py-4">

        <div class="mb-4">
            <h2 class="fw-bold">Gestión de Contactos</h2>
            <p class="text-muted">
                Administración de contactos de clientes
            </p>
        </div>

        <asp:Label
            ID="lblMensaje"
            runat="server"
            Visible="false"
            CssClass="alert alert-success d-block">
        </asp:Label>

        <!-- FORMULARIO -->

        <div class="card shadow-sm mb-4">

            <div class="card-header bg-primary text-white">
                <h5 class="mb-0">
                    Datos del contacto
                </h5>
            </div>

            <div class="card-body">

                <div class="row g-3">

                    <div class="col-md-4">

                        <asp:Label
                            ID="lblCliente"
                            runat="server"
                            Text="Cliente"
                            CssClass="form-label fw-bold" />

                        <asp:DropDownList
                            ID="ddlCliente"
                            runat="server"
                            CssClass="form-select">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator
                            ID="rfvCliente"
                            runat="server"
                            ControlToValidate="ddlCliente"
                            InitialValue="0"
                            ErrorMessage="Seleccione un cliente."
                            CssClass="text-danger">
                        </asp:RequiredFieldValidator>

                    </div>


                    <div class="col-md-4">

                        <asp:Label
                            ID="lblTipoContacto"
                            runat="server"
                            Text="Tipo de contacto"
                            CssClass="form-label fw-bold" />

                        <asp:DropDownList
                            ID="ddlTipoContacto"
                            runat="server"
                            CssClass="form-select">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator
                            ID="rfvTipoContacto"
                            runat="server"
                            ControlToValidate="ddlTipoContacto"
                            InitialValue="0"
                            ErrorMessage="Seleccione un tipo de contacto."
                            CssClass="text-danger">
                        </asp:RequiredFieldValidator>

                    </div>


                    <div class="col-md-4">

                        <asp:Label
                            ID="lblValor"
                            runat="server"
                            Text="Valor"
                            CssClass="form-label fw-bold" />

                        <asp:TextBox
                            ID="txtValor"
                            runat="server"
                            CssClass="form-control">
                        </asp:TextBox>

                        <asp:RequiredFieldValidator
                            ID="rfvValor"
                            runat="server"
                            ControlToValidate="txtValor"
                            ErrorMessage="Ingrese el valor del contacto."
                            CssClass="text-danger">
                        </asp:RequiredFieldValidator>

                    </div>

                </div>

                <div class="mt-4">

                    <asp:Button
                        ID="btnGuardar"
                        runat="server"
                        Text="Guardar"
                        OnClick="btnGuardar_Click"
                        CssClass="btn btn-primary px-4" />

                </div>

            </div>

        </div>


        <!-- GRID -->

        <div class="card shadow-sm">

            <div class="card-header">
                <h5 class="mb-0">
                    Contactos registrados
                </h5>
            </div>

            <div class="card-body p-0">

                <div class="table-responsive">

                    <asp:GridView
                        ID="gvContactos"
                        runat="server"
                        AutoGenerateColumns="False"
                        OnRowCommand="gvContactos_RowCommand"
                        CssClass="table table-hover table-striped mb-0"
                        GridLines="None">

                        <Columns>

                            <asp:BoundField
                                DataField="Id"
                                HeaderText="Id" />

                            <asp:BoundField
                                DataField="ClienteNombre"
                                HeaderText="Cliente" />

                            <asp:BoundField
                                DataField="TipoContactoDescripcion"
                                HeaderText="Tipo de contacto" />

                            <asp:BoundField
                                DataField="Valor"
                                HeaderText="Valor" />

                            <asp:TemplateField
                                HeaderText="Acciones">

                                <ItemTemplate>

                                    <asp:Button
                                        ID="btnEditar"
                                        runat="server"
                                        Text="Editar"
                                        CommandName="EditarContacto"
                                        CommandArgument='<%# Eval("Id") %>'
                                        CausesValidation="false"
                                        CssClass="btn btn-sm btn-outline-primary me-1" />

                                    <asp:Button
                                        ID="btnEliminar"
                                        runat="server"
                                        Text="Eliminar"
                                        CommandName="EliminarContacto"
                                        CommandArgument='<%# Eval("Id") %>'
                                        CausesValidation="false"
                                        OnClientClick="return confirm('¿Está seguro de eliminar este contacto?');"
                                        CssClass="btn btn-sm btn-outline-danger" />

                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>

            </div>

        </div>

    </div>

</asp:Content>