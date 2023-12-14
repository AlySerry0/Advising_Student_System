using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_confirm(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Database_Connection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connStr);

            String A_name = A_R_name.Text;
            String A_password = A_R_password.Text;
            String A_email = A_R_email.Text;
            String A_office = A_R_office.Text;

            SqlCommand A_R_procedure = new SqlCommand("Procedures_AdvisorRegistration", sqlConnection);
            A_R_procedure.CommandType = CommandType.StoredProcedure;
            A_R_procedure.Parameters.Add(new SqlParameter("@advisor_name", A_name));
            A_R_procedure.Parameters.Add(new SqlParameter("@password", A_password));
            A_R_procedure.Parameters.Add(new SqlParameter("@email", A_email));
            A_R_procedure.Parameters.Add(new SqlParameter("@office", A_office));

            SqlParameter A_id = A_R_procedure.Parameters.Add(new SqlParameter("@Advisor_id", SqlDbType.Int));
            A_id.Direction = ParameterDirection.Output;

            sqlConnection.Open();
            A_R_procedure.ExecuteNonQuery();
            sqlConnection.Close();
            Response.Redirect("Advisor_Homepage.aspx?" + "msg=" + A_id.Value.ToString(), false);
            Response.End();
            }

        protected void register_cancel(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_HomePage.aspx");
        }
    }
}