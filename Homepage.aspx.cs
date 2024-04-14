using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void B_Student_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student/Student_Homepage.aspx");
        }
        protected void B_Advisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("Advisor/Advisor_Homepage.aspx");
        }
        protected void B_Admin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin/Admin_Homepage.aspx");
        }
    }
}