<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Login.aspx.cs" Inherits="WebApplication1.Student.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please Enter Your Details:<br />
            ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="S_L_id" runat="server"></asp:TextBox>
            <br />
            Password:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="S_L_password" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="B_Login_Cancel" runat="server" Text="Cancel" OnClick="Login_Cancel" />
            <asp:Button ID="B_Login_Confirm" runat="server" Text="Confirm" OnClick="Login_Confirm" />
        </div>
    </form>
</body>
</html>
