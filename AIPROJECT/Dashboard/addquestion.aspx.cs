using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Data;
using System.Configuration;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Threading;

namespace HR_Web_Application
{
    public partial class addquestion : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        public static string id = "", role = "", name = "", userClass = "";
        public static string queryStrValue = "";
        int[] a = new int[5];
        int t;

        string parameterValueOfnameid = "";
        string parameterValueOfLevel = "";
        string parameterValueOfMob = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                parameterValueOfnameid = Session["parameterValueOfnameid"].ToString();
                parameterValueOfLevel = Session["parameterValueOfLevel"].ToString();
                parameterValueOfMob = Session["parameterValueOfMob"].ToString();

                // Check if the parameter exists
                if (!string.IsNullOrEmpty(parameterValueOfnameid) && !string.IsNullOrEmpty(parameterValueOfLevel) && !string.IsNullOrEmpty(parameterValueOfMob))
                {

                    //lblShowName.Text = Security.Decryption(parameterValueOfnameid).ToUpper();

                }
                else
                {
                    Response.Redirect("~/loginPage/login.aspx");
                }

            }
        }

        protected void addQuestion_Click(object sender, EventArgs e)
        {
            insertData();
            clear();
        }
        public void clear()
        {
            txtQuestion.Text = "";
            txtopt1.Text = "";
            txtopt2.Text = "";
            txtopt3.Text = "";
            txtopt4.Text = "";
            txtcorrect.Text = "";
            ddlsubject.SelectedValue = ddlsubject.Items.FindByText("-Select Subject-").Value;
            ddlclass.SelectedValue = ddlclass.Items.FindByText("-Select Class-").Value;

        }




        static string GenerateRandomNumbers()
        {
            string getrandom = "";
            Random random = new Random();

            while (true)
            {
                // Get current date and time
                DateTime now = DateTime.Now;

                // Format the date and time
                string formattedDate = now.ToString("HHmmssfff");

                // Generate a random number between 0 and 99999
                int randomNumber = random.Next(100000);

                // Append the random number to the formatted date and time
                string uniqueNumber = "QUES" + formattedDate + randomNumber.ToString("D5");

                // Sleep for 1 second
                Thread.Sleep(1000);
                getrandom = uniqueNumber;

                // Break the loop and return the generated random number
                break;
            }

            return getrandom;
        }


        public void insertData()
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_questionbank";
            sqlcon.Open();
            string classvalue = "";

            string randomNum = GenerateRandomNumbers();
            if (ddlclass.SelectedItem.Text == "Class V")
            {
                classvalue = "fifth";
            }
            else if (ddlclass.SelectedItem.Text == "Class VI")
            {
                classvalue = "sixth";
            }
            else if(ddlclass.SelectedItem.Text == "Class VII")
            {
                classvalue = "seventh";
            }
            else if (ddlclass.SelectedItem.Text == "Class VIII")
            {
                classvalue = "eighth";
            }
            else if (ddlclass.SelectedItem.Text == "Class IX")
            {
                classvalue = "nineth";
            }
            else if (ddlclass.SelectedItem.Text == "Class X")
            {
                classvalue = "tenth";
            }

            try
            {

                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "insert");
                com.Parameters.AddWithValue("@QuesCode", randomNum.ToString());
                com.Parameters.AddWithValue("@QuestName", txtQuestion.Text.ToString().Trim());
                com.Parameters.AddWithValue("@option1", txtopt1.Text.ToString().Trim());
                com.Parameters.AddWithValue("@option2", txtopt2.Text.ToString().Trim());
                com.Parameters.AddWithValue("@option3", txtopt3.Text.ToString().Trim());
                com.Parameters.AddWithValue("@option4", txtopt4.Text.ToString().Trim());
                com.Parameters.AddWithValue("@Correctanw", txtcorrect.Text.ToString().Trim());
                com.Parameters.AddWithValue("@Class", classvalue.ToString().Trim());
                com.Parameters.AddWithValue("@subject", ddlsubject.SelectedItem.Text.ToString().Trim());
                com.Parameters.AddWithValue("@UpdatedDate", "");
                //Response.Write(DateTime.Now.ToString("yyyy-MM-dd").Trim());

                int i = com.ExecuteNonQuery();
                if (i != 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Inserted sucessfully');", true);

                    clear();

                }
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                sqlcon.Close();
            }
            finally
            {
                sqlcon.Close();
            }
        }


    }
}