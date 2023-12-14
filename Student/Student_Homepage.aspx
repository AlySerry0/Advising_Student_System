<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Homepage.aspx.cs" Inherits="WebApplication1.Student.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="B_Student_Homepage_Register" runat="server" Text="Register" OnClick="B_Student_Homepage_Register_Click" />
        </div>
        <p>
            <asp:Button ID="B_Student_Homepage_Login" runat="server" Text="Login" OnClick="B_Student_Homepage_Login_Click" />
        </p>
    </form>
</body>
</html>
