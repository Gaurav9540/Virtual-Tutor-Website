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
    public partial class addsubjectcontent : System.Web.UI.Page
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

                //remove once it will donw as dynmic
                /* parameterValueOfnameid = "abcd";
                 parameterValueOfLevel = "admin";
                 parameterValueOfMob = "7893214566";*/

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

        public void insertRecord()
        {
            string subjectCode = "";
            string selectedClass = "";
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class V" && ddlsubject.SelectedItem.Text.ToString().Trim() == "English")
            {
                selectedClass = "fifth";
                subjectCode = "51";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class V" && ddlsubject.SelectedItem.Text.ToString().Trim() == "EVS")
            {
                selectedClass = "fifth";
                subjectCode = "52";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class V" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Mathematics")
            {
                selectedClass = "fifth";
                subjectCode = "53";
            }

            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class VI" && ddlsubject.SelectedItem.Text.ToString().Trim() == "English")
            {
                selectedClass = "sixth";
                subjectCode = "61";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class VI" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Science")
            {
                selectedClass = "sixth";
                subjectCode = "62";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class VI" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Mathematics")
            {
                selectedClass = "sixth";
                subjectCode = "63";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class VI" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Social Science")
            {
                selectedClass = "sixth";
                subjectCode = "64";
            }

            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class VII" && ddlsubject.SelectedItem.Text.ToString().Trim() == "English")
            {
                selectedClass = "seventh";
                subjectCode = "71";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class VII" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Science")
            {
                selectedClass = "seventh";
                subjectCode = "72";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class VII" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Mathematics")
            {
                selectedClass = "seventh";
                subjectCode = "73";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class VII" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Social Science")
            {
                selectedClass = "seventh";
                subjectCode = "74";
            }

            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class VIII" && ddlsubject.SelectedItem.Text.ToString().Trim() == "English")
            {
                selectedClass = "eighth";
                subjectCode = "81";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class VIII" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Science")
            {
                selectedClass = "eighth";
                subjectCode = "82";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class VIII" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Mathematics")
            {
                selectedClass = "eighth";
                subjectCode = "83";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class VIII" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Social Science")
            {
                selectedClass = "eighth";
                subjectCode = "84";
            }

            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class IX" && ddlsubject.SelectedItem.Text.ToString().Trim() == "English")
            {
                selectedClass = "nineth";
                subjectCode = "91";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class IX" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Science")
            {
                selectedClass = "nineth";
                subjectCode = "92";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class IX" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Mathematics")
            {
                selectedClass = "nineth";
                subjectCode = "93";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class IX" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Social Science")
            {
                selectedClass = "nineth";
                subjectCode = "94";
            }


            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class X" && ddlsubject.SelectedItem.Text.ToString().Trim() == "English")
            {
                selectedClass = "tenth";
                subjectCode = "101";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class X" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Science")
            {
                selectedClass = "tenth";
                subjectCode = "102";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class X" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Mathematics")
            {
                selectedClass = "tenth";
                subjectCode = "103";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class X" && ddlsubject.SelectedItem.Text.ToString().Trim() == "Social Science")
            {
                selectedClass = "tenth";
                subjectCode = "104";
            }
            if (ddlclass.SelectedItem.Text.ToString().Trim() == "Class X" && ddlsubject.SelectedItem.Text.ToString().Trim() == "ICT")
            {
                selectedClass = "tenth";
                subjectCode = "105";
            }

            //Below we need to add more like same as above

            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_subjectdata";
            sqlcon.Open();
            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "insert");
                com.Parameters.AddWithValue("@class", selectedClass.ToString().Trim());
                com.Parameters.AddWithValue("@subject", ddlsubject.SelectedItem.Text.ToString().Trim());
                com.Parameters.AddWithValue("@subjectcode", subjectCode);
                com.Parameters.AddWithValue("@title", txttitle.Text.ToString().Trim());
                com.Parameters.AddWithValue("@decription", txtdescription.Text.ToString().Trim());
                com.Parameters.AddWithValue("@videolink", txtvideolink.Text.ToString().Trim());
                com.Parameters.AddWithValue("@createdOn", "");
                com.Parameters.AddWithValue("@lastupdatedon", "");

                int i = com.ExecuteNonQuery();
                if (i != 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Added Sucessfully');", true);

                    clear();
                    //gvbind();
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

        protected void addcontent_Click(object sender, EventArgs e)
        {
            insertRecord();
            clear();
        }

        public void clear()
        {
            // txtAttendanceDate.Text = "";
            ddlsubject.SelectedValue = ddlsubject.Items.FindByText("-Select Subject-").Value;
            ddlclass.SelectedValue = ddlclass.Items.FindByText("-Select Class-").Value;
            txtdescription.Text = "";
            txttitle.Text = "";
            txtvideolink.Text = "";
        }
    }
}