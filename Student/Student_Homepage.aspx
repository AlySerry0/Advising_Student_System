<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Homepage.aspx.cs" Inherits="WebApplication1.Student.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="B_Back" runat="server" Width = "100px" Text="Back" OnClick="B_Back_Click" />
        <div style="vertical-align: middle; text-align: center">
           <asp:Label ID="Label" runat="server" Text="Accessed as Student."></asp:Label>
            <br />
            <asp:Button ID="B_Student_Homepage_Register" runat="server" Width="100px" Text="Register" OnClick="B_Student_Homepage_Register_Click"/>
            <br />
            <asp:Button ID="B_Student_Homepage_Login" runat="server" Width="100px" Text="Login" OnClick="B_Student_Homepage_Login_Click"/>
        </div>
    </form>
</body>
</html>
