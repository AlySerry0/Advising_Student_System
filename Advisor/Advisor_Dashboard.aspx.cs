using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace WebApplication1.Advisor
{
    public partial class Advisor_Dashboard : System.Web.UI.Page
    {
        int Advisor_ID;
        String Current_Semester_Code = "S24";
        private static readonly String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
        private static readonly SqlConnection sqlConnection = new SqlConnection(connStr);

        protected void Page_Load(object sender, EventArgs e)
        {
            Advisor_ID = Int16.Parse(Request.QueryString["msg"].ToString());
            SqlCommand getAdvisorName = new SqlCommand("Select advisor_name From Advisor Where advisor_id = @AdvisorID", sqlConnection);
            getAdvisorName.Parameters.Add(new SqlParameter("@AdvisorID", Advisor_ID));

            sqlConnection.Open();
            SqlDataReader rdr = getAdvisorName.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();
            String A_name = rdr.GetString(rdr.GetOrdinal("advisor_name"));
            sqlConnection.Close();

            L_Welcome.Text = "Welcome " + A_name;


            //SqlCommand S_GET_CS = new SqlCommand("select semester_code from semester where start_date <(CURRENT_TIMESTAMP) and end_date >(CURRENT_TIMESTAMP)", sqlConnection);

            //sqlConnection.Open();
            //rdr = S_GET_CS.ExecuteReader(CommandBehavior.CloseConnection);
            //while (rdr.Read())
            //{
            //    String S_CS = rdr.GetString(rdr.GetOrdinal("semester_code"));
            //    Current_Semester_Code = S_CS;
            //}
            //sqlConnection.Close();
        }
        protected void B_A_Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Homepage.aspx");
        }

        protected void B_A_D_View_All_Students_Click(object sender, EventArgs e)
        {
            L_Students.Text = "Students: <br />&nbsp;&nbsp;&nbsp;&nbsp;";

            SqlCommand A_D_View_All_Students = new SqlCommand("Select S.f_name + '_' + S.l_name as Student_name, S.student_id From Student S Where S.advisor_id = @AdvisorID", sqlConnection);
            A_D_View_All_Students.Parameters.Add(new SqlParameter("@AdvisorID", Advisor_ID));

            sqlConnection.Open();
            SqlDataReader rdr = A_D_View_All_Students.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String sFName = rdr.GetString(rdr.GetOrdinal("Student_name"));
                Int32 sID = rdr.GetInt32(rdr.GetOrdinal("student_id"));
                L_Students.Text = L_Students.Text + "Name: " + sFName + " | ID: " + sID + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_All_Students.Visible = true;

        }

        protected void B_Clear_Students_Click(object sender, EventArgs e)
        {
            L_Students.Text = "";
            D_All_Students.Visible = false;
        }

        protected void B_A_D_Insert_Graduation_Plan_Click(object sender, EventArgs e)
        {
            D_Gradplan_Insert.Visible = true;

        }
        protected void B_Gradplan_Insert_Cancel_Click(object sender, EventArgs e)
        {
            D_Gradplan_Insert.Visible = false;
            L_Gradplan_Insert_Out.Text = string.Empty;
        }

        protected void B_Gradplan_Insert_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                String Semester_Code = TB_Semester_Code.Text;
                SqlDateTime Expected_Graduation_Date = Convert.ToDateTime(TB_Expected_Graduation_Date.Text);
                int Semester_Credit_Hours = Int16.Parse(TB_Semester_Credit_Hours.Text);
                int Student_ID = Int16.Parse(TB_Student_ID.Text);

                SqlCommand gradplan_Insert = new SqlCommand("Procedures_AdvisorCreateGP", sqlConnection);
                gradplan_Insert.CommandType = CommandType.StoredProcedure;
                gradplan_Insert.Parameters.Add(new SqlParameter("@Semester_code", Semester_Code));
                gradplan_Insert.Parameters.Add(new SqlParameter("@expected_graduation_date", Expected_Graduation_Date));
                gradplan_Insert.Parameters.Add(new SqlParameter("@sem_credit_hours", Semester_Credit_Hours));
                gradplan_Insert.Parameters.Add(new SqlParameter("@advisor_id", Advisor_ID));
                gradplan_Insert.Parameters.Add(new SqlParameter("@student_id", Student_ID));

                sqlConnection.Open();
                gradplan_Insert.ExecuteNonQuery();
                sqlConnection.Close();
                L_Gradplan_Insert_Out.Text = "";
                SqlCommand getAcquiredHours = new SqlCommand("Select acquired_hours from Student where student_id = @student_id", sqlConnection);
                getAcquiredHours.Parameters.Add(new SqlParameter("@student_id", Student_ID));
                sqlConnection.Open();
                SqlDataReader rdr = getAcquiredHours.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();
                Int32 Acquired_Hours = rdr.GetInt32(rdr.GetOrdinal("acquired_hours"));
                if (Acquired_Hours >= 157)
                {
                    L_Gradplan_Insert_Out.Text = "Gradplan Created Successfully.";
                }
                else
                {
                    L_Gradplan_Insert_Out.Text = "Insufficient Acquired Hours. ";
                }
            }
            catch (SqlNullValueException)
            {
                L_Gradplan_Insert_Out.Text = "Student Acquired Hours Unavailable.";
            }

            catch (FormatException)
            {
                L_Gradplan_Insert_Out.Text = "Incorrect Format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void B_A_D_Insert_Course_Click(object sender, EventArgs e)
        {
            D_Insert_Course.Visible = true;

        }

        protected void B_Insert_Course_Cancel_Click(object sender, EventArgs e)
        {
            D_Insert_Course.Visible = false;
            L_Insert_Course_Out.Text = string.Empty;
        }

        protected void B_Insert_Course_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                int Student_ID = Int16.Parse(TB_Student_ID2.Text);
                String Semester_Code = TB_Semester_Code2.Text;
                String Course_Name = TB_Course_Name.Text;

                SqlCommand insert_Course = new SqlCommand("Procedures_AdvisorAddCourseGP", sqlConnection);
                insert_Course.CommandType = CommandType.StoredProcedure;
                insert_Course.Parameters.Add(new SqlParameter("@student_id", Student_ID));
                insert_Course.Parameters.Add(new SqlParameter("@Semester_code", Semester_Code));
                insert_Course.Parameters.Add(new SqlParameter("@course_name", Course_Name));

                sqlConnection.Open();
                insert_Course.ExecuteNonQuery();
                sqlConnection.Close();
                L_Insert_Course_Out.Text = "Course Added Successfully.";
            }
            catch (SqlException)
            {
                L_Insert_Course_Out.Text = "Course Already Exists.";
            }
            catch (FormatException)
            {
                L_Insert_Course_Out.Text = "Incorrect Format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void B_A_D_Update_Expected_Graduation_Date_Click(object sender, EventArgs e)
        {
            D_Update_Expected_Graduation_Date.Visible = true;
        }

        protected void B_Update_Expected_Graduation_Date_Cancel_Click(object sender, EventArgs e)
        {
            D_Update_Expected_Graduation_Date.Visible = false;
            L_Update_Expected_Graduation_Date_Out.Text = string.Empty;
        }

        protected void B_Update_Expected_Graduation_Date_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDateTime Updated_Graduation_Date = Convert.ToDateTime(TB_Updated_Graduation_Date.Text);
                int Student_ID = Int16.Parse(TB_Student_ID3.Text);

                SqlCommand update_Date = new SqlCommand("Procedures_AdvisorUpdateGP", sqlConnection);
                update_Date.CommandType = CommandType.StoredProcedure;
                update_Date.Parameters.Add(new SqlParameter("@expected_grad_date", Updated_Graduation_Date));
                update_Date.Parameters.Add(new SqlParameter("@studentID", Student_ID));

                sqlConnection.Open();
                update_Date.ExecuteNonQuery();
                sqlConnection.Close();
                L_Update_Expected_Graduation_Date_Out.Text = "Graduation Date Updated Successfully.";
            }
            catch (FormatException)
            {
                L_Insert_Course_Out.Text = "Incorrect Format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void B_A_D_Delete_Course_Graduation_Plan_Click(object sender, EventArgs e)
        {
            D_Delete_Course_Graduation_Plan.Visible = true;
        }

        protected void B_Delete_Course_Graduation_Plan_Cancel_Click(object sender, EventArgs e)
        {
            D_Delete_Course_Graduation_Plan.Visible = false;
            L_Delete_Course_Graduation_Plan_Out.Text = string.Empty;
        }

        protected void B_Delete_Course_Graduation_Plan_Confirm_Click(object sender, EventArgs e)
        {
            try
            {

                int Student_ID = Int16.Parse(TB_Student_ID4.Text);
                String Semester_Code = TB_Semester_Code3.Text;
                int Course_ID = Int16.Parse(TB_Course_ID.Text);

                SqlCommand delete_course = new SqlCommand("Procedures_AdvisorDeleteFromGP", sqlConnection);
                delete_course.CommandType = CommandType.StoredProcedure;
                delete_course.Parameters.Add(new SqlParameter("@studentID", Student_ID));
                delete_course.Parameters.Add(new SqlParameter("@sem_code", Semester_Code));
                delete_course.Parameters.Add(new SqlParameter("@courseID", Course_ID));

                sqlConnection.Open();
                delete_course.ExecuteNonQuery();
                sqlConnection.Close();
                L_Delete_Course_Graduation_Plan_Out.Text = "Course Removed Successfully.";

            }
            catch (FormatException)
            {
                L_Delete_Course_Graduation_Plan_Out.Text = "Incorrect Format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        protected void B_A_D_View_All_Students_Major_Courses_Click(object sender, EventArgs e)
        {
            D_View_All_Students_Major_Courses.Visible = true;
        }
        protected void B_View_All_Students_Major_Courses_Cancel_Click(object sender, EventArgs e)
        {
            D_View_All_Students_Major_Courses.Visible = false;
            L_View_All_Students_Major_Courses.Text = "";
            B_View_All_Students_Major_Courses_Clear.Visible = false;
        }
        protected void B_View_All_Students_Major_Courses_Confirm_Click(object sender, EventArgs e)
        {
            L_View_All_Students_Major_Courses.Text = "Students: <br />&nbsp;&nbsp;&nbsp;&nbsp;";

            String major = TB_Major.Text;

            SqlCommand viewAllStudentsDetails = new SqlCommand("Procedures_AdvisorViewAssignedStudents", sqlConnection);
            viewAllStudentsDetails.CommandType = CommandType.StoredProcedure;
            viewAllStudentsDetails.Parameters.Add(new SqlParameter("@AdvisorID", Advisor_ID));
            viewAllStudentsDetails.Parameters.Add(new SqlParameter("@major", major));

            sqlConnection.Open();
            SqlDataReader rdr = viewAllStudentsDetails.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 sID = rdr.GetInt32(rdr.GetOrdinal("student_id"));
                String sFName = rdr.GetString(rdr.GetOrdinal("Student_name"));
                String sMajor = rdr.GetString(rdr.GetOrdinal("major"));
                String cName = "";
                try
                {
                    cName = rdr.GetString(rdr.GetOrdinal("Course_name"));
                }
                catch (SqlNullValueException) { }

                L_View_All_Students_Major_Courses.Text = L_View_All_Students_Major_Courses.Text + sFName + ", ID: " + sID + ", Major: " + sMajor + ", Course Name: " + cName + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_View_All_Students_Major_Courses_Students.Visible = true;
            B_View_All_Students_Major_Courses_Clear.Visible = true;
        }
        protected void B_View_All_Students_Major_Courses_Clear_Click(object sender, EventArgs e)
        {
            L_View_All_Students_Major_Courses.Text = String.Empty;
            D_View_All_Students_Major_Courses_Students.Visible = false;
        }

        protected void B_A_D_View_All_Requests_Click(object sender, EventArgs e)
        {
            D_View_All_Requests.Visible = true;
        }
        protected void B_View_All_Requests_Cancel_Click(object sender, EventArgs e)
        {
            D_View_All_Requests.Visible = false;
            B_View_Requests_Clear.Visible = false;
            D_Update_Request.Visible = false;
            L_Update_Out.Text = string.Empty;

        }
        protected void B_View_All_Requests_Click(object sender, EventArgs e)
        {
            B_View_Requests_Clear.Visible = true;
            T_Requests.Visible = true;
            SqlCommand viewAllRequests = new SqlCommand("Select * From Request Where advisor_id = @AdvisorID", sqlConnection);
            viewAllRequests.Parameters.Add(new SqlParameter("@AdvisorID", Advisor_ID));

            sqlConnection.Open();
            SqlDataReader rdr = viewAllRequests.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 rID = rdr.GetInt32(rdr.GetOrdinal("request_id"));
                String rType = rdr.GetString(rdr.GetOrdinal("type"));
                String rComment = rdr.GetString(rdr.GetOrdinal("comment"));
                String rStatus = rdr.GetString(rdr.GetOrdinal("status"));
                Int32 rCreditHours = 0;
                Int32 rCourseID = 0;
                try
                {
                    rCreditHours = rdr.GetInt32(rdr.GetOrdinal("credit_hours"));
                }
                catch { }
                try
                {
                    rCourseID = rdr.GetInt32(rdr.GetOrdinal("course_id"));
                }
                catch { }
                Int32 rStudentID = rdr.GetInt32(rdr.GetOrdinal("student_id"));
                TableRow tRow = new TableRow();
                TableCell c_rID = new TableCell();
                c_rID.Text = "Request ID: " + rID.ToString();
                TableCell c_rType = new TableCell();
                c_rType.Text = "| Type: " + rType.ToString();
                TableCell c_rComment = new TableCell();
                c_rComment.Text = "| Comment: " + rComment.ToString();
                TableCell c_rStatus = new TableCell();
                c_rStatus.Text = "| Stauts: " + rStatus.ToString();
                TableCell c_rCreditHours = new TableCell();
                c_rCreditHours.Text = "| Credit Hours: " + rCreditHours.ToString();
                TableCell c_rCourseID = new TableCell();
                c_rCourseID.Text = "| Course ID: " + rCourseID.ToString();
                TableCell c_rStudentID = new TableCell();
                c_rStudentID.Text = "| Student ID: " + rStudentID.ToString();

                tRow.Cells.Add(c_rID);
                tRow.Cells.Add(c_rType);
                tRow.Cells.Add(c_rComment);
                tRow.Cells.Add(c_rStatus);
                tRow.Cells.Add(c_rCreditHours);
                tRow.Cells.Add(c_rCourseID);

                T_Requests.Rows.Add(tRow);
            }
            sqlConnection.Close();
            D_Update_Request.Visible = true;
        }
        protected void B_View_Pending_Requests_Click(object sender, EventArgs e)
        {
            B_View_Requests_Clear.Visible = true;
            T_Requests.Visible = true;
            SqlCommand viewPendingRequests = new SqlCommand("Procedures_AdvisorViewPendingRequests", sqlConnection);
            viewPendingRequests.CommandType = CommandType.StoredProcedure;
            viewPendingRequests.Parameters.Add(new SqlParameter("@Advisor_ID", Advisor_ID));

            sqlConnection.Open();
            SqlDataReader rdr = viewPendingRequests.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 rID = rdr.GetInt32(rdr.GetOrdinal("request_id"));
                String rType = rdr.GetString(rdr.GetOrdinal("type"));
                String rComment = rdr.GetString(rdr.GetOrdinal("comment"));
                String rStatus = rdr.GetString(rdr.GetOrdinal("status"));
                Int32 rCreditHours = 0;
                Int32 rCourseID = 0;
                try
                {
                    rCreditHours = rdr.GetInt32(rdr.GetOrdinal("credit_hours"));
                }
                catch { }
                try
                {
                    rCourseID = rdr.GetInt32(rdr.GetOrdinal("course_id"));
                }
                catch { }
                Int32 rStudentID = rdr.GetInt32(rdr.GetOrdinal("student_id"));
                TableRow tRow = new TableRow();
                TableCell c_rID = new TableCell();
                c_rID.Text = "Request ID: " + rID.ToString();
                TableCell c_rType = new TableCell();
                c_rType.Text = "| Type: " + rType.ToString();
                TableCell c_rComment = new TableCell();
                c_rComment.Text = "| Comment: " + rComment.ToString();
                TableCell c_rStatus = new TableCell();
                c_rStatus.Text = "| Stauts: " + rStatus.ToString();
                TableCell c_rCreditHours = new TableCell();
                c_rCreditHours.Text = "| Credit Hours: " + rCreditHours.ToString();
                TableCell c_rCourseID = new TableCell();
                c_rCourseID.Text = "| Course ID: " + rCourseID.ToString();
                TableCell c_rStudentID = new TableCell();
                c_rStudentID.Text = "| Student ID: " + rStudentID.ToString();
                TableCell c_bUpdate = new TableCell();

                tRow.Cells.Add(c_rID);
                tRow.Cells.Add(c_rType);
                tRow.Cells.Add(c_rComment);
                tRow.Cells.Add(c_rStatus);
                tRow.Cells.Add(c_rCreditHours);
                tRow.Cells.Add(c_rCourseID);

                T_Requests.Rows.Add(tRow);
            }
            sqlConnection.Close();
            D_Update_Request.Visible = true;

        }

        protected void B_View_Requests_Clear_Click(object sender, EventArgs e)
        {
            T_Requests.Controls.Clear();
            B_View_Requests_Clear.Visible = false;

        }

        protected void B_Update_Click(object sender, EventArgs e)
        {
            SqlCommand viewPendingRequests = new SqlCommand("Procedures_AdvisorViewPendingRequests", sqlConnection);
            ArrayList pendingRequestIDs = new ArrayList();
            viewPendingRequests.CommandType = CommandType.StoredProcedure;
            viewPendingRequests.Parameters.Add(new SqlParameter("@Advisor_ID", Advisor_ID));

            sqlConnection.Open();
            SqlDataReader rdr = viewPendingRequests.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                pendingRequestIDs.Add(rdr.GetInt32(rdr.GetOrdinal("request_id")));
            }
            sqlConnection.Close();

            ArrayList allRequestIDs = new ArrayList();
            SqlCommand viewAllRequests = new SqlCommand("Select * From Request Where advisor_id = @AdvisorID", sqlConnection);
            viewAllRequests.Parameters.Add(new SqlParameter("@AdvisorID", Advisor_ID));

            sqlConnection.Open();
            rdr = viewAllRequests.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                allRequestIDs.Add(rdr.GetInt32(rdr.GetOrdinal("request_id")));
            }
            sqlConnection.Close();

            try
            {
                int rID = Int16.Parse(TB_Request_ID.Text);

                if (pendingRequestIDs.Contains(rID))
                {
                    SqlCommand getRequestType = new SqlCommand("Select type from request where request_id = @RequestID", sqlConnection);
                    getRequestType.Parameters.Add(new SqlParameter("@RequestID", rID));
                    sqlConnection.Open();
                    String rType = (String)getRequestType.ExecuteScalar();
                    sqlConnection.Close();
                    Boolean b = (rType == "course");
                    if (b)
                    {
                        SqlCommand approve_rejectCourseRequest = new SqlCommand("Procedures_AdvisorApproveRejectCourseRequest", sqlConnection);
                        approve_rejectCourseRequest.CommandType = CommandType.StoredProcedure;
                        approve_rejectCourseRequest.Parameters.Add(new SqlParameter("@requestID", rID));
                        approve_rejectCourseRequest.Parameters.Add(new SqlParameter("@current_semester_code", Current_Semester_Code));

                        sqlConnection.Open();
                        approve_rejectCourseRequest.ExecuteNonQuery();
                        sqlConnection.Close();
                        L_Update_Out.Text = "Request Updated Successfully.";
                    }
                    else
                    {
                        SqlCommand approve_rejectCHRequest = new SqlCommand("Procedures_AdvisorApproveRejectCHRequest", sqlConnection);
                        approve_rejectCHRequest.CommandType = CommandType.StoredProcedure;
                        approve_rejectCHRequest.Parameters.Add(new SqlParameter("@requestID", rID));
                        approve_rejectCHRequest.Parameters.Add(new SqlParameter("@current_sem_code", Current_Semester_Code));

                        sqlConnection.Open();
                        approve_rejectCHRequest.ExecuteNonQuery();
                        sqlConnection.Close();
                        L_Update_Out.Text = "Request Updated Successfully.";
                    }
                }
                else if (allRequestIDs.Contains(rID))
                {
                    L_Update_Out.Text = "Request already approved/rejected.";
                }
                else
                {
                    L_Update_Out.Text = "Request ID does not exist.";
                }
            }
            catch (FormatException)
            {
                L_Update_Out.Text = "Incorrect Format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}