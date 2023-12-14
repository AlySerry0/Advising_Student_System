using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Student
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void register_confirm(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connStr);

            String S_firstname = S_R_firstname.Text;
            String S_lastname = S_R_lastname.Text;
            String S_password = S_R_password.Text;
            String S_faculty = S_R_faculty.Text;
            String S_email = S_R_email.Text;
            String S_major = S_R_major.Text;
            int S_semester = Int16.Parse(S_R_semester.Text);

            SqlCommand S_R_procedure = new SqlCommand("Procedures_StudentRegistration", sqlConnection);
            S_R_procedure.CommandType = CommandType.StoredProcedure;
            S_R_procedure.Parameters.Add(new SqlParameter("@first_name", S_firstname));
            S_R_procedure.Parameters.Add(new SqlParameter("@last_name", S_lastname));
            S_R_procedure.Parameters.Add(new SqlParameter("@password", S_password));
            S_R_procedure.Parameters.Add(new SqlParameter("@faculty", S_faculty));
            S_R_procedure.Parameters.Add(new SqlParameter("@email", S_email));
            S_R_procedure.Parameters.Add(new SqlParameter("@major", S_major));
            S_R_procedure.Parameters.Add(new SqlParameter("@semester", S_semester));

            SqlParameter S_id = S_R_procedure.Parameters.Add(new SqlParameter("@Student_id", SqlDbType.Int));
            S_id.Direction = ParameterDirection.Output;

            sqlConnection.Open();
            S_R_procedure.ExecuteNonQuery();
            sqlConnection.Close();
            Response.Redirect("Student_Homepage.aspx?" + "msg=" + S_id.Value.ToString(), false);
            Response.End();
        }
        protected void register_cancel(object sender, EventArgs e)
        {
            Response.Redirect("Student_HomePage.aspx");
        }
    }
}