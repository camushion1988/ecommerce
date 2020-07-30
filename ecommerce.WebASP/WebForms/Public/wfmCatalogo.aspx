<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmCatalogo.aspx.cs" Inherits="ecommerce.WebASP.WebForms.Public.wfmCatalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>
        <asp:Label ID="Label1" runat="server" Text="Productos"></asp:Label>
    </h3>
    </br>
    
    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="5" OnItemCommand="DataList1_ItemCommand" Width="1180px">
        <ItemTemplate>
            <table>
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="200px" Width="200px" ImageUrl='<%#Eval("Url")%>' />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("Nombre")%>'></asp:Label>
                        <br />
                        <strong>$<asp:Label ID="lblPrecio" runat="server" Text='<%#Eval("Precio")%>'></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Comprar" CommandArgument='<%#Eval("ID")%>' ImageUrl="~/Iconos/comprar2.png" Height="40px" Width="100px" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>

</asp:Content>
