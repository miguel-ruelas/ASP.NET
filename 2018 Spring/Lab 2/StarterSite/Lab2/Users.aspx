<%@ Page Title="" Language="C#" MasterPageFile="~/Lab2/Lab2.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Lab2_Default" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Table ID="tblUserAddInput" Border="0" CellSpacing="0" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Text="FirstName:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtBxFirstName" runat="server" AutoPostBack="true" OnTextChanged="txtBxFirstName_TextChanged"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblLastName" runat="server" Text="LastName:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtBxLastName" runat="server" AutoPostBack="true" OnTextChanged="txtBxLastName_TextChanged"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
               <asp:TextBox ID="txtBxEmail" runat="server" AutoPostBack="True" OnTextChanged="txtBxEmail_TextChanged"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click"/>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
    <asp:Label ID="lblAddUserStatus" CssClass="errorMessage" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblCurUsers" runat="server" Text="<h1>Current Users:</h1>"></asp:Label>
    <asp:Table ID="tblUsers" Border="1" CellSpacing="0" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
               FirstName
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
               LastName
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
               Email
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>

