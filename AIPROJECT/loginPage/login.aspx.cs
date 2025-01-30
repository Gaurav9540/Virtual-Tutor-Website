using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace AI_Project.loginPage
{
    public partial class login : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            txtUsername.Focus();
            //txtFullName.Focus();

        }


        public string checkLoginnew()
        {
            string checkExists = "";
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_InsertDetails";
            sqlcon.Open();
            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "checklogin");
                com.Parameters.AddWithValue("@proFname", "");
                com.Parameters.AddWithValue("@proLname", "");
                com.Parameters.AddWithValue("@proDOB", "");
                com.Parameters.AddWithValue("@proEmail", "");
                com.Parameters.AddWithValue("@proMobile", "");
                com.Parameters.AddWithValue("@proState", "");
                com.Parameters.AddWithValue("@proAddres", "");
                com.Parameters.AddWithValue("@proDOJ", "");
                com.Parameters.AddWithValue("@proUsername", txtUsername.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proPassword", txtPassword.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proLevel", "");
                com.Parameters.AddWithValue("@proStatus", "");
                com.Parameters.AddWithValue("@proCreatedDate", "");
                com.Parameters.AddWithValue("@proLastUpdatedDate", "");
                com.Parameters.AddWithValue("@proLastUpdatedBy", "");


                SqlParameter messageParameter = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                messageParameter.Direction = ParameterDirection.Output;
                com.Parameters.Add(messageParameter);

                SqlDataReader reader = com.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string fname = reader["proFname"].ToString();
                        string level = reader["proLevel"].ToString();
                        string mob = reader["proMobile"].ToString();
                        Session["Fname"] = fname;
                        Session["level"] = level;
                        Session["mob"] = mob;
                        checkExists = "pass";

                    }
                }
                else
                {
                    checkExists = "fail";
                }

                sqlcon.Close();
                string message = messageParameter.Value.ToString();
                if (message == "user not exists")
                {
                    checkExists = "fail";
                }
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
                sqlcon.Close();
                checkExists = "fail";
            }
            finally
            {
                sqlcon.Close();
            }

            return checkExists;
        }
        // Event handler for the InfoMessage event
        public void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            // Print the message from SQL Server
            // Console.WriteLine(e.Message);
            string checkValue = e.Message.ToString();
            Session["Check"] = checkValue;
        }
        public string checkLogin()
        {
            string chkloginExists = "0";

            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand("select proUsername, proPassword,proStatus, notepad from tbl_profile where proUsername='" + txtUsername.Text.ToString().Trim() + "' and proPassword='" + txtPassword.Text.ToString().Trim() + "' and proStatus='active' and proLevel='user'", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    string UserRole = rdr["proLevel"].ToString().ToUpper();

                    chkloginExists = UserRole;
                }
                else
                {
                    chkloginExists = "";
                }
            }

            return chkloginExists;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string getUsername = txtUsername.Text.Trim().ToLower();
            string getPassword = txtPassword.Text.Trim().ToLower();

            if (getUsername != "" && getPassword != "")
            {



                string getResult = checkLoginnew();
                if (getResult == "pass")
                {
                    string userName = Session["Fname"].ToString();
                    string level = Session["level"].ToString();
                    string mob = Session["mob"].ToString();

                    lblErrPassMsg.Text = "Login successfull";
                    //string userid = Security.Ecryption(userName.ToString().Trim());
                    //string role = Security.Ecryption(level.ToString());

                    //string userid = userName.ToString().Trim();
                    //string role = level.ToString();

                    Response.Redirect("~/Website/tutorial.aspx?nameid=" + userName + "&level=" + level + "&mob=" + mob);
                }
                else
                {
                    lblErrPassMsg.Text = "Please enter valid username & password";
                }

            }
            else
            {
                lblErrPassMsg.Text = "Please enter username & password";
            }
        }
        protected void btnSubmitSignUp_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text != "" && txtMobile.Text != "" && txtUsernameVal.Text != "" && txtPaswordVal.Text != "")
            {
                //save to database
                insertSignUpData();
            }
            else
            {
                errlblPasswordVal.Text = "something went wrong try again";
            }
        }

        public void insertSignUpData()
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_InsertDetails";
            sqlcon.Open();
            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "insert");
                com.Parameters.AddWithValue("@proFname", txtFullName.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proLname", "");
                com.Parameters.AddWithValue("@proDOB", "");
                com.Parameters.AddWithValue("@proEmail", "");
                com.Parameters.AddWithValue("@proMobile", txtMobile.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proState", "");
                com.Parameters.AddWithValue("@proAddres", "");
                com.Parameters.AddWithValue("@proDOJ", "");
                com.Parameters.AddWithValue("@proUsername", txtUsernameVal.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proPassword", txtPaswordVal.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proLevel", "user".ToString().Trim());
                com.Parameters.AddWithValue("@proStatus", "active".ToString().Trim());
                com.Parameters.AddWithValue("@proCreatedDate", "");
                com.Parameters.AddWithValue("@proLastUpdatedDate", "");
                com.Parameters.AddWithValue("@proLastUpdatedBy", "");

                SqlParameter messageParameter = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                messageParameter.Direction = ParameterDirection.Output;
                com.Parameters.Add(messageParameter);
                // Execute the command
                com.ExecuteNonQuery();

                // Retrieve the message from the output parameter
                string message = messageParameter.Value.ToString();


                //  sqlcon.InfoMessage += Connection_InfoMessage;

                // int i = com.ExecuteNonQuery();

                if (message == "mobile number exists")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Given details is already exists, please try again.');", true);

                }
                else if (message == "username is exists")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Given username is already exists, please try again with other username');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your Successfully SignUp Done');", true);
                    clear();
                }


                sqlcon.Close();
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
                sqlcon.Close();
            }
            finally
            {
                sqlcon.Close();
            }
        }
        public void clear()
        {
            txtFullName.Text = "";
            txtMobile.Text = "";
            txtPassword.Text = "";
            txtPaswordVal.Text = "";
            txtUsername.Text = "";
            txtUsernameVal.Text = "";

        }


    }


}