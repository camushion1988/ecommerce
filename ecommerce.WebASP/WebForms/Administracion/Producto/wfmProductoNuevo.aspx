<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmProductoNuevo.aspx.cs" Inherits="ecommerce.WebASP.WebForms.Administracion.Producto.wfmProductoNuevo" %>

<%@ Register Src="~/UserControl/ucCategoria.ascx" TagName="UC_Categoria" TagPrefix="Uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr>
            <td colspan="2" style="font-size: large">
                <strong>Producto
                </strong>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="imbNuevo" runat="server" ImageUrl="~/Iconos/nuevo.ico" Width="32px" Height="32px" OnClick="imgNuevo_Click" />
                            <asp:LinkButton ID="lnkNuevo" runat="server" OnClick="lnkNuevo_Click" CausesValidation="false">Nuevo</asp:LinkButton>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbGuardar" runat="server" ImageUrl="~/Iconos/guardar.ico" Width="32px" Height="32px" OnClick="ImgGuardar_Click" />
                            <asp:LinkButton ID="LnkGuardar" runat="server" OnClick="LnkGuardar_Click">Guardar</asp:LinkButton>
                        </td>
                    </tr>
                </table>
        </tr>
        <tr>
            <td style="width: 142px">Id
            </td>
            <td style="width: 164px">
                <asp:Label ID="LblId" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Categoria
            </td>
            <td style="width: 164px">
                <%--<asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>--%>
                <Uc1:UC_Categoria ID="UC_Categoria1" runat="server"></Uc1:UC_Categoria>

            </td>
        </tr>
        <tr>
            <td>Codigo
            </td>
            <td style="width: 164px">
                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Codigo campo requerido" Text="*" ControlToValidate="txtCodigo" Style="font-weight: 700; color: #CC3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Nombre
            </td>
            <td style="width: 164px">
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nombre campo requerido" Text="*" ControlToValidate="txtNombre" Style="font-weight: 700; color: #CC3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Precio de Compra
            </td>
            <td style="width: 164px">
                <asp:TextBox ID="txtPrecioCompra" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Precio Compra campo requerido" Text="*" ControlToValidate="txtPrecioCompra" Style="font-weight: 700; color: #CC3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Precio de Venta
            </td>
            <td style="width: 164px">
                <asp:TextBox ID="txtPrecioVenta" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Precio Venta campo requerido" Text="*" ControlToValidate="txtPrecioVenta" Style="font-weight: 700; color: #CC3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Imagen
            </td>
            <td style="width: 164px">
                <asp:FileUpload ID="FileUploadProducto" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Descripcion
            </td>
            <td style="width: 164px">
                <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Stock Minimo
            </td>
            <td style="width: 164px">
                <asp:TextBox ID="txtStockMinimo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Stock Minimo campo requerido" Text="*" ControlToValidate="txtStockMinimo" Style="font-weight: 700; color: #CC3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Stock Maximo
            </td>
            <td style="width: 164px">
                <asp:TextBox ID="txtStockMaximo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Stock Maximo campo requerido" Text="*" ControlToValidate="txtStockMaximo" Style="font-weight: 700; color: #CC3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Mensaje</td>
            <td style="width: 164px">
                <asp:Label ID="LblMensaje" runat="server" ForeColor="#CC3300"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" />
            </td>
        </tr>
    </table>

</asp:Content>
