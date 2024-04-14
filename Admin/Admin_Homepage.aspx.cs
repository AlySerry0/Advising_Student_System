using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class Admin_Homepage : System.Web.UI.Page
    {
        private readonly int userID = 0;
        private readonly int userPassword = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void B_Admin_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Homepage.aspx");
        }
        protected void B_Login_Click(object sender, EventArgs e)
        {
            if(TB_UserID.Text == userID.ToString() && TB_Password.Text == userPassword.ToString())
            {
                Response.Redirect("Admin_Dashboard.aspx");
            }
            else
            {
                L_Login_Out.Text = "Invalid UserID or Password";
            }
        }
    }
}