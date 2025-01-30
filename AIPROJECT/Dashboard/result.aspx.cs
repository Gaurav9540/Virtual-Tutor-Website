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
using static System.Net.Mime.MediaTypeNames;

namespace HR_Web_Application
{
    public partial class result : System.Web.UI.Page
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
                //parameterValueOfnameid = Session["parameterValueOfnameid"].ToString();
                //parameterValueOfLevel = Session["parameterValueOfLevel"].ToString();
                //parameterValueOfMob = Session["parameterValueOfMob"].ToString();

                parameterValueOfnameid = HttpContext.Current.Request.QueryString["nameid"];
                parameterValueOfLevel = HttpContext.Current.Request.QueryString["level"];
                parameterValueOfMob = HttpContext.Current.Request.QueryString["mob"];

                Session["parameterValueOfnameid"] = parameterValueOfnameid;
                Session["parameterValueOfLevel"] = parameterValueOfLevel;
                Session["parameterValueOfMob"] = parameterValueOfMob;

                // Check if the parameter exists
                if (!string.IsNullOrEmpty(parameterValueOfnameid) && !string.IsNullOrEmpty(parameterValueOfLevel) && !string.IsNullOrEmpty(parameterValueOfMob))
                {

                    populateExamCode("7725064078");
                    //lblShowName.Text = Security.Decryption(parameterValueOfnameid).ToUpper();

                }
                else
                {
                    Response.Redirect("~/loginPage/login.aspx");
                }

               


            }
        }


        protected void populateExamCode(string mobileNumber)
        {
            ddlExamCode.Items.Clear(); // Clear existing items
            ddlExamCode.Items.Insert(0, new ListItem("- Select -", "")); // Add the default "Select" option

            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_getresult";
            sqlcon.Open();
            try
            {

                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getExamCode");
                com.Parameters.AddWithValue("@mobilnumber", mobileNumber);
                com.Parameters.AddWithValue("@subject", "");
                com.Parameters.AddWithValue("@class", "");
                com.Parameters.AddWithValue("@examcode", "");


                using (SqlDataReader reader = com.ExecuteReader())
                {

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string value = reader.GetString(0); // Assuming the column is of string type, adjust if it's a different type
                            ddlExamCode.Items.Add(new ListItem(value, value));


                        }

                    }
                    else
                    {

                    }

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


        protected void showResultData_Click(object sender, EventArgs e)
        {
            string getddlExamCode = ddlExamCode.SelectedItem.Text;

            getResult(getddlExamCode);
        }
        public void getResult(string examCode)
        {


            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_getresult";
            sqlcon.Open();

            try
            {

                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getUserResult");
                com.Parameters.AddWithValue("@mobilnumber", "");
                com.Parameters.AddWithValue("@subject", "");
                com.Parameters.AddWithValue("@class", "");
                com.Parameters.AddWithValue("@examcode", examCode);


                using (SqlDataReader reader = com.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        showResultArea.Visible = true;

                        lblexamcode.Text = examCode;
                        lbldateOfExam.Text = reader["dateOfExam"].ToString();
                        lblQuestionAttempt.Text = reader["attemptQuestion"].ToString();
                        lblSubject.Text = reader["subject"].ToString();
                        lblCorrectAnswer.Text = reader["correctAnswer"].ToString();
                        lblWrongAnswer.Text = reader["wrongAnswer"].ToString();
                        lblPercentage.Text = reader["percentage"].ToString();
                        lblGrade.Text = reader["grade"].ToString();


                    }
                    else
                    {
                        showResultArea.Visible = false;

                    }

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