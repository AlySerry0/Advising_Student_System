<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Homepage.aspx.cs" Inherits="WebApplication1.Admin.Admin_Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="B_Admin_Back" runat="server" Text="Back" OnClick="B_Admin_Back_Click" />
            <br />
            <div style="margin-left: 40px">
                <asp:Label ID="L_Login" runat="server" Text="Admin, Please enter your UserID and Password."></asp:Label>
                <br />
                <asp:Label ID="L_UserID" runat="server" Text="UserID: "></asp:Label>
                <asp:TextBox ID="TB_UserID" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="L_Password" runat="server" Text="Password: "></asp:Label>
                <asp:TextBox ID="TB_Password" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="B_Login" runat="server" Width=" 100px" Text="Login" OnClick="B_Login_Click" />

                <asp:Label ID="L_Login_Out" runat="server" Text=""></asp:Label>

            </div>
        </div>
    </form>
</body>
</html>
