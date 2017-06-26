<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="width: 100%; height: 100%">
    <div>
    
        <asp:CheckBox ID="chkAssassin" runat="server" AutoPostBack="True" OnCheckedChanged="Check_Clicked" Text="刺客" />
        <asp:CheckBox ID="chkTank" runat="server" AutoPostBack="True" OnCheckedChanged="Check_Clicked" Text="坦克" />
        <asp:CheckBox ID="chkMaster" runat="server" AutoPostBack="True" OnCheckedChanged="Check_Clicked" Text="法師" />
        <asp:CheckBox ID="chkAid" runat="server" AutoPostBack="True" OnCheckedChanged="Check_Clicked" Text="輔助" />
        <asp:CheckBox ID="chkFighters" runat="server" AutoPostBack="True" OnCheckedChanged="Check_Clicked" Text="鬥士" />
        <asp:CheckBox ID="chkArcher" runat="server" AutoPostBack="True" OnCheckedChanged="Check_Clicked" Text="射手" />
        <asp:TextBox ID="textBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="btnSearch_Click" Text="Button" />
    
    </div>
        <asp:Panel ID="Panel1" runat="server" Width="100%">
        </asp:Panel>
    </form>
</body>
</html>
