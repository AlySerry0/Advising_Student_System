using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1.Student
{
    public partial class Student_Dashboard : System.Web.UI.Page
    {
        int S_ID;
        String Current_Semester = "S24";
        protected void Page_Load(object sender, EventArgs e)
        {
            S_ID = Int16.Parse(Request.QueryString["msg"].ToString());
            String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            //SqlCommand S_GET_CS = new SqlCommand("select semester_code from semester where start_date <(CURRENT_TIMESTAMP) and end_date >(CURRENT_TIMESTAMP)", sqlConnection);


            //sqlConnection.Open();
            //SqlDataReader rdr = S_GET_CS.ExecuteReader(CommandBehavior.CloseConnection);
            //while (rdr.Read())
            //{
            //    String S_CS = rdr.GetString(rdr.GetOrdinal("semester_code"));
            //    Current_Semester = "S24";
            //}
            //sqlConnection.Close();
            SqlCommand getStudenttName = new SqlCommand("Select f_name,l_name From Student Where student_id = @StudentID", sqlConnection);
            getStudenttName.Parameters.Add(new SqlParameter("@StudentID", S_ID));

            sqlConnection.Open();
            SqlDataReader rdr = getStudenttName.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();
            String S_fname = rdr.GetString(rdr.GetOrdinal("f_name"));
            String S_lname = rdr.GetString(rdr.GetOrdinal("l_name"));
            sqlConnection.Close();
            L_Welcome.Text = "Welcome " + S_fname + " " + S_lname;
        }

        protected void SPN_add1_Click(object sender, EventArgs e)
        {
            D_PN.Visible = true;
        }
        protected void SPN_Cancel_Click(object sender, EventArgs e)
        {
            D_PN.Visible = false;
            R1.Text = "";
        }
        protected void SPN_add_Click(object sender, EventArgs e)
        {
            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
                SqlConnection sqlConnection = new SqlConnection(connStr);
                String S_pn = S_phonenumber.Text;
                if (S_pn == "")
                    R1.Text = "Please enter a phone number.";
                else
                {
                    SqlCommand S_PN_procedure = new SqlCommand("Procedures_StudentaddMobile", sqlConnection);
                    S_PN_procedure.CommandType = CommandType.StoredProcedure;
                    S_PN_procedure.Parameters.Add(new SqlParameter("@StudentID", S_ID));
                    S_PN_procedure.Parameters.Add(new SqlParameter("@mobile_number", S_pn));

                    sqlConnection.Open();
                    S_PN_procedure.ExecuteNonQuery();
                    sqlConnection.Close();
                    R1.Text = "Phone number successfully added!";
                }
            }
            catch (SqlException)
            {
                R1.Text = "Phone number has been added previously.";
            }
        }

        protected void B_Request_Click(object sender, EventArgs e)
        {
            D_REQUEST.Visible = true;
        }
        protected void B_request_Cancel(object sender, EventArgs e)
        {
            D_REQUEST.Visible = false;
            R2.Text = "";
        }

        protected void B_request_Confirm(object sender, EventArgs e)
        {
            try
            { 
                if(C_Course.Checked)
                {
                    String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
                    SqlConnection sqlConnection = new SqlConnection(connStr);
                    int S_CID = Int16.Parse(SR_CID.Text);
                    String S_type = "course";
                    String S_comment = SR_Comment.Text;
                    SqlCommand S_RQ_procedure = new SqlCommand("Procedures_StudentSendingCourseRequest", sqlConnection);
                    S_RQ_procedure.CommandType = CommandType.StoredProcedure;
                    S_RQ_procedure.Parameters.Add(new SqlParameter("@StudentID", S_ID));
                    S_RQ_procedure.Parameters.Add(new SqlParameter("@courseID", S_CID));
                    S_RQ_procedure.Parameters.Add(new SqlParameter("@type", S_type));
                    S_RQ_procedure.Parameters.Add(new SqlParameter("@comment", S_comment));

                    sqlConnection.Open();
                    S_RQ_procedure.ExecuteNonQuery();
                    sqlConnection.Close();
                    R2.Text = "Your Request has been submitted.";
                }
                else if (C_Credit_Hours.Checked)
                {

                    String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
                    SqlConnection sqlConnection = new SqlConnection(connStr);
                    int S_CH = Int16.Parse(SR_CH.Text);
                    String S_type = "credit hours";
                    String S_comment = SR_Comment.Text;
                    SqlCommand S_RQ_procedure = new SqlCommand("Procedures_StudentSendingCHRequest", sqlConnection);
                    S_RQ_procedure.CommandType = CommandType.StoredProcedure;
                    S_RQ_procedure.Parameters.Add(new SqlParameter("@StudentID", S_ID));
                    S_RQ_procedure.Parameters.Add(new SqlParameter("@credit_hours", S_CH));
                    S_RQ_procedure.Parameters.Add(new SqlParameter("@type", S_type));
                    S_RQ_procedure.Parameters.Add(new SqlParameter("@comment", S_comment));

                    sqlConnection.Open();
                    S_RQ_procedure.ExecuteNonQuery();
                    sqlConnection.Close();
                    R2.Text = "Your Request has been submitted.";
                }
                else
                    R2.Text = "Please enter your details.";

            }
            catch(FormatException)
            {
                R2.Text = "Request Submission Failed. Please enter the correct format.";
            }
        }
        protected void B_ViewGP_Click(object sender, EventArgs e)
        {
            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
                SqlConnection sqlConnection = new SqlConnection(connStr);

                SqlCommand S_View_GP = new SqlCommand("Select * from dbo.FN_StudentViewGP(@student_ID)", sqlConnection);
                S_View_GP.Parameters.Add(new SqlParameter("@student_ID", S_ID));
                sqlConnection.Open();
                SqlDataReader rdr = S_View_GP.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();
                Int32 PID = rdr.GetInt32(rdr.GetOrdinal("plan_id"));
                String SemCode = rdr.GetString(rdr.GetOrdinal("semester_code"));
                Int32 SemCH = rdr.GetInt32(rdr.GetOrdinal("semester_credit_hours"));
                DateTime Expected_Grad_Date = rdr.GetDateTime(rdr.GetOrdinal("expected_grad_date"));
                Int32 AID = rdr.GetInt32(rdr.GetOrdinal("advisor_id"));
                R4.Text = "Plan ID: " + PID + ", Semester Code:" + SemCode + ", Semester Credit Hours:" + SemCH + ", Expected Graduation Date:"
                          + Expected_Grad_Date.ToString("dd/M/yyyy") + ", Advisor ID:" + AID + "<br/>&nbsp;&nbsp;&nbsp;&nbsp; Courses:<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
                while (rdr.Read())
                {

                    String CName = rdr.GetString(rdr.GetOrdinal("name"));
                    Int32 CID = rdr.GetInt32(rdr.GetOrdinal("course_id"));

                    R4.Text = R4.Text + "" + CName + ", ID:" + CID + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
                }
                sqlConnection.Close();
                D_GP.Visible = true;
            }
            finally { }

        }

        protected void B_GP_Clear_Click(object sender, EventArgs e)
        {
            R4.Text = "";
            D_GP.Visible = false;
        }
        protected void B_View_Unpaid_Installment_Click(object sender, EventArgs e)
        {
            try
            {
                D_Unpaid_Installment.Visible = true;
                String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
                SqlConnection sqlConnection = new SqlConnection(connStr);

                SqlCommand S_View_Unpaid_Installment = new SqlCommand("Select dbo.FN_StudentUpcoming_installment(@student_ID)", sqlConnection);
                S_View_Unpaid_Installment.Parameters.AddWithValue("@student_ID", S_ID);
                sqlConnection.Open();
                SqlDateTime Installment_Date = Convert.ToDateTime(S_View_Unpaid_Installment.ExecuteScalar());
                sqlConnection.Close();
                R5.Text = "Your upcoming unpaid installment is due: " + Installment_Date + ".";
            }
            catch (InvalidCastException)
            {
                R5.Text = "You have no unpaid installments.";
            }
        }

        protected void B_Unpaid_Installment_Clear_Click(object sender, EventArgs e)
        {
            R5.Text = "";
            D_Unpaid_Installment.Visible = false;
        }
        protected void B_View_Course_Exam_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            R6.Text = "";
            SqlCommand S_View_Course_Exam = new SqlCommand("Select * from dbo.Students_Courses_transcript where student_id=@Student_ID", sqlConnection);
            S_View_Course_Exam.Parameters.Add(new SqlParameter("@Student_ID", S_ID));
            sqlConnection.Open();
            SqlDataReader rdr = S_View_Course_Exam.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String CName = rdr.GetString(rdr.GetOrdinal("name"));
                String ExamType = rdr.GetString(rdr.GetOrdinal("exam_type"));
                String Grade = "";
                try
                {
                    Grade = rdr.GetString(rdr.GetOrdinal("grade"));
                }
                catch { }
                    String Sem_Code = rdr.GetString(rdr.GetOrdinal("semester_code"));

                R6.Text = R6.Text + "Course: " + CName + ", Exam Type: " + ExamType + ", Grade: " + Grade + ", Exam Semester Code:" + Sem_Code + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_View_Course_Exam.Visible = true;
        }

        protected void B_View_Course_Exam_Clear_Click(object sender, EventArgs e)
        {
            R6.Text = "";
            D_View_Course_Exam.Visible = false;
        }
        protected void B_First_Makeup_Click(object sender, EventArgs e)
        {
            D_First_Makeup.Visible = true;
        }

        protected void B_First_Makeup_Clear_Click(object sender, EventArgs e)
        {
            R7.Text = "";
            D_First_Makeup.Visible = false;
        }

        protected void B_First_Makeup_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
                SqlConnection sqlConnection = new SqlConnection(connStr);
                String S_CID = T_Course_ID.Text;

                SqlCommand S_Register_F_Makeup = new SqlCommand("Procedures_StudentRegisterFirstMakeup", sqlConnection);
                S_Register_F_Makeup.CommandType = CommandType.StoredProcedure;
                S_Register_F_Makeup.Parameters.Add(new SqlParameter("@StudentID", S_ID));
                S_Register_F_Makeup.Parameters.Add(new SqlParameter("@courseID", S_CID));
                S_Register_F_Makeup.Parameters.Add(new SqlParameter("@studentCurr_sem", Current_Semester));

                SqlCommand S_Register_Sucess = new SqlCommand("Select exam_type from Student_Instructor_Course_take where student_id=@StudentID", sqlConnection);
                S_Register_Sucess.Parameters.Add(new SqlParameter("@StudentID", S_ID));
                sqlConnection.Open();
                

                if (S_CID == "")
                    R7.Text = "Please enter Course ID.";
                else
                {
                    S_Register_F_Makeup.ExecuteNonQuery();
                    String type = ((string)S_Register_Sucess.ExecuteScalar());
                    sqlConnection.Close();
                    if (type == "first_makeup")
                        R7.Text = "Success";
                    else
                        R7.Text = "Inelligible for first makeup.";

                }
            }
            finally { }
            
        }
        protected void B_Second_Makeup_Click(object sender, EventArgs e)
        {
            D_Second_Makeup.Visible = true;
        }

        protected void B_Second_Makeup_Clear_Click(object sender, EventArgs e)
        {
            R8.Text = "";
            D_Second_Makeup.Visible = false;
        }

        protected void B_Second_Makeup_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                    String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
                    SqlConnection sqlConnection = new SqlConnection(connStr);
                    String S_CID = T_Course_ID2.Text;

                    SqlCommand S_Register_F_Makeup = new SqlCommand("Procedures_StudentRegisterSecondMakeup", sqlConnection);
                    S_Register_F_Makeup.CommandType = CommandType.StoredProcedure;
                    S_Register_F_Makeup.Parameters.Add(new SqlParameter("@StudentID", S_ID));
                    S_Register_F_Makeup.Parameters.Add(new SqlParameter("@courseID", S_CID));
                    S_Register_F_Makeup.Parameters.Add(new SqlParameter("@studentCurr_sem", Current_Semester));

                    SqlCommand S_Register_Sucess = new SqlCommand("Select dbo.FN_StudentCheckSMEligibility(@StudentID, @courseID)", sqlConnection);
                    S_Register_Sucess.Parameters.Add(new SqlParameter("@StudentID", S_ID));
                    S_Register_Sucess.Parameters.Add(new SqlParameter("@courseID", S_CID));
                    sqlConnection.Open();
                    Boolean elligibility = ((Boolean)S_Register_Sucess.ExecuteScalar());

                    if (S_CID == "")
                        R8.Text = "Please enter Course ID.";
                    else
                    {
                        S_Register_F_Makeup.ExecuteNonQuery();
                        sqlConnection.Close();
                        if (elligibility)
                            R8.Text = "Success";
                        else
                            R8.Text = "Inelligible for second makeup.";
                     }
            }
            catch(SqlException)
            {
                R8.Text = "Please enter the correct Course ID format.";
            }
            
        }
        protected void B_View_Course_Slot_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            R9.Text = "";
            SqlCommand S_View_Course_Slot = new SqlCommand("Select * from dbo.Courses_Slots_Instructor", sqlConnection);
            sqlConnection.Open();
            SqlDataReader rdr = S_View_Course_Slot.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 CID = rdr.GetInt32(rdr.GetOrdinal("CourseID"));
                String CName = rdr.GetString(rdr.GetOrdinal("Course"));
                Int32 SID = rdr.GetInt32(rdr.GetOrdinal("slot_id"));
                String Day = rdr.GetString(rdr.GetOrdinal("day"));
                String Time = rdr.GetString(rdr.GetOrdinal("time"));
                String Location = rdr.GetString(rdr.GetOrdinal("location"));
                String Iname = rdr.GetString(rdr.GetOrdinal("Instructor"));

                R9.Text = R9.Text + "Course ID: "+ CID +"| Course: " + CName + "| Slot ID: " + SID + "| Day: " + Day + "| Time:" + Time + "| Location:" + Location+ "| Instructor name:" +Iname+ "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_View_Course_Slot.Visible = true;
        }

        protected void B_View_Course_Slot_Clear_Click(object sender, EventArgs e)
        {
            R9.Text = "";
            D_View_Course_Slot.Visible = false;
        }


        protected void B_View_Course_Slot2_Click(object sender, EventArgs e)
        {
            D_View_Course_Slot2.Visible = true;
        }

        protected void B_View_Course_Slot2_Clear_Click(object sender, EventArgs e)
        {
            R10.Text = "";
            D_View_Course_Slot2.Visible = false;
        }
        protected void B_View_Course_Slot2_Clear_Confirm(object sender, EventArgs e)
        {
            try
            {
                int CID = Int32.Parse(T_VCS_CID.Text);
                int IID = Int32.Parse(T_VCS_IID.Text);
                R10.Text = "";
                String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
                SqlConnection sqlConnection = new SqlConnection(connStr);
                SqlCommand S_View_Course_Slot = new SqlCommand("Select * from dbo.FN_StudentViewSlot(@CourseID, @InstructorID)", sqlConnection);
                S_View_Course_Slot.Parameters.Add(new SqlParameter("@CourseID", CID));
                S_View_Course_Slot.Parameters.Add(new SqlParameter("@InstructorID", IID));
                sqlConnection.Open();
                SqlDataReader rdr = S_View_Course_Slot.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    String CName = rdr.GetString(rdr.GetOrdinal("Course"));
                    Int32 SID = rdr.GetInt32(rdr.GetOrdinal("slot_id"));
                    String Day = rdr.GetString(rdr.GetOrdinal("day"));
                    String Time = rdr.GetString(rdr.GetOrdinal("time"));
                    String Location = rdr.GetString(rdr.GetOrdinal("location"));

                    R10.Text = R10.Text + "Slot ID: " + SID + "| Day: " + Day + "| Time:" + Time + "| Location:" + Location + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
                }
                sqlConnection.Close();
            }
            catch(FormatException) 
            {
                R10.Text = "Please enter a valid course or instructor ID format.";
            }
        }

        protected void B_Choose_Instuctor_Click(object sender, EventArgs e)
        {
            D_Choose_Instuctor.Visible = true;
        }

        protected void B_Choose_Instuctor_Clear_Click(object sender, EventArgs e)
        {
            R11.Text = "";
            D_Choose_Instuctor.Visible = false;
        }

        protected void B_Choose_Instuctor_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                int CID = Int32.Parse(T_C_ID.Text);
                int IID = Int32.Parse(T_I_ID.Text);
                R11.Text = "";
                String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
                SqlConnection sqlConnection = new SqlConnection(connStr);
                SqlCommand S_Choose_Instuctor = new SqlCommand("Procedures_Chooseinstructor", sqlConnection);
                S_Choose_Instuctor.CommandType = CommandType.StoredProcedure;
                S_Choose_Instuctor.Parameters.Add(new SqlParameter("@StudentID", S_ID));
                S_Choose_Instuctor.Parameters.Add(new SqlParameter("@instrucorID", IID));
                S_Choose_Instuctor.Parameters.Add(new SqlParameter("@CourseID", CID));
                S_Choose_Instuctor.Parameters.Add(new SqlParameter("@current_semester_code", Current_Semester));
                SqlCommand S_Check_Instructor= new SqlCommand("Select instructor_id from Instructor_Course where course_id =@Course_id ", sqlConnection);
                SqlCommand S_Same_Instructor = new SqlCommand("Select instructor_id from Student_Instructor_Course_take where course_id = @Course_id and student_id = @StudentID and semester_code= @current_semester_code", sqlConnection);
                SqlCommand S_Check_Course = new SqlCommand("Select student_id from Student_Instructor_Course_take where course_id = @Course_id and semester_code= @current_semester_code", sqlConnection);
                S_Check_Instructor.Parameters.AddWithValue("@Course_id", CID);
                S_Same_Instructor.Parameters.AddWithValue("@Course_id", CID);
                S_Same_Instructor.Parameters.AddWithValue("@StudentID", S_ID);
                S_Same_Instructor.Parameters.AddWithValue("@current_semester_code", Current_Semester);
                S_Check_Course.Parameters.AddWithValue("@Course_id", CID);
                S_Check_Course.Parameters.AddWithValue("@current_semester_code", Current_Semester);
                ArrayList instructor = new ArrayList();
                ArrayList instructor2 = new ArrayList();
                ArrayList student = new ArrayList();
                sqlConnection.Open();
                SqlDataReader rdr = S_Check_Instructor.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    instructor.Add(rdr.GetInt32(rdr.GetOrdinal("instructor_id")));

                }
                sqlConnection.Close();
                sqlConnection.Open();
                rdr = S_Same_Instructor.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    instructor2.Add(rdr.GetInt32(rdr.GetOrdinal("instructor_id")));

                }
                sqlConnection.Close();
                sqlConnection.Open();
                rdr = S_Check_Course.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    student.Add(rdr.GetInt32(rdr.GetOrdinal("student_id")));

                }
                if (!instructor.Contains(IID))
                    R11.Text = "This instructor does not give this course.";
                else
                {
                    if (instructor2.Contains(IID))
                        R11.Text = "You alrready take this course with this instructor.";
                    else
                    {
                        if (!student.Contains(S_ID))
                            R11.Text = "You do not take this course.";
                        else
                            R11.Text = "Instructor changed successfully.";
                    }
                }
                sqlConnection.Close();

            }
            catch (FormatException)
            {
                R11.Text = "Please enter a valid format of course or instructor ID.";
            }
        }
        protected void B_View_Course_Prerequisites_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            R12.Text = "";
            SqlCommand S_View_Course_Pre = new SqlCommand("Select * from dbo.view_Course_Prerequisites", sqlConnection);
            sqlConnection.Open();
            SqlDataReader rdr = S_View_Course_Pre.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 C_ID = rdr.GetInt32(rdr.GetOrdinal("course_id"));
                String Cname = rdr.GetString(rdr.GetOrdinal("name"));
                String major = rdr.GetString(rdr.GetOrdinal("major"));
                Boolean is_offered = rdr.GetBoolean(rdr.GetOrdinal("is_offered"));
                Int32 credit_hours = rdr.GetInt32(rdr.GetOrdinal("credit_hours"));
                Int32 semester = rdr.GetInt32(rdr.GetOrdinal("semester"));
                Int32 Prerequisite_course_id = rdr.GetInt32(rdr.GetOrdinal("preRequsite_course_id"));
                String Prerequisite_course_name = rdr.GetString(rdr.GetOrdinal("preRequsite_course_name"));
                R12.Text = R12.Text + "Course ID: " +C_ID +"| Course name:" + Cname+ "| Major:"+major + "| Offered:" + is_offered + "| Credit Hours:" + credit_hours + "| Semester:" + semester + "| Prerequiste Course ID:" + Prerequisite_course_id + "| Prerquiste Course Name:" + Prerequisite_course_name;
            }
            sqlConnection.Close();
            D_View_Course_Prerequisites.Visible = true;

        }

        protected void B_View_Course_Prerequisites_Clear_Click(object sender, EventArgs e)
        {
            D_View_Course_Prerequisites.Visible = false;
        }
        protected void S_OC_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connStr);

            SqlCommand S_View_All_OC = new SqlCommand("Procedures_ViewOptionalCourse", sqlConnection);
            S_View_All_OC.CommandType = CommandType.StoredProcedure;
            S_View_All_OC.Parameters.Add(new SqlParameter("@StudentID", S_ID));
            S_View_All_OC.Parameters.Add(new SqlParameter("@current_semester_code", Current_Semester));
            R3.Text = "&nbsp;&nbsp;&nbsp;&nbsp Optional Courses: <br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            sqlConnection.Open();
            SqlDataReader rdr = S_View_All_OC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String CName = rdr.GetString(rdr.GetOrdinal("name"));
                Int32 CID = rdr.GetInt32(rdr.GetOrdinal("course_id"));

                R3.Text = R3.Text + "" + CName +", ID:" + CID + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_Course.Visible = true;
        }

        protected void S_AC_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connStr);

            SqlCommand S_View_All_AC = new SqlCommand("Select * from dbo.FN_SemsterAvailableCourses(@semstercode)", sqlConnection);
            S_View_All_AC.Parameters.Add(new SqlParameter("@semstercode", Current_Semester));
            R3.Text = "&nbsp;&nbsp;&nbsp;&nbsp Available Courses: <br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            sqlConnection.Open();
            SqlDataReader rdr = S_View_All_AC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String CName = rdr.GetString(rdr.GetOrdinal("name"));
                Int32 CID = rdr.GetInt32(rdr.GetOrdinal("course_id"));

                R3.Text = R3.Text + "" + CName + ", ID:" + CID + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_Course.Visible = true;
        }

        protected void S_RC_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            R3.Text = "&nbsp;&nbsp;&nbsp;&nbsp Required Courses: <br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            SqlCommand S_View_All_RC = new SqlCommand("Procedures_ViewRequiredCourses", sqlConnection);
            S_View_All_RC.CommandType = CommandType.StoredProcedure;
            S_View_All_RC.Parameters.Add(new SqlParameter("@StudentID", S_ID));
            S_View_All_RC.Parameters.Add(new SqlParameter("@current_semester_code", Current_Semester));

            sqlConnection.Open();
            SqlDataReader rdr = S_View_All_RC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String CName = rdr.GetString(rdr.GetOrdinal("name"));
                Int32 CID = rdr.GetInt32(rdr.GetOrdinal("course_id"));

                R3.Text = R3.Text + "" + CName + ", ID:" + CID + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_Course.Visible = true;
        }

        protected void S_MC_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connStr);

            SqlCommand S_View_All_MC = new SqlCommand("Procedures_ViewMS", sqlConnection);
            S_View_All_MC.Parameters.Add(new SqlParameter("@StudentID", S_ID));
            S_View_All_MC.CommandType = CommandType.StoredProcedure;
            R3.Text = "&nbsp;&nbsp;&nbsp;&nbsp Missing Courses: <br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            sqlConnection.Open();
            SqlDataReader rdr = S_View_All_MC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String CName = rdr.GetString(rdr.GetOrdinal("name"));
                Int32 CID = rdr.GetInt32(rdr.GetOrdinal("course_id"));

                R3.Text = R3.Text + "" + CName + ", ID:" + CID + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_Course.Visible = true;
        }
        protected void B_C_Clear_Click(object sender, EventArgs e)
        {
            R3.Text = "";
            D_Course.Visible = false;
        }
        protected void B_Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student_Homepage.aspx");
        }
    }
}