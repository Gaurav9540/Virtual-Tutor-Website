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
    public partial class viewquestion : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        public static string empid = "";
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
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