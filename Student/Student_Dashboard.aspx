<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Dashboard.aspx.cs" Inherits="WebApplication1.Student.Student_Dashboard" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>

                <asp:Button ID="B_Logout" runat="server" Width="100px" Text="Log Out" OnClick="B_Logout_Click" />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:Label ID="L_Welcome" runat="server" Text=""></asp:Label>

                <br />

            </div>
            <div style="height: auto">
                <asp:Button ID="B_S_PN" runat="server" Text="Add A Phone Number" OnClick="SPN_add1_Click" Width="350px" />
                <div id="D_PN" runat="server" visible="false">
                    Phone Number:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="S_phonenumber" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:Button ID="S_PN_Cancel" runat="server" Text="Cancel" OnClick="SPN_Cancel_Click" />
                    <asp:Button ID="S_PN_add" runat="server" Text="Add" OnClick="SPN_add_Click" Width="77px" />
                    <br />
                    <asp:Label ID="R1" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div style="height: auto">
                <asp:Button ID="B_Request" runat="server" Text="Submit a Request" Width="350px" OnClick="B_Request_Click" />
                <div id="D_REQUEST" runat="server" visible="false">
                    <asp:ScriptManager ID="asm" runat="server" />
                    <br />
                    Course:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="C_Course" runat="server"/>
                    <ajaxToolkit:MutuallyExclusiveCheckBoxExtender ID="C_Course_MutuallyExclusiveCheckBoxExtender" runat="server" TargetControlID="C_Course" Key="YesNo"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CourseID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="SR_CID" runat="server"></asp:TextBox>
                    <br />
                    Credit Hours:<asp:CheckBox ID="C_Credit_Hours" runat="server" />
                    <ajaxToolkit:MutuallyExclusiveCheckBoxExtender ID="C_Credit_Hours_MutuallyExclusiveCheckBoxExtender" runat="server" TargetControlID="C_Credit_Hours" Key="YesNo"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Credit Hours Amount:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="SR_CH" runat="server"></asp:TextBox>
                    <br />
                    Comment:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="SR_Comment" runat="server" Height="47px" Width="387px" ></asp:TextBox>
                    <br />
                    <asp:Button ID="B_R_cancel" runat="server" Text="Cancel" Width="247px" OnClick="B_request_Cancel" />
                    <asp:Button ID="B_R_confirm" runat="server" Text="Confirm" Width="247px" OnClick="B_request_Confirm" />
                    <br />
                    <asp:Label ID="R2" runat="server" Text=""></asp:Label>
                    <br />
                </div>
            </div>
            <div style="height: auto">
                <asp:Button ID="B_ViewGP" runat="server" Text="View Graduation Plan" OnClick="B_ViewGP_Click" Width="350px" />
                <br />
                <div id="D_GP" runat="server" visible="false">
                    <asp:Label ID="R4" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Button ID="B_GP_Clear" runat="server" Text="Clear" Width="350px" OnClick="B_GP_Clear_Click" />
                </div>
            </div>
            <div style="height: auto">
                 <asp:Button ID="B_View_Unpaid_Installment" runat="server" Text="View Upcoming Unpaid Installment" OnClick="B_View_Unpaid_Installment_Click" Width="350px" />
                 <br />
                 <asp:Label ID="R5" runat="server" Text=""></asp:Label>
                 <div id="D_Unpaid_Installment" runat="server" visible="false">
                      <asp:Button ID="B_Unpaid_Installment_Clear" runat="server" Text="Clear" Width="350px" OnClick="B_Unpaid_Installment_Clear_Click" />
                 </div>
            </div>
            <div style="height: auto">
                 <asp:Button ID="B_View_Course_Exam" runat="server" Text="View Course Exams" OnClick="B_View_Course_Exam_Click" Width="350px" />
                 <br />
                 <asp:Label ID="R6" runat="server" Text=""></asp:Label>
                 <div id="D_View_Course_Exam" runat="server" visible="false">
                       <asp:Button ID="B_View_Course_Exam_Clear" runat="server" Text="Clear" Width="350px" OnClick="B_View_Course_Exam_Clear_Click" />
                 </div>
            </div>
            <div style="height: auto">
                   <asp:Button ID="B_First_Makeup" runat="server" Text="Register for First Makeup" OnClick="B_First_Makeup_Click" Width="350px" />
                   <br />
                   <div id="D_First_Makeup" runat="server" visible="false">
                        Course ID:<asp:TextBox ID="T_Course_ID" runat="server" ></asp:TextBox>
                        <br />
                   <asp:Label ID="R7" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Button ID="B_First_Makeup_Clear" runat="server" Text="Clear" Width="175px" OnClick="B_First_Makeup_Clear_Click" />
                        <asp:Button ID="B_First_Makeup_Confirm" runat="server" Text="Confirm" Width="175px" OnClick="B_First_Makeup_Confirm_Click" />
                        <br />
                   </div>
            </div>
            <div style="height: auto">
                   <asp:Button ID="B_Second_Makeup" runat="server" Text="Register for Second Makeup" OnClick="B_Second_Makeup_Click" Width="350px" />
                   <br />
                   <div id="D_Second_Makeup" runat="server" visible="false">
                         Course ID:<asp:TextBox ID="T_Course_ID2" runat="server" ></asp:TextBox>
                          <br />
                         <asp:Label ID="R8" runat="server" Text=""></asp:Label>
                          <br />
                          <asp:Button ID="B_Second_Makeup_Clear" runat="server" Text="Clear" Width="175px" OnClick="B_Second_Makeup_Clear_Click" />
                          <asp:Button ID="B_Second_Makeup_Confirm" runat="server" Text="Confirm" Width="175px" OnClick="B_Second_Makeup_Confirm_Click" />
                          <br />
                  </div>
            </div>
            <div style="height: auto">
                <asp:Button ID="B_View_Course_Slot" runat="server" Text="View All Course Slot Details" OnClick="B_View_Course_Slot_Click" Width="350px" />
                <br />
                <asp:Label ID="R9" runat="server" Text=""></asp:Label>
                <div id="D_View_Course_Slot" runat="server" visible="false">
                      <asp:Button ID="B_View_Course_Slot_Clear" runat="server" Text="Clear" Width="350px" OnClick="B_View_Course_Slot_Clear_Click" />
                </div>
            </div>
             <div style="height: auto">
                  <asp:Button ID="B_View_Course_Slot2" runat="server" Text="View Specific Course Slot Details" OnClick="B_View_Course_Slot2_Click" Width="350px" />
                  <br />
                  <asp:Label ID="R10" runat="server" Text=""></asp:Label>
                  <div id="D_View_Course_Slot2" runat="server" visible="false">

                         Course ID:&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="T_VCS_CID" runat="server" Height="16px"></asp:TextBox>
                         <br />
                         Instructor ID:<asp:TextBox ID="T_VCS_IID" runat="server"></asp:TextBox>
                         <br />
                         <asp:Button ID="B_View_Course_Slot2_Clear" runat="server" Text="Clear" Width="175px" OnClick="B_View_Course_Slot2_Clear_Click" />
                         <asp:Button ID="B_View_Course_Slot2_Confirm" runat="server" Text="Confirm" Width="175px" OnClick="B_View_Course_Slot2_Clear_Confirm" />
                  </div>
            </div>
             <div style="height: auto">
                 <asp:Button ID="B_Choose_Instuctor" runat="server" Text="Choose Instructor For A Specific Course" OnClick="B_Choose_Instuctor_Click" Width="350px" />
                 <br />
                 <asp:Label ID="R11" runat="server" Text=""></asp:Label>
                 <div id="D_Choose_Instuctor" runat="server" visible="false">

                    Course ID:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="T_C_ID" runat="server" Height="16px"></asp:TextBox>
                    <br />
                     Instructor ID:<asp:TextBox ID="T_I_ID" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="B_Choose_Instuctor_Clear" runat="server" Text="Clear" Width="175px" OnClick="B_Choose_Instuctor_Clear_Click" />
                    <asp:Button ID="B_Choose_Instuctor_Confirm" runat="server" Text="Confirm" Width="175px" OnClick="B_Choose_Instuctor_Confirm_Click" />
                </div>
            </div>
             <div style="height: auto">
                 <asp:Button ID="B_View_Course_Prerequisites" runat="server" Text="View All Course Prerequisites" OnClick="B_View_Course_Prerequisites_Click" Width="350px" />
                 <br />
                 <div id="D_View_Course_Prerequisites" runat="server" visible="false">
                 <asp:Label ID="R12" runat="server" Text=""></asp:Label>
                         <br />
                         <asp:Button ID="B_View_Course_Prerequisites_Clear" runat="server" Text="Clear" Width="350px" OnClick="B_View_Course_Prerequisites_Clear_Click" />
                 </div>
            </div>
            <div style="height: auto">
                <asp:Button ID="S_OC" runat="server" Text="View optional courses" OnClick="S_OC_Click" />
                <asp:Button ID="S_AC" runat="server" Text="View available courses" OnClick="S_AC_Click" />
                <asp:Button ID="S_RC" runat="server" Text="View required courses" OnClick="S_RC_Click" />
                <asp:Button ID="S_MC" runat="server" Text="View missing courses" OnClick="S_MC_Click" />
                
                <br />
                <asp:Label ID="R3" runat="server" Text=""></asp:Label>
                <div id="D_Course" runat="server" visible="false">
                    <asp:Button ID="B_C_Clear" runat="server" Text="Clear" OnClick="B_C_Clear_Click" />
                </div>
                <br />
                
            </div>
        </div>
    </form>
</body>
</html>
