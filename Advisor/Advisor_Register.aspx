<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_Register.aspx.cs" Inherits="WebApplication1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1">
            Register<br />
            &nbsp;&nbsp;&nbsp;
            Name:
            <asp:TextBox ID="A_R_name" runat="server"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;
            Password:
             <asp:TextBox ID="A_R_password" runat="server"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;
            Email:
             <asp:TextBox ID="A_R_email" runat="server"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;
            Office:
             <asp:TextBox ID="A_R_office" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="B_Register_Cancel" runat="server" OnClick="register_cancel" Text="Cancel" />
            <asp:Button ID="B_Register_Confirm" runat="server" OnClick="register_confirm" Text="Confirm"/>
        </div>
    </form>
</body>
</html>
