<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Register.aspx.cs" Inherits="WebApplication1.Student.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Register<br />
            First Name:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="S_R_firstname" runat="server"></asp:TextBox>
            <br />
            Last Name:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="S_R_lastname" runat="server"></asp:TextBox>
            <br />
            Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="S_R_password" runat="server"></asp:TextBox>
            <br />
            Faculty:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="S_R_faculty" runat="server"></asp:TextBox>
            <br />
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="S_R_email" runat="server"></asp:TextBox>
            <br />
            Major:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="S_R_major" runat="server"></asp:TextBox>
            <br />
            Semester:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="S_R_semester" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="B_Register_Cancel" runat="server" Text="Cancel" OnClick="register_cancel" />
            <asp:Button ID="B_Register_Confirm" runat="server" Text="Confirm" OnClick="register_confirm" />
        </div>
    </form>
</body>
</html>
