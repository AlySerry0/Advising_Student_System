<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_Homepage.aspx.cs" Inherits="WebApplication1.Advisor_HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="B_Advisor_Homepage_Register" runat="server" Text="Register" OnClick="B_Advisor_Homepage_Register_Click" />
            <br />

            <br />
            &nbsp;&nbsp;
            <asp:Button ID="B_Advisor_Homepage_Login" runat="server" Text="Login" OnClick="B_Advisor_Homepage_Login_Click" />
        </div>
    </form>
</body>
</html>
