<%--<%@ 
    Page Title="Tipos de contacto"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="TiposContacto.aspx.cs"
    Inherits="WebFormsMejoresPracticas.TiposContacto"
%>--%>
<%@ Page
    Title="Tipos de contacto"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="TiposContacto.aspx.cs"
    Inherits="WebFormsMejoresPracticas.TiposContacto" %>
<asp:Content
    ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="container py-4">

        <!-- Título -->

        <div class="mb-4">

            <h2 class="fw-bold">
                Gestión de Tipos de Contacto
            </h2>

            <p class="text-muted">
                Administración de tipos de contacto
            </p>

        </div>


        <!-- Mensaje -->

        <asp:Label
            ID="lblMensaje"
            runat="server"
            Visible="false"
            CssClass="alert alert-success d-block">
        </asp:Label>


        <!-- Botón Nuevo -->

        <div class="mb-3">

            <asp:Button
                ID="btnNuevo"
                runat="server"
                Text="+ Nuevo tipo"
                OnClick="btnNuevo_Click"
                CssClass="btn btn-primary" />

        </div>


        <!-- Grid -->

        <div class="card shadow-sm mb-4">

            <div class="card-header">

                <h5 class="mb-0">
                    Tipos de contacto registrados
                </h5>

            </div>

            <div class="card-body p-0">

                <div class="table-responsive">

                    <asp:GridView
                        ID="gvTiposContacto"
                        runat="server"
                        AutoGenerateColumns="false"
                        OnRowCommand="gvTiposContacto_RowCommand"
                        CssClass="table table-hover table-striped mb-0"
                        GridLines="None">

                        <Columns>

                            <asp:BoundField
                                DataField="Id"
                                HeaderText="Id" />

                            <asp:BoundField
                                DataField="Descripcion"
                                HeaderText="Descripción" />

                            <asp:TemplateField
                                HeaderText="Acciones">

                                <ItemTemplate>

                                    <asp:Button
                                        ID="btnEditar"
                                        runat="server"
                                        Text="Editar"
                                        CommandName="EditarTipoContacto"
                                        CommandArgument='<%# Eval("Id") %>'
                                        CausesValidation="false"
                                        CssClass="btn btn-sm btn-outline-primary me-1" />

                                    <asp:Button
                                        ID="btnEliminar"
                                        runat="server"
                                        Text="Eliminar"
                                        CommandName="EliminarTipoContacto"
                                        CommandArgument='<%# Eval("Id") %>'
                                        CausesValidation="false"
                                        OnClientClick="return confirm('¿Está seguro de eliminar este tipo de contacto?');"
                                        CssClass="btn btn-sm btn-outline-danger" />

                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>

            </div>

        </div>


        <!-- Formulario -->

        <asp:Panel
            ID="pnlTipoContacto"
            runat="server"
            Visible="false">

            <div class="card shadow-sm">

                <div class="card-header bg-primary text-white">

                    <h5 class="mb-0">

                        <asp:Label
                            ID="lblTituloFormulario"
                            runat="server"
                            Text="Nuevo tipo de contacto">
                        </asp:Label>

                    </h5>

                </div>

                <div class="card-body">

                    <asp:HiddenField
                        ID="hfTipoContactoId"
                        runat="server" />

                    <div class="mb-3">

                        <asp:Label
                            ID="lblDescripcion"
                            runat="server"
                            Text="Descripción"
                            CssClass="form-label fw-bold">
                        </asp:Label>

                        <asp:TextBox
                            ID="txtDescripcion"
                            runat="server"
                            MaxLength="50"
                            CssClass="form-control">
                        </asp:TextBox>

                    </div>

                    <asp:Button
                        ID="btnGuardar"
                        runat="server"
                        Text="Guardar"
                        OnClick="btnGuardar_Click"
                        CssClass="btn btn-primary me-2" />

                    <asp:Button
                        ID="btnCancelar"
                        runat="server"
                        Text="Cancelar"
                        OnClick="btnCancelar_Click"
                        CssClass="btn btn-secondary" />

                </div>

            </div>

        </asp:Panel>

    </div>

</asp:Content>