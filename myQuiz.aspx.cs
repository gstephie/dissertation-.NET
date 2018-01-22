using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineQuiz
{
    public partial class myQuiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session["username"]);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("myQuiz.aspx");
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Response.Write("Radio button1 clicked");
            GridView2.Visible = true;
        }



        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Response.Write("Radio button2 clicked");
            GridView2.Visible = true;

        }

        /*protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }*/

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedValue=="")
            {
                Response.Write("Please Select WET or NOT WET");
            }
            else
            {
                GridView2.Visible = true; 
            }
            /*if()
            {

            }*/
        }
    }
}