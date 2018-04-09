<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearEquipo.aspx.cs" Inherits="Mindden.Web.Equipos.Views.CrearEquipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div>
         <span class="field-label">
                Nombre:
            </span>
            <span class="field-editor">
                <asp:TextBox runat="server" ID="TextName"></asp:TextBox>
            </span>
            <span class="field-label">
                Ubicacion:
            </span>
            <span class="field-editor">
                <asp:Textbox runat="server" ID="TextUbicacion"></asp:Textbox>
            </span>
            <span class="field-label">
                Cliente:
            </span>
            <span class="field-editor">
                <asp:TextBox runat="server" ID="TextCliente"></asp:TextBox>
            </span>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
     </div>
      
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <TR>
               <TD>NombreEquipo</TD>
               <TD>Ubicacion</TD>
               <TD>Cliente</TD>
            </TR>
        </HeaderTemplate>
        <ItemTemplate>
            <TR>
                <TD><%#Eval("NombreEquipo") %></TD
                <TD><%#Eval("Ubicacion") %></TD>
                <TD><%#Eval("Cliente") %></TD>
            </TR>>
        </ItemTemplate>
        
            
        
    </asp:Repeater>
    
</asp:Content>
