using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Advisor_login : System.Web.UI.Page
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

                int A_id = Int16.Parse(A_L_id.Text);
                String A_password = A_L_password.Text;

                SqlCommand A_L_function = new SqlCommand("Select dbo.FN_AdvisorLogin(@advisor_Id, @password)", sqlConnection);
                A_L_function.Parameters.AddWithValue("@advisor_Id", A_id);
                A_L_function.Parameters.AddWithValue("@password", A_password);
                sqlConnection.Open();
                Boolean Success = (Boolean)(A_L_function.ExecuteScalar());
                sqlConnection.Close();

                if (!Success)
                {
                    Response.Write("Invalid Userid/Password");
                }
                else
                {
                    Response.Redirect("Advisor_Dashboard.aspx?" + "msg=" + A_id, false);
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
            Response.Redirect("Advisor_Homepage.aspx");
        }
    }
}