<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="WebApplication1.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div width =" auto" style="vertical-align: middle; text-align: center">
            <asp:Button ID="B_Student" runat="server" Text="Student" width="100px" OnClick="B_Student_Click"/>
            <br />
            <asp:Button ID="B_Advisor" runat="server" Text="Advisor" width="100px" OnClick="B_Advisor_Click"/>
            <br />
            <asp:Button ID="B_Admin" runat="server" Text="Admin" width="100px" OnClick="B_Admin_Click"/>
        </div>
    </form>
</body>
</html>
