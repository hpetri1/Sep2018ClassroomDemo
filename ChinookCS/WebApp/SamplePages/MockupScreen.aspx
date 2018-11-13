<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MockupScreen.aspx.cs" Inherits="WebApp.SamplePages.MockupScreen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Some Value"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>Bob Paper</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Any Data I want"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server">12</asp:TextBox>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("id") %>'></asp:Label>
                </ItemTemplate>  
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("name") %>'></asp:Label>
                </ItemTemplate>  
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="Picked">
                <ItemTemplate>
                    <asp:TextBox runat="server"  Text='<%# Eval("Picked") %>'></asp:TextBox>
                 </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Issues">
                <ItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Eval("Issues") %>'></asp:TextBox>
                 </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
