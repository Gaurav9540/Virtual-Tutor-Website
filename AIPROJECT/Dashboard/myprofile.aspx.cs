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
using System.Globalization;

namespace HR_Web_Application
{
    public partial class myprofile : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        string parameterValueOfnameid = "";
        string parameterValueOfLevel = "";
        string parameterValueOfMob = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string getEmployeeID = displayEmpdetails();
                /* if (Session["EmpID"].ToString() != null)
                 {
                     txtEmpid.Text = Session["EmpID"].ToString();
                     getEmployeeData(txtEmpid.Text);
                 }
                 ddldesignation.Attributes.Add("Readonly", "Readonly");
                 ddlRoles.Attributes.Add("Readonly", "Readonly");
                 ddlstatus.Attributes.Add("Readonly", "Readonly");
                 ddldesignation.Enabled = false;
                 ddlRoles.Enabled = false;
                 ddlstatus.Enabled = false;*/
                parameterValueOfnameid = HttpContext.Current.Request.QueryString["nameid"];
                parameterValueOfLevel = HttpContext.Current.Request.QueryString["level"];
                parameterValueOfMob = HttpContext.Current.Request.QueryString["mob"];

                //remove once it will donw as dynmic
                /* parameterValueOfnameid = "yogesh";
                 parameterValueOfLevel = "admin";
                 parameterValueOfMob = "8793206404";*/

                Session["parameterValueOfnameid"] = parameterValueOfnameid;
                Session["parameterValueOfLevel"] = parameterValueOfLevel;
                Session["parameterValueOfMob"] = parameterValueOfMob;

                // Check if the parameter exists
                if (!string.IsNullOrEmpty(parameterValueOfnameid) && !string.IsNullOrEmpty(parameterValueOfLevel) && !string.IsNullOrEmpty(parameterValueOfMob))
                {

                    //lblShowName.Text = Security.Decryption(parameterValueOfnameid).ToUpper();

                }
                else
                {
                    Response.Redirect("~/loginPage/login.aspx");
                }
                PopulateStatesDropDown();
                getdata();
            }


        }


        private void PopulateStatesDropDown()
        {
            // List of states
            List<string> states = new List<string>
            {
                "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh",
                "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jharkhand",
                "Karnataka", "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur",
                "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Punjab",
                "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura",
                "Uttar Pradesh", "Uttarakhand", "West Bengal"
            };

            // Bind the list of states to the DropDownList
            ddlStates.DataSource = states;
            ddlStates.DataBind();

            // Optionally, you can add a default item
            ddlStates.Items.Insert(0, new ListItem("-Select State-", ""));
        }

        public void getdata()
        {

            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_InsertDetails";
            sqlcon.Open();
            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getdata");
                com.Parameters.AddWithValue("@proFname", "");
                com.Parameters.AddWithValue("@proLname", "");
                com.Parameters.AddWithValue("@proDOB", "");
                com.Parameters.AddWithValue("@proEmail", "");
                com.Parameters.AddWithValue("@proMobile", Session["parameterValueOfMob"].ToString());
                com.Parameters.AddWithValue("@proState", "");
                com.Parameters.AddWithValue("@proAddres", "");
                com.Parameters.AddWithValue("@proDOJ", "");
                com.Parameters.AddWithValue("@proUsername", "");
                com.Parameters.AddWithValue("@proPassword", "");
                com.Parameters.AddWithValue("@proLevel", "");
                com.Parameters.AddWithValue("@proStatus", "");
                com.Parameters.AddWithValue("@proCreatedDate", "");
                com.Parameters.AddWithValue("@proLastUpdatedDate", "");
                com.Parameters.AddWithValue("@proLastUpdatedBy", "");


                SqlParameter messageParameter = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                messageParameter.Direction = ParameterDirection.Output;
                com.Parameters.Add(messageParameter);

                SqlDataReader reader = com.ExecuteReader();

                ddlRoles.Enabled = false;
                ddlstatus.Enabled = false;


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtFname.Text = reader["proFname"].ToString();
                        txtLname.Text = reader["proLname"].ToString();
                        txtDob.Text = reader["proDOB"].ToString();
                        txtEmail.Text = reader["proEmail"].ToString();
                        txtPhone.Text = reader["proMobile"].ToString();
                        string state = reader["proState"].ToString();
                        txtAdd.Text = reader["proAddres"].ToString();
                        //txtDOJ.Text = reader["proCreatedDate"].ToString();
                        DateTime dateFromSqlServer = (DateTime)reader["proCreatedDate"];
                        txtDOJ.Text = dateFromSqlServer.ToShortDateString();
                        txtUsername.Text = reader["proUsername"].ToString();
                        string level = reader["proLevel"].ToString();
                        string status = reader["proStatus"].ToString();
                        if (state != "")
                        {
                            ddlStates.SelectedValue = ddlStates.Items.FindByText(state).Value;
                        }
                        else
                        {
                            ddlStates.SelectedValue = ddlStates.Items.FindByText("-Select State-").Value;
                        }
                        if (level != "")
                        {
                            ddlRoles.SelectedValue = ddlRoles.Items.FindByText(level).Value;
                        }
                        else
                        {
                            ddlRoles.SelectedValue = ddlRoles.Items.FindByText("-Select Role-").Value;
                        }
                        if (status != "")
                        {
                            ddlstatus.SelectedValue = ddlstatus.Items.FindByText(status).Value;
                        }
                        else
                        {
                            ddlstatus.SelectedValue = ddlstatus.Items.FindByText("-Select Status-").Value;
                        }



                    }
                }
                else
                {

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

        public void updateData()
        {

            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_InsertDetails";
            sqlcon.Open();
            string dob = txtDob.Text.ToString().Trim();
            /*DateTime dobDateTime;
            string newDate = "";

            // Convert string to DateTime using ParseExact
            if (DateTime.TryParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dobDateTime))
            {
                // Conversion successful, dobDateTime now contains the parsed DateTime value
                Console.WriteLine(dobDateTime); // Output: 5/20/2025 12:00:00 AM
                newDate = dobDateTime.ToString("yyyy-MM-dd");
            }*/

            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "update");
                com.Parameters.AddWithValue("@proFname", txtFname.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proLname", txtLname.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proDOB", dob);
                com.Parameters.AddWithValue("@proEmail", txtEmail.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proMobile", txtPhone.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proState", ddlStates.SelectedItem.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proAddres", txtAdd.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proDOJ", txtDOJ.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proUsername", txtUsername.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proPassword", "");
                com.Parameters.AddWithValue("@proLevel", ddlRoles.SelectedItem.Text.ToString().Trim());
                com.Parameters.AddWithValue("@proStatus", ddlstatus.SelectedItem.Text.ToString().Trim());
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

                int i = com.ExecuteNonQuery();

                if (i != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your Details Successfully Updated');", true);
                    // clear();
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


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //insertData();
                updateData();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}