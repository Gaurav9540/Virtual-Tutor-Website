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
using static System.Net.Mime.MediaTypeNames;

namespace HR_Web_Application
{
    public partial class changepassword : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        public static string empid = "";
        string parameterValueOfnameid = "";
        string parameterValueOfLevel = "";
        string parameterValueOfMob = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*parameterValueOfnameid = HttpContext.Current.Request.QueryString["nameid"];
                parameterValueOfLevel = HttpContext.Current.Request.QueryString["level"];
                parameterValueOfMob = HttpContext.Current.Request.QueryString["mob"];*/



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


        public void checkIsPasswordPresent()
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_InsertDetails";
            sqlcon.Open();
            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "checkPass");
                com.Parameters.AddWithValue("@proFname", "");
                com.Parameters.AddWithValue("@proLname", "");
                com.Parameters.AddWithValue("@proDOB", "");
                com.Parameters.AddWithValue("@proEmail", "");
                com.Parameters.AddWithValue("@proMobile", txtmobile.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proState", "");
                com.Parameters.AddWithValue("@proAddres", "");
                com.Parameters.AddWithValue("@proDOJ", "");
                com.Parameters.AddWithValue("@proUsername", "");
                com.Parameters.AddWithValue("@proPassword", txtoldpass.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proLevel", "".ToString().Trim());
                com.Parameters.AddWithValue("@proStatus", "".ToString().Trim());
                com.Parameters.AddWithValue("@proCreatedDate", "");
                com.Parameters.AddWithValue("@proLastUpdatedDate", "");
                com.Parameters.AddWithValue("@proLastUpdatedBy", "");
                SqlParameter messageParameter = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                messageParameter.Direction = ParameterDirection.Output;
                com.Parameters.Add(messageParameter);

                com.ExecuteNonQuery();
                //  sqlcon.InfoMessage += Connection_InfoMessage;
                string message = messageParameter.Value.ToString();
                if (message == "password exists")
                {
                    insertRecord();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Old Password doesnot match with our records');", true);
                }

                /* int i = com.ExecuteNonQuery();
                 if (i != 0)
                 {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your Password changed Successfully');", true);
                     clear();
                 }*/


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
        public void insertRecord()
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_InsertDetails";
            sqlcon.Open();
            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "changepass");
                com.Parameters.AddWithValue("@proFname", "");
                com.Parameters.AddWithValue("@proLname", "");
                com.Parameters.AddWithValue("@proDOB", "");
                com.Parameters.AddWithValue("@proEmail", "");
                com.Parameters.AddWithValue("@proMobile", txtmobile.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proState", "");
                com.Parameters.AddWithValue("@proAddres", "");
                com.Parameters.AddWithValue("@proDOJ", "");
                com.Parameters.AddWithValue("@proUsername", "");
                com.Parameters.AddWithValue("@proPassword", txtconfirmpass.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proLevel", "".ToString().Trim());
                com.Parameters.AddWithValue("@proStatus", "".ToString().Trim());
                com.Parameters.AddWithValue("@proCreatedDate", "");
                com.Parameters.AddWithValue("@proLastUpdatedDate", "");
                com.Parameters.AddWithValue("@proLastUpdatedBy", "");
                SqlParameter messageParameter = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                messageParameter.Direction = ParameterDirection.Output;
                com.Parameters.Add(messageParameter);


                //  sqlcon.InfoMessage += Connection_InfoMessage;

                int i = com.ExecuteNonQuery();
                if (i != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your Password changed Successfully');", true);
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

        protected void changepass_Click(object sender, EventArgs e)
        {
            //insertRecord();
            checkIsPasswordPresent();
            clear();
        }

        public void clear()
        {
            // txtAttendanceDate.Text = "";
            txtconfirmpass.Text = "";
            txtmobile.Text = "";
            txtnewpass.Text = "";
            txtoldpass.Text = "";
        }
    }
}