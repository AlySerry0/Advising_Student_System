using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Student
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Confirm(object sender, EventArgs e)
        {
            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
                SqlConnection sqlConnection = new SqlConnection(connStr);

                int S_id = Int16.Parse(S_L_id.Text);
                String S_password = S_L_password.Text;

                SqlCommand S_L_function = new SqlCommand("Select dbo.FN_StudentLogin(@Student_id, @password)", sqlConnection);
                S_L_function.Parameters.AddWithValue("@Student_id", S_id);
                S_L_function.Parameters.AddWithValue("@password", S_password);
                sqlConnection.Open();
                Boolean Success = (Boolean)(S_L_function.ExecuteScalar());
                sqlConnection.Close();

                if (!Success)
                {
                    Response.Write("Invalid Userid/Password");
                }
                else
                {
                    Response.Redirect("Student_Dashboard.aspx?" + "msg=" + S_id, false);
                    Response.End();
                }
            }
            catch (FormatException)
            {
                Response.Write("Invalid UserID Format");
            }
        }
        protected void Login_Cancel(object sender, EventArgs e)
        {
            Response.Redirect("Student_Homepage.aspx");
        }
    }
}