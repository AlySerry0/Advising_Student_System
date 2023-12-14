using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Advisor_HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["msg"] != null)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["msg"].ToString()))
                    Response.Write("Registration Successful. Your Advisor ID is: " + Request.QueryString["msg"].ToString() + ".");

            }
        }

        protected void B_Advisor_Homepage_Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Register.aspx");
        }

        protected void B_Advisor_Homepage_Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Login.aspx");
        }
    }
}