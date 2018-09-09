<%@ Page Title="" Language="C#" MasterPageFile="~/Lab2/Lab2.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Lab2_Default" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Label ID="lblCategory" runat="server" Text="Add Category"></asp:Label>
    <asp:TextBox ID="txtBxCategory" runat="server"></asp:TextBox>
    <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" OnClick="btnAddCategory_Click" />
    <br />
    <asp:Label ID="lblCatStatus" CssClass="errorMessage" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblCurCategory" runat="server" Text="<h1>Current Categories:</h1>"></asp:Label>
    <asp:Table ID="tblCategories" Border="1" CellSpacing="0" runat="server">
        <asp:TableHeaderRow>
           <asp:TableHeaderCell>
               Name
           </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>

