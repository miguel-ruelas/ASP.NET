<%@ Page Title="" Language="C#" MasterPageFile="~/Lab2/Lab2.master" AutoEventWireup="true" CodeFile="TicketsAdd.aspx.cs" Inherits="Lab2_Default" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Table ID="tblTickAddInput" Border="0" CellSpacing="0" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
                <asp:Label ID="lblAddTic" runat="server" Text="Add Tickets"></asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtBxTitle" runat="server" AutoPostBack="true" OnTextChanged="txtBxTitle_TextChanged"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="drlstCat" runat="server"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblUser" runat="server" Text="User:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
              <asp:DropDownList ID="drlstUser" runat="server"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDesc" runat="server" Text="Description:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtAreaDesc" runat="server" TextMode="MultiLine" AutoPostBack="true" OnTextChanged="txtAreaDesc_TextChanged"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnSubTick" runat="server" Text="Submit Ticket" OnClick="btnSubTick_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
    <asp:Label ID="lblAddTickStatus" CssClass="errorMessage" runat="server" Text=""></asp:Label>
    <br/>
    <br/>
    <asp:Label ID="lblCurTick" runat="server" Text="<h1>Current Tickets:</h1>"></asp:Label>
    <asp:Table ID="tblTickets" Border="1" CellSpacing="0" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
               Title
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
               User
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
               Category
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
               Description
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>

