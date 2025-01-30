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

namespace HR_Web_Application
{
    public partial class forgotpassword : System.Web.UI.Page
    {

        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                updateData();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void updateData()
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_EmployeesDetails";
            sqlcon.Open();

            try
            {

                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "passupdate".ToString().Trim());
                com.Parameters.AddWithValue("@Empid", Session["EmpID"].ToString().Trim());
                com.Parameters.AddWithValue("@FirstName", "".ToString().Trim());
                com.Parameters.AddWithValue("@LastName", "".ToString().Trim());
                com.Parameters.AddWithValue("@MobileNumber", "".ToString().Trim());
                com.Parameters.AddWithValue("@AltMobileNumber", "".ToString().Trim());
                com.Parameters.AddWithValue("@Email", "".ToString().Trim());
                com.Parameters.AddWithValue("@Company_Email", "".ToString().Trim());
                com.Parameters.AddWithValue("@Address", "".ToString().Trim());
                com.Parameters.AddWithValue("@Address2", "".ToString().Trim());
                com.Parameters.AddWithValue("@AadharNumber", "".ToString().Trim());
                com.Parameters.AddWithValue("@PANCard", "".ToString().Trim());
                com.Parameters.AddWithValue("@status", "".ToString().Trim());
                com.Parameters.AddWithValue("@Inserted_date", "");
                com.Parameters.AddWithValue("@Updated_date", "");
                com.Parameters.AddWithValue("@passwords", txtConPass.Text.ToString().Trim());
                com.Parameters.AddWithValue("@Roles", "".ToString().Trim());
                com.Parameters.AddWithValue("@Designation", "".ToString().Trim());
                com.Parameters.AddWithValue("@Dateofbirth", "".ToString().Trim());


                int i = com.ExecuteNonQuery();
                if (i > 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Updated sucessfully');", true);

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
        public void clear()
        {
            txtConPass.Text = "";
            txtNewPass.Text = "";
            txtOldPass.Text = "";
        }
    }
}