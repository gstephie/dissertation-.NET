using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace onlineQuiz
{
    
    public partial class GameQuiz : System.Web.UI.Page
    {
        string wt="";
        string name = "";
        

        private string connString = WebConfigurationManager.ConnectionStrings["UkPlacesConnectionString"].ConnectionString;

        private bool wetnessCheck(string name, string wt)
        {
            name = GridView1.Rows[0].Cells[0].Text;
            if (RadioButtonList1.SelectedValue == "0")
            {
                wt = "false";
            }
            else if(RadioButtonList1.SelectedValue == "1")
            {
                wt = "true";
            }
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("SELECT name,wet_notwet FROM dbo.places WHERE name=@name AND wet_notwet=@wt", connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@wt", wt);
            connection.Open();
            string result = Convert.ToString(command.ExecuteScalar());
            if (String.IsNullOrEmpty(result)) return false; return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if(Page.IsPostBack)
            {*/
            
            if (Session["questions"] != null)
            {
                Label4.Visible = false;
                Label2.Text = "You have "+Session["correct"].ToString()+" correct answers";
                Label3.Text = "You have " + Session["wrong"].ToString() + " wrong answers";
                //Session["questions"] = questNumb;
                if ((int)Session["wrong"] == 1)
                {
                    Image1.ImageUrl = @"~\2ndCharacter.png";
                }
                else if ((int)Session["wrong"] == 2)
                {
                    Image1.ImageUrl = @"~\3rdCharacter.png";

                }
                else if ((int)Session["wrong"] == 3)
                {
                    Image1.ImageUrl = @"~\character4.1.png";

                }
                //Label2.Text = "You have " + corrAns + " correct answers.";
                //Label3.Text = "You have " + wrongAns + " wrong answers.";
            }
        //}

            else
            {
                Label4.Visible = true;
                int corrAns = 0;
                int wrongAns = 0;
                int questNumb = 0;

                Session["correct"] = corrAns;
                Session["wrong"] = wrongAns;
                Session["questions"] = questNumb;

                Label2.Text = "You have " + corrAns + " correct answers.";
                Label3.Text = "You have " + wrongAns + " wrong answers.";

            }

            //GridView2.Visible = false;
            GridView1.Visible = true;
            Label1.Text = "";
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("GameQuiz.aspx");
            bool result = wetnessCheck(name, wt);

            int corrAns = (int)Session["correct"];
            int wrongAns = (int)Session["wrong"];
            int questNumb = (int)Session["questions"];



            Label4.Visible=false;

            if (result)
            {
                GridView1.Columns[2].Visible = true;
                GridView1.Columns[3].Visible = true;
                GridView1.Columns[4].Visible = true;

                /*while (questNumb < 6)
                {*/

                Label1.Text = "Well done you got it right, press next to go to the next question";
                corrAns++;
                questNumb++;
                //GridView2.Visible = true;
                Button1.Visible = false;
                Button2.Visible = true;
                //Label2.Text = "You have " + corrAns + " correct answers.";
                //Label3.Text = "You have " + wrongAns + " wrong answers.";
                //}
                Session["correct"] = corrAns;
                Session["wrong"] = wrongAns;
                Session["questions"] = questNumb;
                Label2.Text = "You have " + Session["correct"].ToString() + " correct answers";
                Label3.Text = "You have " + Session["wrong"].ToString() + " wrong answers";

                RadioButtonList1.Visible = false;

            }
            //else if (RadioButtonList1.SelectedValue == "1")
            else
            {
                GridView1.Columns[2].Visible = true;
                GridView1.Columns[3].Visible = true;
                GridView1.Columns[4].Visible = true;

                /*while (questNumb < 6)
                {*/

                Label1.Text = "Sorry that was not the answer, press next to go to the next question";
                questNumb++;
                wrongAns++;
                //GridView2.Visible = true;
                Button1.Visible = false;
                Button2.Visible = true;
                //Label2.Text = "You have " + corrAns + " correct answers.";
                //Label3.Text = "You have " + wrongAns + " wrong answers.";
                //}

                Session["correct"] = corrAns;
                Session["wrong"] = wrongAns;
                Session["questions"] = questNumb;

                Label2.Text = "You have " + Session["correct"].ToString() + " correct answers";
                Label3.Text = "You have " + Session["wrong"].ToString() + " wrong answers";

                RadioButtonList1.Visible = false;

            }

            if (wrongAns==1)
            {
                /*form1.BackColor = Image.FromFile
                   (System.Environment.GetFolderPath
                   (System.Environment.SpecialFolder.Personal)
                   + @"\Image.gif"); this.BackgroundImage=new Bitmap()
                Form.BackgroundImage= @"~\character2-new.png";*/
                Image1.ImageUrl = @"~\2ndCharacter.png";
            }
            else if(wrongAns ==2)
            {
                Image1.ImageUrl = @"~\3rdCharacter.png";

            }
            else if(wrongAns ==3)
            {
                Image1.ImageUrl = @"~\character4.1.png";

            }
            else if(wrongAns ==4)
            {
                Image1.ImageUrl = @"~\character5.png";
                Label5.Text="Sorry you lost, you got 4 wrong answers but you should try again!";
                Button3.Visible = true;
                Button1.Visible = false;
                Button2.Visible = false;
                GridView1.Visible = false;
                Label1.Text = "";
            }
            if (wrongAns != 4)
            {
                if (questNumb == 6)
                {
                    Label5.Text = "Well done! You finished the game with " + corrAns + " correct answers and " + wrongAns + " wrong answers.  But you should keep playing!";
                    Button3.Visible = true;
                    Button1.Visible = false;
                    Button2.Visible = false;
                    GridView1.Visible = false;
                    Label1.Text = "";

                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("GameQuiz.aspx");
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["correct"] = 0;
            Session["wrong"] = 0;
            Session["questions"] = 0;

            Image1.ImageUrl = @"~\manCharacter.png";

            Response.Redirect("GameQuiz.aspx");

            Label4.Text = "Place-names can tell us whether a place is naturally wet or dry.  Trouble is, many of these names are more than a thousand years old. What they mean is not always easy to make out from their modern spellings. Answer her six place-name questions and see whether you can keep your head above water.  Good luck!";
        }
    }
}