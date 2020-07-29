<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmProductoLista.aspx.cs" Inherits="ecommerce.WebASP.WebForms.Administracion.Producto.wfmProductoLista" %>

<%@ Register Src="~/UserControl/ucGridviewDatos.ascx" TagName="UC_Datos" TagPrefix="Uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <div align="center" width="95">
        <table width="95%">
            <tr>
                <td>
                    <h3>Lista Productos</h3>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="imbNuevo" runat="server" ImageUrl="~/Iconos/nuevo.ico" Width="32px" Height="32px" CausesValidation="false" OnClick="imbNuevo_Click" />
                    <asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="false" OnClick="lnkNuevo_Click">Nuevo</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <table width="35%">
                        <tr>
                            <td>Buscar por</td>
                            <td>
                                <asp:DropDownList ID="ddlBuscar" runat="server">
                                    <asp:ListItem Value="T">Todos</asp:ListItem>
                                    <asp:ListItem Value="C">Codigo</asp:ListItem>
                                    <asp:ListItem Value="N">Nombre</asp:ListItem>
                                    <asp:ListItem Value="Ca">Categoria</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton ID="imbBuscar" runat="server" ImageUrl="~/Iconos/buscar.ico" Width="24px" Height="24px" OnClick="imbBuscar_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <Uc1:UC_Datos ID="UC_Datos1" runat="server"></Uc1:UC_Datos>
    </div>
</asp:Content>
