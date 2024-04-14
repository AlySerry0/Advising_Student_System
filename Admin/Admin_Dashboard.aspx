<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Dashboard.aspx.cs" Inherits="WebApplication1.Admin.Admin_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div >
            <asp:Button ID="B_Admin_Logout" runat="server" Text="Log Out" width="100px" OnClick="B_Admin_Logout_Click"/>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="L_Welcome" runat="server" Text="Welcome Admin"></asp:Label>
            <br />
            <br />
        </div>
        <div>

            <asp:Button ID="B_Admin_View_All_Advisors" runat="server" Width="300px" Text="View All Advisors" OnClick="B_Admin_View_All_Advisors_Click" />
            <div id="D_Advisors" runat="server" visible="false">
                <asp:Label ID="L_Advisors" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="B_View_All_Advisors_Clear" runat="server" Width="100px" Text="Clear" OnClick="B_View_All_Advisors_Clear_Click" />
            </div>
        </div>
        <div>

            <asp:Button ID="B_Admin_View_All_Students_Advisors" runat="server" Width="300px" Text="View All Students/Advisors" OnClick="B_Admin_View_All_Students_Advisors_Click" />
            <div id="D_Students_Advisors" runat="server" visible="false">
                <asp:Label ID="L_Students_Advisors" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="B_View_All_Students_Advisors_Clear" runat="server" Width="100px" Text="Clear" OnClick="B_View_All_Students_Advisors_Clear_Click" />
            </div>
        </div>
        <div>

            <asp:Button ID="B_Admin_View_All_Requests" runat="server" Width = "300px" Text="View All Requests" OnClick="B_Admin_View_All_Requests_Click" />
            <div id="D_Requests" runat="server" visible="false">
                <asp:Table ID="T_All_Requests" runat="server"></asp:Table>
                <asp:Button ID="B_View_All_Requests_Clear" runat="server" Width = "100px" Text="Clear" OnClick="B_View_All_Requests_Clear_Click" />
            </div>
        </div>
        <div>

            <asp:Button ID="B_Admin_Add_New_Semester" runat="server" Width = "300px" Text="Add New Semester" OnClick="B_Admin_Add_New_Semester_Click" />
            <div id="D_Add_New_Semester" runat="server" visible="false">

                <asp:Label ID="L_Start_Date" runat="server" Text="Start Date: "></asp:Label>
                <asp:TextBox ID="TB_Start_Date" TextMode =" Date" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="L_End_Date" runat="server" Text="End Date: "></asp:Label>
                <asp:TextBox ID="TB_End_Date" TextMode ="Date" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="L_Semester_Code" runat="server" Text="Semester Code: "></asp:Label>
                <asp:TextBox ID="TB_Semester_Code" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="B_Add_Semester_Cancel" runat="server" Width = "100px" Text="Cancel" OnClick="B_Add_Semester_Cancel_Click" />
                <asp:Button ID="B_Add_Semester_Confirm" runat="server" Width = "100px" Text="Confirm" OnClick="B_Add_Semester_Confirm_Click" />
                <asp:Label ID="L_Add_Semester_Out" runat="server" Text=""></asp:Label>
            </div>

        </div>
        <div>
            <asp:Button ID="B_Admin_Add_New_Course" runat="server" Width = "300px" Text="Add New Course" OnClick="B_Admin_Add_New_Course_Click" />
            <div id="D_Add_New_Course" runat="server" visible="false">
                 <asp:Label ID="L_Major" runat="server" Text="Major: "></asp:Label>
                 <asp:TextBox ID="TB_Major" runat="server"></asp:TextBox>
                 <br />
                 <asp:Label ID="L_Semester" runat="server" Text="Semester: "></asp:Label>
                 <asp:TextBox ID="TB_Semester" runat="server"></asp:TextBox>
                 <br />
                 <asp:Label ID="L_Credit_Hours" runat="server" Text="Credit Hours: "></asp:Label>
                 <asp:TextBox ID="TB_Credit_Hours" runat="server"></asp:TextBox>
                 <br />
                 <asp:Label ID="L_Name" runat="server" Text="Name: "></asp:Label>
                 <asp:TextBox ID="TB_Name" runat="server"></asp:TextBox>
                 <br />
                 <asp:Label ID="L_isOffered" runat="server" Text="isOffered: "></asp:Label>
                 <asp:CheckBox ID="CB_isOffered" runat="server" />
                 <br />
                 <asp:Button ID="B_Add_New_Course_Cancel" runat="server" Width = "100px" Text="Cancel" OnClick="B_Add_Course_Cancel_Click" />
                 <asp:Button ID="B_Add_New_Course_Confirm" runat="server" Width = "100px" Text="Confirm" OnClick="B_Add_Course_Confirm_Click" />
                 <asp:Label ID="L_Add_New_Course_Out" runat="server" Text=""></asp:Label>
             </div>
        </div>
        <div>
            <asp:Button ID="B_Admin_Update_Slot" runat="server" Width = "300px" Text="Update Slot" OnClick="B_Admin_Update_Slot_Click" />
            <div id="D_Update_Slot" runat="server" visible="false">
                    <asp:Label ID="L_CourseID" runat="server" Text="Course ID: "></asp:Label>
                    <asp:TextBox ID="TB_CourseID" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="L_InstructorID" runat="server" Text="Instructor ID: "></asp:Label>
                    <asp:TextBox ID="TB_InstructorID" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="L_SlotID" runat="server" Text="Slot ID: "></asp:Label>
                    <asp:TextBox ID="TB_SlotID" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="B_Update_Slot_Cancel" runat="server" Width = "100px" Text="Cancel" OnClick="B_Update_Slot_Cancel_Click" />
                    <asp:Button ID="B_Update_Slot_Confirm" runat="server" Width = "100px" Text="Confirm" OnClick="B_Update_Slot_Confirm_Click" />
                    <asp:Label ID="L_Update_Slot_Out" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div>
            <asp:Button ID="B_Admin_Link_Student_Advisor" runat="server" Width = "300px" Text="Link Student To Advisor" OnClick="B_Admin_Link_Student_Advisor_Click" />
            <div id="D_Link_Student_Advisor" runat="server" visible="false">
                    <asp:Label ID="L_StudentID" runat="server" Text="Student ID: "></asp:Label>
                    <asp:TextBox ID="TB_StudentID" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="L_AdvisorID" runat="server" Text="Advisor ID: "></asp:Label>
                    <asp:TextBox ID="TB_AdvisorID" runat="server"></asp:TextBox>
                    <br />

                    <asp:Button ID="B_Link_Student_Advisor_Cancel" runat="server" Width = "100px" Text="Cancel" OnClick="B_Link_Student_Advisor_Cancel_Click" />
                    <asp:Button ID="B_Link_Student_Advisor_Confirm" runat="server" Width = "100px" Text="Confirm" OnClick="B_Link_Student_Advisor_Confirm_Click" />
                    <asp:Label ID="L_Link_Student_Advisor_Out" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div>
            <asp:Button ID="B_Admin_Link_Student_Course_Instructor" runat="server" Width = "300px" Text="Link Student/Course/Instructor" OnClick="B_Admin_Link_Student_Course_Instructor_Click" />
            <div id="D_Link_Student_Course_Instructor" runat="server" visible="false">
                <asp:Label ID="L_CourseID2" runat="server" Text="Course ID: "></asp:Label>
                <asp:TextBox ID="TB_CourseID2" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="L_InstructorID2" runat="server" Text="Instructor ID: "></asp:Label>
                <asp:TextBox ID="TB_InstructorID2" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="L_StudentID2" runat="server" Text="Student ID: "></asp:Label>
                <asp:TextBox ID="TB_StudentID2" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="L_Semester_Code2" runat="server" Text="Semester Code: "></asp:Label>
                <asp:TextBox ID="TB_Semester_Code2" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="B_Link_Student_Course_Instructor_Cancel" runat="server" Width = "100px" Text="Cancel" OnClick="B_Link_Student_Course_Instructor_Cancel_Click" />
                <asp:Button ID="B_Link_Student_Course_Instructor_Confirm" runat="server" Width = "100px" Text="Confirm" OnClick="B_Link_Student_Course_Instructor_Confirm_Click"/>
                <asp:Label ID="L_Link_Student_Course_Instructor_Out" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div>
            <asp:Button ID="B_Admin_View_Instructors_Courses" runat="server" Width="300px" Text="View All Instructors/Courses" OnClick="B_Admin_View_Instructors_Courses_Click" />
            <div id="D_Instructors_Courses" runat="server" visible="false">
                <asp:Label ID="L_Instructors_Courses" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="B_View_Instructors_Courses_Clear" runat="server" Width="100px" Text="Clear" OnClick="B_View_Instructors_Courses_Clear_Click" />
            </div>
        </div>
        <div>
            <asp:Button ID="B_Admin_View_Semesters_Courses" runat="server" Width="300px" Text="View All Semesters/Courses" OnClick="B_Admin_View_Semesters_Courses_Click" />
            <div id="D_Semesters_Courses" runat="server" visible="false">
                <asp:Label ID="L_Semesters_Courses" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="B_View_Semesters_Courses_Clear" runat="server" Width="100px" Text="Clear" OnClick="B_View_Semesters_Courses_Clear_Click" />
            </div>
        <div style="height: auto">
            <asp:Button ID="B_Delete_Course" runat="server" Text="Delete Course" OnClick="B_Delete_Course_Click" Width="300px" />
            <div id="D_Delete_Course" runat="server" style="height: auto" visible="false">
                Course ID:<asp:TextBox ID="T_Delete_C_ID" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="L_1" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="B_Delete_Course_Cancel" runat="server" Width = "100px" Text="Cancel" OnClick="B_Delete_Course_Cancel_Click" />
                <asp:Button ID="B_Delete_Course_Confirm" runat="server" Width = "100px" Text="Confirm" OnClick="B_Delete_Course_Confirm_Click" />
            </div>
        </div>
        <div style="height: auto">
            <asp:Button ID="B_Delete_Slot" runat="server" Text="Delete Slot Of A Specific Course" OnClick="B_Delete_Slot_Click" Width="300px" />
            <div id="D_Delete_Slot" runat="server" style="height: auto" visible="false">
                Course ID:<asp:TextBox ID="T_Delete_S_C_ID" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="L_2" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="B_Delete_Slot_Cancel" runat="server" Width = "100px" Text="Cancel" OnClick="B_Delete_Slot_Cancel_Click" />
                <asp:Button ID="B_Delete_Slot_Confirm" runat="server" Width = "100px" Text="Confirm" OnClick="B_Delete_Slot_Confirm_Click" />
            </div>
        </div>
        <div style="height: auto">
            <asp:Button ID="B_Add_Exam" runat="server" Text="Add Makeup Exam" OnClick="B_Add_Exam_Click" Width="300px" />
            <div id="D_Add_Exam" runat="server" style="height: auto" visible="false">
                Course ID:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="T_AE_C_ID" runat="server"></asp:TextBox>
                <br />
                Exam Type:&nbsp; <asp:TextBox ID="T_AE_Type" runat="server"></asp:TextBox>
                <br />
                 Date :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="T_AE_Date" runat="server" TextMode="Date"></asp:TextBox>
                <br />
                <asp:Label ID="L_3" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="B_Add_Exam_Cancel" runat="server" Width = "100px" Text="Cancel" OnClick="B_Add_Exam_Cancel_Click" />
                <asp:Button ID="B_Add_Exam_Confirm" runat="server" Width = "100px" Text="Confirm" OnClick="B_Add_Exam_Confirm_Click" />
            </div>
        </div>
        <div style="height: auto">
            <asp:Button ID="B_View_Payments" runat="server" Text="View All Payments" OnClick="B_View_Payments_Click" Width="300px" />
            <div id="D_View_Payments" runat="server" style="height: auto" visible="false">
                <asp:Label ID="L_4" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="B_View_Payments_Clear" runat="server" Width = "100px" Text="Clear" OnClick="B_View_Payments_Clear_Click" />
            </div>
        </div>
         <div style="height: auto">
            <asp:Button ID="B_Issue_Installments" runat="server" Text="Issue Installments" OnClick="B_Issue_Installments_Click" Width="300px" />
            <div id="D_Issue_Installments" runat="server" style="height: auto" visible="false">
                Payment ID:<asp:TextBox ID="T_II_PID" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="L_5" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="B_Issue_Installments_Cancel" runat="server" Width = "100px" Text="Cancel" OnClick="B_Issue_Installments_Cancel_Click" />
                <asp:Button ID="B_Issue_Installments_Confirm" runat="server" Width = "100px" Text="Confirm" OnClick="B_Issue_Installments_Confirm_Click" />
             </div>
        </div>
            <asp:Button ID="B_Admin_Update_Student_Status" runat="server" Width = "300px" Text="Update Student Status" OnClick="B_Admin_Update_Student_Status_Click" />
            <div id="D_Update_Student_Status" runat="server" visible="false">
                <asp:Label ID="L_StudentID3" runat="server" Text="Student ID: "></asp:Label>
                <asp:TextBox ID="TB_StudentID3" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="B_Update_Student_Status_Cancel" runat="server" Width = "100px" Text="Cancel" OnClick="B_Update_Student_Status_Cancel_Click" />
                <asp:Button ID="B_Update_Student_Status_Confirm" runat="server" Width = "100px" Text="Confirm" OnClick="B_Update_Student_Status_Confirm_Click"/>
                <asp:Label ID="L_Update_Student_Status_Out" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div>
            <asp:Button ID="B_Admin_View_All_Active_Students" runat="server" Width="300px" Text="View All Active Students" OnClick="B_Admin_View_All_Active_Students_Click" />
            <div id="D_Active_Students" runat="server" visible="false">
                <asp:Label ID="L_Active_Students" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="B_View_All_Active_Students_Clear" runat="server" Width="100px" Text="Clear" OnClick="B_View_All_Active_Students_Clear_Click" />
            </div>
        </div>
        <div>
            <asp:Button ID="B_Admin_View_Gradplan_Advisor" runat="server" Width="300px" Text="View All Graduation Plans and Related Advisor" OnClick="B_Admin_View_Gradplan_Advisor_Click" />
            <div id="D_Gradplan_Advisor" runat="server" visible="false">
                <asp:Label ID="L_Gradplan_Advisor" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="B_View_Gradplan_Advisor_Clear" runat="server" Width="100px" Text="Clear" OnClick="B_View_Gradplan_Advisor_Clear_Click" />
            </div>
        </div>
        <div>
            <asp:Button ID="B_Admin_View_Students_Transcript" runat="server" Width="300px" Text="View All Students Transcript" OnClick="B_Admin_View_Students_Transcript_Click" />
            <div id="D_Students_Transcript" runat="server" visible="false">
                <asp:Label ID="L_Students_Transcript" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="B_View_Students_Transcript_Clear" runat="server" Width="100px" Text="Clear" OnClick="B_View_Students_Transcript_Clear_Click" />
            </div>
        </div>
    </form>
</body>
</html>
