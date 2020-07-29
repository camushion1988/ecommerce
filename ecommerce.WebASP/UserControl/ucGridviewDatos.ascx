<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGridviewDatos.ascx.cs" Inherits="ecommerce.WebASP.UserControl.ucGridviewDatos" %>
<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="95%" OnRowCommand="GridView1_RowCommand" >
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="imbEditar" runat="server" ImageUrl="~/Iconos/editar.ico" Width="24px" Height="24px" CommandName="Modificar" CommandArgument='<%#Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="imbEliminar" runat="server" ImageUrl="~/Iconos/eliminar.ico" Width="24px" Height="24px" CommandName="Eliminar" CommandArgument='<%#Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>
