<%@ Page Title="" Language="C#" MasterPageFile="~/Lab2/Lab2.master" AutoEventWireup="true" CodeFile="TicketsView.aspx.cs" Inherits="Lab2_Default" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Label ID="lblFilter" runat="server" Text="Filter Tickets:"></asp:Label>
    <asp:Table ID="tblTickAddInput" Border="0" CellSpacing="0" runat="server">
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
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
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

