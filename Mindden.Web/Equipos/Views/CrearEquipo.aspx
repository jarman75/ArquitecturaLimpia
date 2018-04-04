<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearEquipo.aspx.cs" Inherits="Mindden.Web.Equipos.Views.CrearEquipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:FormView ID="FormView1" runat="server" ItemType="Mindden.Web.Equipos.Models.EquipoViewModel" InsertMethod="InsertItem">
        <InsertItemTemplate>
            <span class="field-label">
                Nombre:
            </span>
            <span class="field-editor">
                <asp:TextBox runat="server" ID="TextName" Text ="<%# Item.NombrEquipo %>"></asp:TextBox>
            </span>
            <span class="field-label">
                Ubicacion:
            </span>
            <span class="field-editor">
                <asp:Textbox runat="server" ID="TextUbicacion" Text ="<%#Item.Ubicacion %>"></asp:Textbox>
            </span>
            <span class="field-label">
                Cliente:
            </span>
            <span class="field-editor">
                <asp:TextBox runat="server" ID="TextCliente" Text ="<%#Item.Cliente %>"></asp:TextBox>
            </span>
        </InsertItemTemplate>
    </asp:FormView>
    
</asp:Content>
