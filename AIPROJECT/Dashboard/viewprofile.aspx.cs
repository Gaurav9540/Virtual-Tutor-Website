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
using System.Xml.Linq;

namespace HR_Web_Application
{
    public partial class viewprofile : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
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


                PopulateMobileNumbersDropDown();
                gvbind();
            }


        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection(CS);
                GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
                string labelID = ((Label)row.FindControl("Label12")).Text;

                conn.Open();
                SqlCommand cmd = new SqlCommand("delete FROM tbl_profile where proID='" + Convert.ToInt32(labelID) + "'", conn);

                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your Data is Deleted sucessfully');", true);

                }
                conn.Close();
                gvbind();
            }
            catch (Exception ex)
            { }
        }

        private void PopulateMobileNumbersDropDown()
        {

            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_InsertDetails";
            sqlcon.Open();
            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getmobiledata");
                com.Parameters.AddWithValue("@proFname", "");
                com.Parameters.AddWithValue("@proLname", "");
                com.Parameters.AddWithValue("@proDOB", "");
                com.Parameters.AddWithValue("@proEmail", "");
                com.Parameters.AddWithValue("@proMobile", "");
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

                //   SqlDataReader reader = com.ExecuteReader();

                using (SqlDataReader reader = com.ExecuteReader())
                {
                    List<string> mobileNumbers = new List<string>();

                    while (reader.Read())
                    {
                        string mobileNumber = reader["proMobile"].ToString(); // Replace MobileNumberColumn with actual column name
                        mobileNumbers.Add(mobileNumber);
                    }

                    // Bind the list of mobile numbers to the DropDownList
                    ddlMobileNumber.DataSource = mobileNumbers;
                    ddlMobileNumber.DataBind();

                    // Optionally, you can add a default item
                    ddlMobileNumber.Items.Insert(0, new ListItem("-Select Mobile Number-", ""));

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

        protected void gvbind()
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_InsertDetails";
            sqlcon.Open();


            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getgriddata");
                com.Parameters.AddWithValue("@proFname", "");
                com.Parameters.AddWithValue("@proLname", "");
                com.Parameters.AddWithValue("@proDOB", "");
                com.Parameters.AddWithValue("@proEmail", "");
                com.Parameters.AddWithValue("@proMobile", "");
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

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                sqlcon.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    GridView1.Rows[0].Cells.Clear();
                    GridView1.Rows[0].Cells.Add(new TableCell());
                    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                    GridView1.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            catch (Exception ex)
            {

                sqlcon.Close();
                Response.Write(ex.ToString());

            }
        }

        public void getGridDataByMobile()
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_InsertDetails";
            sqlcon.Open();
            string mobileNumber = "";
            string action = "";
            if (ddlMobileNumber.SelectedItem.Text.ToString().Trim() == "-Select Mobile Number-")
            {
                mobileNumber = "";
                action = "getgriddata";
            }
            else
            {
                mobileNumber = ddlMobileNumber.SelectedItem.Text.ToString().Trim();
                action = "getdata";
            }

            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", action);
                com.Parameters.AddWithValue("@proFname", "");
                com.Parameters.AddWithValue("@proLname", "");
                com.Parameters.AddWithValue("@proDOB", "");
                com.Parameters.AddWithValue("@proEmail", "");
                com.Parameters.AddWithValue("@proMobile", mobileNumber.ToString());
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

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                sqlcon.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    GridView1.Rows[0].Cells.Clear();
                    GridView1.Rows[0].Cells.Add(new TableCell());
                    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                    GridView1.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            catch (Exception ex)
            {

                sqlcon.Close();
                Response.Write(ex.ToString());

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //insertData();
                getGridDataByMobile();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}