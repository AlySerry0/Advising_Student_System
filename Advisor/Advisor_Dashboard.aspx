<%@ Page Language="C#" EnableViewState="true" AutoEventWireup="true" CodeBehind="Advisor_Dashboard.aspx.cs" Inherits="WebApplication1.Advisor.Advisor_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="margin-left:auto; margin-right:auto;">
        <div runat="server" style="margin-left:auto; margin-right:auto;">
            <div style="height: auto">
                <div>
                    <asp:Button ID="B_A_Logout" runat="server" Text="Log Out" OnClick="B_A_Logout_Click" />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="L_Welcome" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                </div>
                <asp:Button ID="B_A_D_View_All_Students" runat="server" OnClick="B_A_D_View_All_Students_Click" Text="View All Students" Width="300px" />
                <br />
                <div id = "D_All_Students" runat = "server" visible = "false">
                    <asp:Label ID="L_Students" runat="server" Text="" style="height: auto"></asp:Label>
                    <br />
                    <asp:Button ID="B_Clear_Students" runat="server" Text="Clear" Width="100px" OnClick="B_Clear_Students_Click"/>
                </div>
            </div>
            <div style="height: auto">
                <asp:Button ID="B_A_D_Insert_Graduation_Plan" runat="server" OnClick="B_A_D_Insert_Graduation_Plan_Click" Text="Insert Graduation Plan" Width="300px" />
                <div id = "D_Gradplan_Insert" runat = "server" visible = "false">
                    <asp:Label ID="L_Semester_Code" runat="server" Text="Semester Code: "></asp:Label>
                    <asp:TextBox ID="TB_Semester_Code" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="L_Expected_Graduation_Date" runat="server" Text="Expected Graduation Date: "></asp:Label>
                    <asp:TextBox ID="TB_Expected_Graduation_Date" runat="server" TextMode =" Date"></asp:TextBox>
                    <br />
                    <asp:Label ID="L_Semester_Credit_Hours" runat="server" Text="Semester Credit Hours: "></asp:Label>
                    <asp:TextBox ID="TB_Semester_Credit_Hours" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="L_Student_ID" runat="server" Text="Student ID: "></asp:Label>
                    <asp:TextBox ID="TB_Student_ID" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="B_Gradplan_Insert_Cancel" runat="server" Text="Cancel" Width="100px" OnClick="B_Gradplan_Insert_Cancel_Click" />
                    <asp:Button ID="B_Gradplan_Insert_Confirm" runat="server" Text="Confirm" Width="100px" OnClick="B_Gradplan_Insert_Confirm_Click" />
                    <asp:Label ID="L_Gradplan_Insert_Out" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div style="height: auto">
                <asp:Button ID="B_A_D_Insert_Course" runat="server" Text="Insert Course" Width="300px" OnClick="B_A_D_Insert_Course_Click" />
                <div id = "D_Insert_Course" runat = "server" visible = "false">
                    <asp:Label ID="L_Student_ID2" runat="server" Text="Student ID: "></asp:Label>
                    <asp:TextBox ID="TB_Student_ID2" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="L_Semester_Code2" runat="server" Text="Semester Code: "></asp:Label>
                    <asp:TextBox ID="TB_Semester_Code2" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="L_Course_Name" runat="server" Text="Course Name: "></asp:Label>
                    <asp:TextBox ID="TB_Course_Name" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="B_Insert_Course_Cancel" runat="server" Text="Cancel" Width="100px" OnClick="B_Insert_Course_Cancel_Click" />
                    <asp:Button ID="B_Insert_Course_Confirm" runat="server" Text="Confirm" Width="100px" OnClick="B_Insert_Course_Confirm_Click" />
                    <asp:Label ID="L_Insert_Course_Out" runat="server" Text=""></asp:Label>
                    </div>
            </div>
            <div style="height: auto">
                <asp:Button ID="B_A_D_Update_Expected_Graduation_Date" runat="server" Text="Update Expected Graduation Date" Width="300px" OnClick="B_A_D_Update_Expected_Graduation_Date_Click" />
                <div id ="D_Update_Expected_Graduation_Date" runat = "server" visible = "false">
                    <asp:Label ID="L_Updated_Graduation_Date" runat="server" Text="Updated Graduation Date: "></asp:Label>
                    <asp:TextBox ID="TB_Updated_Graduation_Date" runat="server" TextMode =" Date"></asp:TextBox>
                    <br />
                    <asp:Label ID="L_Student_ID3" runat="server" Text="Student ID: "></asp:Label>
                    <asp:TextBox ID="TB_Student_ID3" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="B_Update_Expected_Graduation_Date_Cancel" runat="server" Text="Cancel" Width="100px" OnClick="B_Update_Expected_Graduation_Date_Cancel_Click" />
                    <asp:Button ID="B_Update_Expected_Graduation_Date_Confirm" runat="server" Text="Confirm" Width="100px" OnClick="B_Update_Expected_Graduation_Date_Confirm_Click" />
                    <asp:Label ID="L_Update_Expected_Graduation_Date_Out" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div style="height: auto">
                <asp:Button ID="B_A_D_Delete_Course_Graduation_Plan" runat="server" Text="Delete Course From Graduation Plan" Width="300px" OnClick="B_A_D_Delete_Course_Graduation_Plan_Click" />
                <div id ="D_Delete_Course_Graduation_Plan" runat = "server" visible = "false">
                    <asp:Label ID="L_Student_ID4" runat="server" Text="Student ID: "></asp:Label>
                    <asp:TextBox ID="TB_Student_ID4" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="L_Semester_Code3" runat="server" Text="Semester Code: "></asp:Label>
                    <asp:TextBox ID="TB_Semester_Code3" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="L_Course_ID" runat="server" Text="Course ID: "></asp:Label>
                    <asp:TextBox ID="TB_Course_ID" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="B_Delete_Course_Graduation_Plan_Cancel" runat="server" Text="Cancel" Width="100px" OnClick="B_Delete_Course_Graduation_Plan_Cancel_Click" />
                    <asp:Button ID="B_Delete_Course_Graduation_Plan_Confirm" runat="server" Text="Confirm" Width="100px" OnClick="B_Delete_Course_Graduation_Plan_Confirm_Click" />
                    <asp:Label ID="L_Delete_Course_Graduation_Plan_Out" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div style="height: auto">
                <asp:Button ID="B_A_D_View_All_Students_Major_Courses" runat="server" OnClick="B_A_D_View_All_Students_Major_Courses_Click" Width="300px" Text="View All Students/Major/Course" />
                <div id ="D_View_All_Students_Major_Courses" runat="server" visible =" false">
                    <asp:Label ID="L_Major" runat="server" Text="Student Major: "></asp:Label>
                    <asp:TextBox ID="TB_Major" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="B_View_All_Students_Major_Courses_Cancel" runat="server" Text="Cancel" Width="100px" OnClick="B_View_All_Students_Major_Courses_Cancel_Click" />
                    <asp:Button ID="B_View_All_Students_Major_Courses_Confirm" runat="server" Text="Confirm" Width="100px" OnClick="B_View_All_Students_Major_Courses_Confirm_Click" />
                    <div id ="D_View_All_Students_Major_Courses_Students" runat="server" style="margin-left: 40px">
                    <asp:Label ID="L_View_All_Students_Major_Courses" runat="server" Text=""></asp:Label>
                        <br />
                    <asp:Button ID="B_View_All_Students_Major_Courses_Clear" runat="server" Visible = "false" Text="Clear" Width="100px" OnClick="B_View_All_Students_Major_Courses_Clear_Click" />
                    </div>
                </div>
            </div>
            <div style="height: auto">
                <asp:Button ID="B_A_D_View_All_Requests" runat="server" Text="View All Requests" Width="300px" OnClick="B_A_D_View_All_Requests_Click" />
                <div id ="D_View_All_Requests" runat="server" visible =" false">
                    <asp:Button ID="B_View_All_Requests_Cancel" runat="server" Text="Cancel" Width="100px" OnClick="B_View_All_Requests_Cancel_Click" />
                    <asp:Button ID="B_View_All_Requests" runat="server" Text="All" Width="100px" OnClick="B_View_All_Requests_Click" />
                    <asp:Button ID="B_View_Pending_Requests" runat="server" Text="Pending" Width="100px" OnClick="B_View_Pending_Requests_Click" />
                    &nbsp;<asp:Table ID="T_Requests" runat="server" Visible ="false" EnableViewState="true" ViewStateMode="Enabled">
                    </asp:Table>
                    <asp:Button ID="B_View_Requests_Clear" runat="server" OnClick="B_View_Requests_Clear_Click" Text="Clear" Width="100px" Visible =" false"/>
                    <br />
                    <div id ="D_Update_Request" runat="server" visible =" false">
                        <asp:Label ID="L_Request_ID" runat="server" Text="Request ID: "></asp:Label>
                        <asp:TextBox ID="TB_Request_ID" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="B_Update" runat="server" Text="Update" OnClick="B_Update_Click" Width="100px"/>
                        <asp:Label ID="L_Update_Out" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html> 
