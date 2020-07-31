<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmProducto.aspx.cs" Inherits="ecommerce.WebASP.WebForms.Public.wfmProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table width="95%">
        <tr>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td width="40%">
                <asp:Image ID="imgProducto" runat="server" Width="350px" Height="400px" />
            </td>
            <td width="*" style="vertical-align: top">
                <table width="100%">
                    <tr>
                        <td align="center">
                            <h4>
                                <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label></h4>
                        </td>

                    </tr>
                    <tr>
                        <td align="center">
                            <h5>
                                <asp:Label ID="lblDescripcion" runat="server" Text="Label"></asp:Label></h5>
                        </td>

                    </tr>
                    <tr>
                        <td align="center">
                            <h5>Precio: USD$
                                <asp:Label ID="lblPrecio" runat="server" Text="Label" ForeColor="red"></asp:Label></h5>
                        </td>

                    </tr>
                    <tr>
                        <td>&nbsp;</td>

                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblIdProducto" runat="server" Text="" visible="false" ></asp:Label>
                            <asp:Label ID="lblCodigoProducto" runat="server" Text="" visible="false" ></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td align="center">Cantidad:
                            <asp:TextBox ID="txtCantidad" TextMode="Number" min="1" max="20" step="1" runat="server"></asp:TextBox>
                        </td>

                    </tr>

                    <tr>
                        <td align="center">&nbsp;</td>

                    </tr>

                    <tr>
                        <td align="center">
                            <asp:ImageButton ID="btnComprar" runat="server" ImageUrl="~/Iconos/comprar2.png" Height="80px" Width="200px" OnClick="btnComprar_Click" />
                        </td>

                    </tr>
                    <tr>
                        <td>&nbsp;</td>

                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
