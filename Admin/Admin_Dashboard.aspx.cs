using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class Admin_Dashboard : System.Web.UI.Page
    {
        private static readonly String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
        private static readonly SqlConnection sqlConnection = new SqlConnection(connStr);
        String Current_Semester;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand S_GET_CS = new SqlCommand("select semester_code from semester where start_date <(CURRENT_TIMESTAMP) and end_date >(CURRENT_TIMESTAMP)", sqlConnection);
            sqlConnection.Open();
            SqlDataReader rdr = S_GET_CS.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String S_CS = rdr.GetString(rdr.GetOrdinal("semester_code"));
                Current_Semester = S_CS;
            }
            sqlConnection.Close();
        }
        protected void B_Admin_Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Homepage.aspx");
        }
        protected void B_Admin_View_All_Advisors_Click(object sender, EventArgs e)
        {
            L_Advisors.Text = "Advisors: <br />&nbsp;&nbsp;&nbsp;&nbsp;";

            SqlCommand viewAllAdvisors = new SqlCommand("Procedures_AdminListAdvisors", sqlConnection);
            viewAllAdvisors.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            SqlDataReader rdr = viewAllAdvisors.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 aID = rdr.GetInt32(rdr.GetOrdinal("advisor_id"));
                String aFName = rdr.GetString(rdr.GetOrdinal("advisor_name"));
                String aEmail = rdr.GetString(rdr.GetOrdinal("email"));
                String aOffice = rdr.GetString(rdr.GetOrdinal("office"));
                String aPassword = rdr.GetString(rdr.GetOrdinal("password"));

                L_Advisors.Text = L_Advisors.Text + aFName + " | ID: " + aID + " | Email: " + aEmail + " | Office: " + aOffice + " | Password: " + aPassword + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_Advisors.Visible = true;
            B_View_All_Advisors_Clear.Visible = true;
        }

        protected void B_View_All_Advisors_Clear_Click(object sender, EventArgs e)
        {
            L_Advisors.Text = "";
            D_Advisors.Visible = false;
        }

        protected void B_Admin_View_All_Students_Advisors_Click(object sender, EventArgs e)
        {
            L_Students_Advisors.Text = "Students & Advisors: <br />&nbsp;&nbsp;&nbsp;&nbsp;";

            SqlCommand viewAllAdvisors = new SqlCommand("AdminListStudentsWithAdvisors", sqlConnection);
            viewAllAdvisors.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            SqlDataReader rdr = viewAllAdvisors.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 sID = rdr.GetInt32(rdr.GetOrdinal("student_id"));
                String sFName = rdr.GetString(rdr.GetOrdinal("f_name"));
                String sLName = rdr.GetString(rdr.GetOrdinal("l_name"));
                Int32 aID = rdr.GetInt32(rdr.GetOrdinal("advisor_id"));
                String aName = rdr.GetString(rdr.GetOrdinal("advisor_name"));

                L_Students_Advisors.Text = L_Students_Advisors.Text + sFName + " " + sLName + " | ID: " + sID + " | Advisor Name: " + aName + " | Advisor ID: " + aID  + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_Students_Advisors.Visible = true;
            B_View_All_Advisors_Clear.Visible = true;
        }

        protected void B_View_All_Students_Advisors_Clear_Click(object sender, EventArgs e)
        {
            L_Students_Advisors.Text = "";
            D_Students_Advisors.Visible = false;
        }

        protected void B_Admin_View_All_Requests_Click(object sender, EventArgs e)
        {
            D_Requests.Visible = true;
            SqlCommand viewAllRequests = new SqlCommand("Select * From Request", sqlConnection);

            sqlConnection.Open();
            SqlDataReader rdr = viewAllRequests.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 rID = rdr.GetInt32(rdr.GetOrdinal("request_id"));
                String rType = rdr.GetString(rdr.GetOrdinal("type"));
                String rComment = "";
                try
                {
                    rComment = rdr.GetString(rdr.GetOrdinal("comment"));
                }
                catch { }
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

                T_All_Requests.Rows.Add(tRow);
            }
            sqlConnection.Close();
        }

        protected void B_View_All_Requests_Clear_Click(object sender, EventArgs e)
        {
            T_All_Requests.Controls.Clear();
            D_Requests.Visible = false;
        }
        protected void B_Admin_Add_New_Semester_Click(object sender, EventArgs e)
        {
            D_Add_New_Semester.Visible = true;
        }

        protected void B_Add_Semester_Cancel_Click(object sender, EventArgs e)
        {
            D_Add_New_Semester.Visible = false;
            L_Add_Semester_Out.Text = string.Empty;
        }

        protected void B_Add_Semester_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDateTime startDate = Convert.ToDateTime(TB_Start_Date.Text);
                SqlDateTime endDate = Convert.ToDateTime(TB_End_Date.Text);
                String semesterCode = TB_Semester_Code.Text;
                if (semesterCode == "")
                    throw new FormatException();

                SqlCommand addSemester = new SqlCommand("AdminAddingSemester", sqlConnection);
                addSemester.CommandType = CommandType.StoredProcedure;
                addSemester.Parameters.Add(new SqlParameter("@start_date", startDate));
                addSemester.Parameters.Add(new SqlParameter("@end_date", endDate));
                addSemester.Parameters.Add(new SqlParameter("@semester_code", semesterCode));

                sqlConnection.Open();
                addSemester.ExecuteNonQuery();
                sqlConnection.Close();
                L_Add_Semester_Out.Text = "Semester Added Successfully.";
            }
            catch (SqlException)
            {
                L_Add_Semester_Out.Text = "Semester Already Exists.";
            }
            catch (FormatException)
            {
                L_Add_Semester_Out.Text = "Incorrect Format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void B_Admin_Add_New_Course_Click(object sender, EventArgs e)
        {
            D_Add_New_Course.Visible = true;
        }

        protected void B_Add_Course_Cancel_Click(object sender, EventArgs e)
        {
            D_Add_New_Course.Visible = false;
            L_Add_New_Course_Out.Text = string.Empty;
        }

        protected void B_Add_Course_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                String major = TB_Major.Text;
                int semester = Int16.Parse(TB_Semester.Text);
                int creditHours = Int16.Parse(TB_Credit_Hours.Text);
                String name = TB_Name.Text;
                SqlBoolean isOffered = CB_isOffered.Checked;
                if (name == "" || major == "")
                    throw new FormatException();

                SqlCommand addCourse = new SqlCommand("Procedures_AdminAddingCourse", sqlConnection);
                addCourse.CommandType = CommandType.StoredProcedure;
                addCourse.Parameters.Add(new SqlParameter("@major", major));
                addCourse.Parameters.Add(new SqlParameter("@semester", semester));
                addCourse.Parameters.Add(new SqlParameter("@credit_hours", creditHours));
                addCourse.Parameters.Add(new SqlParameter("@name", name));
                addCourse.Parameters.Add(new SqlParameter("@is_offered", isOffered));

                sqlConnection.Open();
                addCourse.ExecuteNonQuery();
                sqlConnection.Close();
                L_Add_New_Course_Out.Text = "Course Added Successfully.";
            }
            catch (SqlException)
            {
                L_Add_New_Course_Out.Text = "Course Already Exists.";
            }
            catch (FormatException)
            {
                L_Add_New_Course_Out.Text = "Incorrect Format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void B_Admin_Update_Slot_Click(object sender, EventArgs e)
        {
            D_Update_Slot.Visible = true;

        }

        protected void B_Update_Slot_Cancel_Click(object sender, EventArgs e)
        {
            D_Update_Slot.Visible = false;
            L_Update_Slot_Out.Text = string.Empty;
        }

        protected void B_Update_Slot_Confirm_Click(object sender, EventArgs e)
        {
            ArrayList slotIDs = new ArrayList();
            SqlCommand viewSlots = new SqlCommand("Select * From Slot", sqlConnection);

            sqlConnection.Open();
            SqlDataReader rdr = viewSlots.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                slotIDs.Add(rdr.GetInt32(rdr.GetOrdinal("slot_id")));
            }
            sqlConnection.Close();

            try
            {
                int courseID = Int16.Parse(TB_CourseID.Text);
                int instructorID = Int16.Parse(TB_InstructorID.Text);
                int slotID = Int16.Parse(TB_SlotID.Text);
                if (slotIDs.Contains(slotID)){

                    SqlCommand updateSlot = new SqlCommand("Procedures_AdminLinkInstructor", sqlConnection);
                    updateSlot.CommandType = CommandType.StoredProcedure;
                    updateSlot.Parameters.Add(new SqlParameter("@cours_id", courseID));
                    updateSlot.Parameters.Add(new SqlParameter("@instructor_id", instructorID));
                    updateSlot.Parameters.Add(new SqlParameter("@slot_id", slotID));

                    sqlConnection.Open();
                    updateSlot.ExecuteNonQuery();
                    sqlConnection.Close();
                    L_Update_Slot_Out.Text = "Slot Updated Successfully.";
                }
                else
                {
                    L_Update_Slot_Out.Text = "This Slot Does Not Exist.";
                }
            }
            catch (SqlException)
            {
                L_Update_Slot_Out.Text = "Incorrect Course/Instructor ID.";
            }

            catch (FormatException)
            {
                L_Update_Slot_Out.Text = "Incorrect Format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void B_Admin_Link_Student_Advisor_Click(object sender, EventArgs e)
        {
            D_Link_Student_Advisor.Visible = true;
        }

        protected void B_Link_Student_Advisor_Cancel_Click(object sender, EventArgs e)
        {
            L_Link_Student_Advisor_Out.Text = string.Empty;
            D_Link_Student_Advisor.Visible = false;
        }

        protected void B_Link_Student_Advisor_Confirm_Click(object sender, EventArgs e)
        {
            ArrayList studentIDs = new ArrayList();
            SqlCommand viewStudents = new SqlCommand("Select * From Student", sqlConnection);

            sqlConnection.Open();
            SqlDataReader rdr = viewStudents.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                studentIDs.Add(rdr.GetInt32(rdr.GetOrdinal("student_id")));
            }
            sqlConnection.Close();
            try
            {
                int studentID = Int16.Parse(TB_StudentID.Text);
                int advisorID = Int16.Parse(TB_AdvisorID.Text);

                if(studentIDs.Contains(studentID))
                {
                    SqlCommand linkStudentAdvisor = new SqlCommand("Procedures_AdminLinkStudentToAdvisor", sqlConnection);
                    linkStudentAdvisor.CommandType = CommandType.StoredProcedure;
                    linkStudentAdvisor.Parameters.Add(new SqlParameter("@studentID", studentID));
                    linkStudentAdvisor.Parameters.Add(new SqlParameter("@advisorID", advisorID));

                    sqlConnection.Open();
                    linkStudentAdvisor.ExecuteNonQuery();
                    sqlConnection.Close();
                    L_Link_Student_Advisor_Out.Text = "Student Linked.";
                }
                else
                {
                    L_Link_Student_Advisor_Out.Text = "This Student Does Not Exist.";
                }
                
            }
            catch (SqlException)
            {
                L_Link_Student_Advisor_Out.Text = "This Advisor Does Not Exist.";
            }

            catch (FormatException)
            {
                L_Link_Student_Advisor_Out.Text = "Incorrect Format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void B_Admin_Link_Student_Course_Instructor_Click(object sender, EventArgs e)
        {
            D_Link_Student_Course_Instructor.Visible = true;
        }

        protected void B_Link_Student_Course_Instructor_Cancel_Click(object sender, EventArgs e)
        {
            L_Link_Student_Course_Instructor_Out.Text = string.Empty;
            D_Link_Student_Course_Instructor.Visible= false;
        }

        protected void B_Link_Student_Course_Instructor_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                int courseID = Int16.Parse(TB_CourseID2.Text);
                int instructorID = Int16.Parse(TB_InstructorID2.Text);
                int studentID = Int16.Parse(TB_StudentID2.Text);
                String semesterCode = TB_Semester_Code2.Text;
                if (semesterCode == "")
                    throw new FormatException();

                ArrayList courseIDs = new ArrayList();
                SqlCommand viewCourses = new SqlCommand("Select * From Course", sqlConnection);

                sqlConnection.Open();
                SqlDataReader rdr = viewCourses.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    courseIDs.Add(rdr.GetInt32(rdr.GetOrdinal("course_id")));
                }
                sqlConnection.Close();
                if (courseIDs.Contains(courseID))
                {
                    ArrayList instructorIDs = new ArrayList();
                    SqlCommand viewInstructors_Courses = new SqlCommand("Select * From Instructor_Course Where course_id = @courseID", sqlConnection);
                    viewInstructors_Courses.Parameters.Add(new SqlParameter("@courseID", courseID));

                    sqlConnection.Open();
                    rdr = viewInstructors_Courses.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rdr.Read())
                    {
                        instructorIDs.Add(rdr.GetInt32(rdr.GetOrdinal("instructor_id")));
                    }
                    sqlConnection.Close();
                    if (instructorIDs.Contains(instructorID))
                    {
                        ArrayList semesterCodes = new ArrayList();
                        SqlCommand viewSemesters = new SqlCommand("Select * From Semester", sqlConnection);

                        sqlConnection.Open();
                        rdr = viewSemesters.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rdr.Read())
                        {
                            semesterCodes.Add(rdr.GetString(rdr.GetOrdinal("semester_code")));
                        }
                        sqlConnection.Close();
                        if (semesterCodes.Contains(semesterCode))
                        {
                            SqlCommand linkStudentAdvisor = new SqlCommand("Procedures_AdminLinkStudent", sqlConnection);
                            linkStudentAdvisor.CommandType = CommandType.StoredProcedure;
                            linkStudentAdvisor.Parameters.Add(new SqlParameter("@cours_id", courseID));
                            linkStudentAdvisor.Parameters.Add(new SqlParameter("@instructor_id", instructorID));
                            linkStudentAdvisor.Parameters.Add(new SqlParameter("@studentID", studentID));
                            linkStudentAdvisor.Parameters.Add(new SqlParameter("@semester_code", semesterCode));

                            sqlConnection.Open();
                            linkStudentAdvisor.ExecuteNonQuery();
                            sqlConnection.Close();
                            L_Link_Student_Course_Instructor_Out.Text = "Student Linked Successfully.";
                        }
                        else
                        {
                            L_Link_Student_Course_Instructor_Out.Text = "Given Semester Does Not Exist.";
                        }
                    }
                    else
                    {
                        L_Link_Student_Course_Instructor_Out.Text = "Given Instructor Does Not Teach This Course.";
                    }
                }
                else
                {
                    L_Link_Student_Course_Instructor_Out.Text = "Given Course Does Not Exist.";
                }
            }
            catch (SqlException)
            {
                L_Link_Student_Course_Instructor_Out.Text = "Given Student Does Not Exist.";
            }

            catch (FormatException)
            {
                L_Link_Student_Course_Instructor_Out.Text = "Incorrect Format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void B_Admin_View_Instructors_Courses_Click(object sender, EventArgs e)
        {
            L_Instructors_Courses.Text = "Instructors: <br />&nbsp;&nbsp;&nbsp;&nbsp;";

            SqlCommand viewAllInstructorsCourses = new SqlCommand("Select * From Instructors_AssignedCourses", sqlConnection);

            sqlConnection.Open();
            SqlDataReader rdr = viewAllInstructorsCourses.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 iID = rdr.GetInt32(rdr.GetOrdinal("instructor_id"));
                String iFName = rdr.GetString(rdr.GetOrdinal("Instructor"));
                Int32 cID = rdr.GetInt32(rdr.GetOrdinal("course_id"));
                String cName = rdr.GetString(rdr.GetOrdinal("Course"));

                L_Instructors_Courses.Text = L_Instructors_Courses.Text + "Instructor Name: " + iFName + " | ID: " + iID + " | Course Name: " + cName + " | ID: " + cID + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_Instructors_Courses.Visible = true;
        }

        protected void B_View_Instructors_Courses_Clear_Click(object sender, EventArgs e)
        {
            L_Instructors_Courses.Text = "";
            D_Instructors_Courses.Visible = false;
        }

        protected void B_Admin_View_Semesters_Courses_Click(object sender, EventArgs e)
        {
            L_Semesters_Courses.Text = "Semesters: <br />&nbsp;&nbsp;&nbsp;&nbsp;";

            SqlCommand viewAllSemestersCourses = new SqlCommand("Select * From Semster_offered_Courses", sqlConnection);

            sqlConnection.Open();
            SqlDataReader rdr = viewAllSemestersCourses.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 sCode = rdr.GetInt32(rdr.GetOrdinal("semester_code"));
                String cID = rdr.GetString(rdr.GetOrdinal("course_id"));
                Int32 cName = rdr.GetInt32(rdr.GetOrdinal("name"));

                L_Semesters_Courses.Text = L_Semesters_Courses.Text + "Semester Code: " + sCode + " | Course ID: " + cID + " | Course Name: " + cName + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_Semesters_Courses.Visible = true;
        }

        protected void B_View_Semesters_Courses_Clear_Click(object sender, EventArgs e)
        {
            L_Semesters_Courses.Text = "";
            D_Semesters_Courses.Visible = false;
        }
        protected void B_Delete_Course_Click(object sender, EventArgs e)
        {
            D_Delete_Course.Visible = true;
        }

        protected void B_Delete_Course_Cancel_Click(object sender, EventArgs e)
        {
            D_Delete_Course.Visible = false;
            L_1.Text = "";

        }
        protected void B_Delete_Course_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                int C_ID = Int32.Parse(T_Delete_C_ID.Text);
                SqlCommand A_Delete_Course = new SqlCommand("Procedures_AdminDeleteCourse", sqlConnection);
                SqlCommand A_Check_Course = new SqlCommand("Select course_id from Course", sqlConnection);

                A_Delete_Course.CommandType = CommandType.StoredProcedure;
                A_Delete_Course.Parameters.Add(new SqlParameter("@courseID", C_ID));
                ArrayList course = new ArrayList();
                sqlConnection.Open();
                SqlDataReader rdr = A_Check_Course.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    course.Add(rdr.GetInt32(rdr.GetOrdinal("course_id")));
                }
                sqlConnection.Close();
                sqlConnection.Open();
                A_Delete_Course.ExecuteNonQuery();
                sqlConnection.Close();
                if (!course.Contains(C_ID))
                    L_1.Text = "This course does not exist.";
                else
                    L_1.Text = "Successfully deleted course.";
            }
            catch (FormatException)
            {
                L_1.Text = "Please enter correct course ID format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        protected void B_Delete_Slot_Click(object sender, EventArgs e)
        {
            D_Delete_Slot.Visible = true;
        }
        protected void B_Delete_Slot_Cancel_Click(object sender, EventArgs e)
        {
            D_Delete_Slot.Visible = false;
            L_2.Text = "";
        }
        protected void B_Delete_Slot_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                int C_ID = Int32.Parse(T_Delete_S_C_ID.Text);
                SqlCommand A_Delete_Slot = new SqlCommand("Delete from slot where Slot.course_id In (Select Slot.course_id from Slot inner join Course_Semester on Slot.course_id = Course_Semester.course_id where Course_Semester.semester_code != @current_semester and Slot.course_id=@courseID)", sqlConnection);
                SqlCommand A_Check_Course = new SqlCommand("Select course_id from Course", sqlConnection);
                SqlCommand A_Check_Course_Offered = new SqlCommand("Select course_id from Course_Semester where semester_code=@current_semester", sqlConnection);
                A_Check_Course_Offered.Parameters.Add(new SqlParameter("@current_semester", Current_Semester));
                ArrayList course2 = new ArrayList();
                A_Delete_Slot.Parameters.Add(new SqlParameter("@courseID", C_ID));
                A_Delete_Slot.Parameters.Add(new SqlParameter("@current_semester", Current_Semester));
                ArrayList course = new ArrayList();
                sqlConnection.Open();
                A_Delete_Slot.ExecuteScalar();
                SqlDataReader rdr = A_Check_Course.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    course.Add(rdr.GetInt32(rdr.GetOrdinal("course_id")));
                }
                sqlConnection.Close();
                sqlConnection.Open();
                rdr = A_Check_Course_Offered.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    course2.Add(rdr.GetInt32(rdr.GetOrdinal("course_id")));
                }
                sqlConnection.Close();
                if (!course.Contains(C_ID))
                    L_2.Text = "This course does not exist.";
                else
                {
                    if (course2.Contains(C_ID))
                        L_2.Text = "Course is offered in current semester";
                    else
                        L_2.Text = "Successfully deleted all slots in current semester";
                }
            }
            catch (FormatException)
            {
                L_2.Text = "Please enter correct course ID format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void B_Add_Exam_Click(object sender, EventArgs e)
        {
            D_Add_Exam.Visible = true;
        }

        protected void B_Add_Exam_Cancel_Click(object sender, EventArgs e)
        {
            D_Add_Exam.Visible = false;
            L_3.Text = "";
        }

        protected void B_Add_Exam_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                int C_ID = Int32.Parse(T_AE_C_ID.Text);
                String type = T_AE_Type.Text;
                SqlDateTime date = Convert.ToDateTime(T_AE_Date.Text);
                SqlCommand A_Check_Course = new SqlCommand("Select course_id from Course", sqlConnection);
                ArrayList course = new ArrayList();
                SqlCommand A_Add_Exam = new SqlCommand("Procedures_AdminAddExam", sqlConnection);
                A_Add_Exam.CommandType = CommandType.StoredProcedure;
                A_Add_Exam.Parameters.Add(new SqlParameter("@Type", type));
                A_Add_Exam.Parameters.Add(new SqlParameter("@date", date));
                A_Add_Exam.Parameters.Add(new SqlParameter("@courseID", C_ID));
                SqlCommand A_Check_Date = new SqlCommand("select iif ((@date < (CURRENT_TIMESTAMP)),1,0)", sqlConnection);
                A_Check_Date.Parameters.Add(new SqlParameter("@date", date));
                sqlConnection.Open();
                SqlDataReader rdr = A_Check_Course.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    course.Add(rdr.GetInt32(rdr.GetOrdinal("course_id")));
                }
                sqlConnection.Close();
                sqlConnection.Open();
                Int32 check = (Int32)A_Check_Date.ExecuteScalar();
                if (check == 1)
                    L_3.Text = "Date has already passed.";
                else
                {
                    if ((type != "first") && (type != "second"))
                        L_3.Text = "Exam type should be either 'first' or 'second'";
                    else
                    {
                        if (!course.Contains(C_ID))
                            L_3.Text = "This course does not exist.";
                        else
                        {
                            A_Add_Exam.ExecuteNonQuery();
                            L_3.Text = "Makeup Added Successfully.";
                        }
                    }
                }
                sqlConnection.Close();
            }
            catch (FormatException)
            {
                L_3.Text = "Please fill all fields or enter the correct format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        protected void B_View_Payments_Click(object sender, EventArgs e)
        {
            L_4.Text = "";
            D_View_Payments.Visible = true;
            SqlCommand A_View_Payments = new SqlCommand("Select * from dbo.Student_Payment", sqlConnection);
            sqlConnection.Open();
            SqlDataReader rdr = A_View_Payments.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 SID = rdr.GetInt32(rdr.GetOrdinal("studentID"));
                String Sfname = rdr.GetString(rdr.GetOrdinal("f_name"));
                String Slname = rdr.GetString(rdr.GetOrdinal("l_name"));
                Int32 PID = rdr.GetInt32(rdr.GetOrdinal("payment_id"));
                Int32 Pamount = rdr.GetInt32(rdr.GetOrdinal("amount"));
                DateTime Psdate = rdr.GetDateTime(rdr.GetOrdinal("startdate"));
                DateTime Pdeadline = rdr.GetDateTime(rdr.GetOrdinal("deadline"));
                Int32 Pn_installemnts = rdr.GetInt32(rdr.GetOrdinal("n_installments"));
                Decimal Pfund_percent = rdr.GetDecimal(rdr.GetOrdinal("fund_percentage"));
                String status = "";
                try
                {
                    status = rdr.GetString(rdr.GetOrdinal("status"));
                }
                catch { }
                String Sem_Code = rdr.GetString(rdr.GetOrdinal("semester_code"));


                L_4.Text = L_4.Text + "Student ID: " + SID + " | Student Name: " + Sfname + " " + Slname + " | Payment ID: " + PID + " | Amount: " + Pamount + " | Start Date: " + Psdate.ToString("dd/M/yyyy") + " | Deadline: " + Pdeadline.ToString("dd/M/yyyy") + " | Number of Installments: " + Pn_installemnts + " | Fund Percentage:" + Pfund_percent + " | Status: " + status + " | Semester Code:" + Sem_Code + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
        }

        protected void B_View_Payments_Clear_Click(object sender, EventArgs e)
        {
            L_4.Text = "";
            D_View_Payments.Visible = false;
        }

        protected void B_Issue_Installments_Click(object sender, EventArgs e)
        {
            D_Issue_Installments.Visible = true;
        }

        protected void B_Issue_Installments_Cancel_Click(object sender, EventArgs e)
        {
            D_Issue_Installments.Visible = false;
            L_5.Text = "";
        }

        protected void B_Issue_Installments_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 PID = Int32.Parse(T_II_PID.Text);
                SqlCommand A_Issue_Installments = new SqlCommand("Procedures_AdminIssueInstallment", sqlConnection);
                A_Issue_Installments.CommandType = CommandType.StoredProcedure;
                SqlCommand A_Check_Payment = new SqlCommand("Select payment_id from Payment", sqlConnection);
                SqlCommand A_Payment_Installments = new SqlCommand("Select n_installments from Payment where payment_id =@payment_id", sqlConnection);
                SqlCommand A_Installments = new SqlCommand("Select count(*) from Installment where payment_id=@payment_id group by payment_id", sqlConnection);
                A_Issue_Installments.Parameters.Add(new SqlParameter("@payment_id", PID));
                A_Payment_Installments.Parameters.Add(new SqlParameter("@payment_id", PID));
                A_Installments.Parameters.Add(new SqlParameter("@payment_id", PID));
                ArrayList payment = new ArrayList();
                sqlConnection.Open();
                SqlDataReader rdr = A_Check_Payment.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    payment.Add(rdr.GetInt32(rdr.GetOrdinal("payment_id")));
                }
                sqlConnection.Close();
                if (!payment.Contains(PID))
                {
                    L_5.Text = "Payment ID does not exist.";
                }
                else
                {
                    sqlConnection.Open();
                    A_Issue_Installments.ExecuteNonQuery();
                    L_5.Text = "Successfully issued installemts.";
                    sqlConnection.Close();
                }
            }
            catch (FormatException)
            {
                L_5.Text = "Please enter the correct payment ID format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void B_Admin_Update_Student_Status_Click(object sender, EventArgs e)
        {
            D_Update_Student_Status.Visible = true;
        }

        protected void B_Update_Student_Status_Cancel_Click(object sender, EventArgs e)
        {
            L_Update_Student_Status_Out.Text = string.Empty;
            D_Update_Student_Status.Visible = false;
        }

        protected void B_Update_Student_Status_Confirm_Click(object sender, EventArgs e)
        {
            ArrayList studentIDs = new ArrayList();
            SqlCommand viewStudents = new SqlCommand("Select * From Student", sqlConnection);

            sqlConnection.Open();
            SqlDataReader rdr = viewStudents.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                studentIDs.Add(rdr.GetInt32(rdr.GetOrdinal("student_id")));
            }
            sqlConnection.Close();
            try
            {
                int studentID = Int16.Parse(TB_StudentID3.Text);

                if (studentIDs.Contains(studentID))
                {
                    SqlCommand updateStudentStatus = new SqlCommand("Procedure_AdminUpdateStudentStatus", sqlConnection);
                    updateStudentStatus.CommandType = CommandType.StoredProcedure;
                    updateStudentStatus.Parameters.Add(new SqlParameter("@student_id", studentID));

                    sqlConnection.Open();
                    updateStudentStatus.ExecuteNonQuery();
                    sqlConnection.Close();
                    L_Update_Student_Status_Out.Text = "Status Updated Successfully.";
                }
                else
                {
                    L_Update_Student_Status_Out.Text = "This Student Does Not Exist.";
                }
            }
            catch (FormatException)
            {
                L_Update_Student_Status_Out.Text = "Incorrect Format.";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void B_Admin_View_All_Active_Students_Click(object sender, EventArgs e)
        {
            L_Active_Students.Text = "Students: <br />&nbsp;&nbsp;&nbsp;&nbsp;";

            SqlCommand viewAllActiveStudents = new SqlCommand("Select * From view_Students", sqlConnection);

            sqlConnection.Open();
            SqlDataReader rdr = viewAllActiveStudents.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 sID = rdr.GetInt32(rdr.GetOrdinal("student_id"));
                String sFName = rdr.GetString(rdr.GetOrdinal("f_name")) + " " + rdr.GetString(rdr.GetOrdinal("l_name"));
                String sPassword = rdr.GetString(rdr.GetOrdinal("password"));
                Decimal sGPA = rdr.GetDecimal(rdr.GetOrdinal("gpa"));
                String sFaculty = rdr.GetString(rdr.GetOrdinal("faculty"));
                String sEmail = rdr.GetString(rdr.GetOrdinal("email"));
                String sMajor = rdr.GetString(rdr.GetOrdinal("major"));
                Int32 sSemester = rdr.GetInt32(rdr.GetOrdinal("semester"));
                Int32 sAcquiredHours = rdr.GetInt32(rdr.GetOrdinal("acquired_hours"));
                Int32 sAssignedHours = rdr.GetInt32(rdr.GetOrdinal("assigned_hours"));
                Int32 sAdvisorID = rdr.GetInt32(rdr.GetOrdinal("advisor_id"));
                
                L_Active_Students.Text = L_Active_Students.Text + "Name: " + sFName + " | ID: " + sID + " | Password: " + sPassword + " | GPA: " + sGPA + " | Faculty: " + sFaculty + " | Email: " + sEmail + " | Major: " + sMajor + " | Semester: " + sSemester + " | Acquired Hours: " + sAcquiredHours + " | Assigned Hours: " + sAssignedHours + " | Advisor ID: " + sAdvisorID + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_Active_Students.Visible = true;
        }

        protected void B_View_All_Active_Students_Clear_Click(object sender, EventArgs e)
        {
            L_Active_Students.Text = "";
            D_Active_Students.Visible = false;
        }

        protected void B_Admin_View_Students_Transcript_Click(object sender, EventArgs e)
        {
            L_Students_Transcript.Text = "Semesters: <br />&nbsp;&nbsp;&nbsp;&nbsp;";

            SqlCommand viewAllStudentsTranscript = new SqlCommand("Select * From Students_Courses_transcript", sqlConnection);

            sqlConnection.Open();
            SqlDataReader rdr = viewAllStudentsTranscript.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 sID = rdr.GetInt32(rdr.GetOrdinal("student_id"));
                String sFName = rdr.GetString(rdr.GetOrdinal("f_name")) + " " + rdr.GetString(rdr.GetOrdinal("l_name"));
                Int32 cID = rdr.GetInt32(rdr.GetOrdinal("course_id"));
                String cName = rdr.GetString(rdr.GetOrdinal("name"));
                String eType = rdr.GetString(rdr.GetOrdinal("exam_type"));
                String eGrade = "";
                try
                {
                    rdr.GetString(rdr.GetOrdinal("grade"));
                }
                catch (SqlNullValueException) { }
                String eSemester = rdr.GetString(rdr.GetOrdinal("semester_code"));
                L_Students_Transcript.Text = L_Students_Transcript.Text + "Student Name: " + sFName + " | ID: " + sID + " | Course Name: " + cName + " | ID: " + cID + " | Exam Type: " + eType + " | Exam Grade: " + eGrade + " | Semester: " + eSemester + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_Students_Transcript.Visible = true;
        }

        protected void B_View_Students_Transcript_Clear_Click(object sender, EventArgs e)
        {
            L_Students_Transcript.Text = "";
            D_Students_Transcript.Visible = false;
        }

        protected void B_Admin_View_Gradplan_Advisor_Click(object sender, EventArgs e)
        {
            L_Gradplan_Advisor.Text = "Graduation Plans: <br />&nbsp;&nbsp;&nbsp;&nbsp;";

            SqlCommand viewAllGradplansAdvisor = new SqlCommand("Select * From Advisors_Graduation_Plan", sqlConnection);

            sqlConnection.Open();
            SqlDataReader rdr = viewAllGradplansAdvisor.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 gID = rdr.GetInt32(rdr.GetOrdinal("plan_id"));
                String gSemesterCode = rdr.GetString(rdr.GetOrdinal("semester_code"));
                Int32 gSemesterCreditHours = rdr.GetInt32(rdr.GetOrdinal("semester_credit_hours"));
                DateTime gExpectedGradDate = rdr.GetDateTime(rdr.GetOrdinal("expected_grad_date"));
                Int32 gStudentID = rdr.GetInt32(rdr.GetOrdinal("student_id"));
                Int32 aID = rdr.GetInt32(rdr.GetOrdinal("AdvisorID"));
                String aName = rdr.GetString(rdr.GetOrdinal("advisor_name"));

                L_Gradplan_Advisor.Text = L_Gradplan_Advisor.Text + "Plan ID: " + gID + " | Semester Code: " + gSemesterCode + " | Credit Hours: " + gSemesterCreditHours + " | Expected Graduation Date: " + gExpectedGradDate.ToString("dd/M/yyyy") + " | Student ID: " + gStudentID + " | Advisor ID: " + aID + " | Advisor Name: " + aName + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            sqlConnection.Close();
            D_Gradplan_Advisor.Visible = true;
        }

        protected void B_View_Gradplan_Advisor_Clear_Click(object sender, EventArgs e)
        {
            L_Gradplan_Advisor.Text = "";
            D_Gradplan_Advisor.Visible = false;
        }
    }
}