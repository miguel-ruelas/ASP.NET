<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
      .auto-style1 {
        width: 100%;
      }
      .error  
      {
        border-color:red;
        border-width:1px;
        border-style:solid;
      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding:10px">
          <table class="auto-style1">
            <tr>
              <td style="width:33%;">
                <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label></td>
              <td style="width:33%;">
                <asp:Label ID="Label2" runat="server" Text="Registrations:"></asp:Label></td>
             <td style="width:33%;">
                <asp:Label ID="Label3" runat="server" Text="Canceled Registrations:"></asp:Label>
              </td>
            </tr>
            <tr>
              <td style="vertical-align:top">
                <asp:TextBox Width="75%" ID="txtName" runat="server" AutoPostBack="True" OnTextChanged="txtName_TextChanged"></asp:TextBox>
                <br />
                <asp:Label ID="lbltxtNameError" runat="server" Text="Name is required!!!" Visible="False" Width="100%" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
              </td>
              <td>
                <asp:ListBox style="Width:100%" ID="lstbxRegs" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstbxRegs_SelectedIndexChanged" SelectionMode="Multiple"></asp:ListBox>
              </td>
              <td>
                <asp:ListBox style="Width:100%" ID="lstbxCancelRegs" runat="server" SelectionMode="Multiple" ></asp:ListBox>
              </td>
            </tr>
          </table>
          <table class="auto-style1">
            <tr>
              <td style="width:33%">
                <asp:Label ID="Label4" runat="server" Text="Event Date:"></asp:Label>
                <br />
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="240px" Width="240px" OnSelectionChanged="Calendar1_SelectionChanged">
                  <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                  <NextPrevStyle VerticalAlign="Bottom" />
                  <OtherMonthDayStyle ForeColor="#808080" />
                  <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                  <SelectorStyle BackColor="#CCCCCC" />
                  <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                  <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                  <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
                <asp:Label ID="lblTxtCalError" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="Please select a Saturday or Sunday" Visible="False" Width="100%"></asp:Label>
                <br />
              </td>
              <td style="width:66%; vertical-align:top">
                <asp:Button ID="btnCancelReg" runat="server" Text="Cancel Registration" Visible="False" OnClick="btnCancelReg_Click" />
              </td>
            </tr>
          </table>
          <div style="padding:10px">
          <asp:Label ID="Label5" runat="server" Text="Dietary Requirements:"></asp:Label>
          <br />
            <asp:RadioButtonList ID="RdBtnLstDietReqs" runat="server">
            </asp:RadioButtonList>
            <br />
            <asp:Button ID="btnAddReg" runat="server" Text="Add Registration" OnClick="btnAddReg_Click" ToolTip="Enter your name" />
          <br />
          <br />
          <br />
          </div>
        </div>
        <asp:Label ID="lblStatus" runat="server" Width="100%"></asp:Label>
    </form>
</body>
</html>
