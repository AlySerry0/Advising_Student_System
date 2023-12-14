<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_Login.aspx.cs" Inherits="WebApplication1.Advisor_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please Enter Your Details:<br />
            ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="A_L_id" runat="server"></asp:TextBox>
            <br />
            Password:&nbsp;&nbsp; <asp:TextBox ID="A_L_password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="B_Login_Cancel" runat="server" OnClick="Login_Cancel" Text="Cancel" />
            <asp:Button ID="B_Login_Confirm" runat="server" OnClick="Login_Confirm" Text="Confirm" />
        </div>
    </form>
</body>
</html>
