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
    public partial class viewupdatesubjectcontent : System.Web.UI.Page
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
                try
                {
                    gvbind();


                    parameterValueOfnameid = HttpContext.Current.Request.QueryString["nameid"];
                    parameterValueOfLevel = HttpContext.Current.Request.QueryString["level"];
                    parameterValueOfMob = HttpContext.Current.Request.QueryString["mob"];

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
                        //welcomeName.Text = parameterValueOfnameid.ToUpper();
                        //showAccess(parameterValueOfLevel);
                        //lblShowName.Text = Security.Decryption(parameterValueOfnameid).ToUpper();

                    }
                    else
                    {
                        Response.Redirect("~/loginPage/login.aspx");
                    }

                }
                catch (Exception ex)
                {
                    Response.Redirect("~/loginPage/login.aspx");
                }
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {

                GridView1.EditIndex = -1;
                gvbind();
            }
            catch (Exception ex)
            { }
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
                GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
                string txtSrno = ((Label)row.FindControl("Label12")).Text;
                Application["txtSrno"] = txtSrno.ToString();
                string lblclass = ((Label)row.FindControl("lblclass")).Text;
                string lblsubject = ((Label)row.FindControl("lblsubject")).Text;
                string lbltitle = ((Label)row.FindControl("lbltitle")).Text;
                string lbldescritption = ((Label)row.FindControl("lbldescritption")).Text;
                string lblvideolink = ((Label)row.FindControl("lblvideolink")).Text;
                //GridView1.EditIndex = -1;
                gridArea.Visible = false;

                formArea.Visible = true;
                btnUpdate.Visible = true;

                if (lblclass == "fifth")
                {
                    lblclass = "Class V";
                }
                else if (lblclass == "sixth")
                {
                    lblclass = "Class VI";
                }
                else if (lblclass == "seventh")
                {
                    lblclass = "Class VII";
                }
                else if (lblclass == "eighth")
                {
                    lblclass = "Class VIII";
                }
                else if (lblclass == "nineth")
                {
                    lblclass = "Class IX";
                }
                else if (lblclass == "tenth")
                {
                    lblclass = "Class X";
                }
                ddlclass.SelectedValue = ddlclass.Items.FindByText(lblclass).Value;
                ddlsubject.SelectedValue = ddlsubject.Items.FindByText(lblsubject).Value;

                txtdescription.Text = lbldescritption;
                txttitle.Text = lbltitle;
                txtvideolink.Text = lblvideolink;
            }
            catch (Exception ex)
            { }

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                GridView1.PageIndex = e.NewPageIndex;
                gvbind();
            }
            catch (Exception ex)
            { }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection(CS);
                GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
                string labelID = ((Label)row.FindControl("Label12")).Text;

                conn.Open();
                SqlCommand cmd = new SqlCommand("delete FROM classWiseSubject where srno='" + Convert.ToInt32(labelID) + "'", conn);

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
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = e.NewEditIndex;
                gvbind();
            }
            catch (Exception ex)
            { }
        }
        protected void gvbind()
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_subjectdata";
            sqlcon.Open();


            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getdata".ToString().Trim());
                com.Parameters.AddWithValue("@class", "");
                com.Parameters.AddWithValue("@subject", "");
                com.Parameters.AddWithValue("@subjectcode", "");
                com.Parameters.AddWithValue("@title", "");
                com.Parameters.AddWithValue("@decription", "");
                com.Parameters.AddWithValue("@videolink", "");
                com.Parameters.AddWithValue("@createdOn", "");
                com.Parameters.AddWithValue("@lastupdatedon", "");



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



        public void updateRecord()
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
                /*com.CommandType = CommandType.StoredProcedure;
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

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Updated Sucessfully');", true);

                    clear();
                    //gvbind();
                }*/



                SqlCommand cmd = new SqlCommand("update classWiseSubject set title='" + txttitle.Text.ToString().Trim() +
                    "',decription='" + txtdescription.Text.ToString().Trim() +
                    "',subjectcode='" + subjectCode.ToString().Trim() +
                    "',videolink='" + txtvideolink.Text.ToString().Trim() + "',class='" + selectedClass.ToString().Trim() +
                    "',subject='" + ddlsubject.SelectedItem.Text.ToString().Trim() + "' where srno='" + Convert.ToInt32(Application["txtSrno"].ToString()) + "'", sqlcon);

                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your data updated sucessfully');", true);
                    gridArea.Visible = true;

                    formArea.Visible = false;
                    gvbind();

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


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updateRecord();
            GridView1.EditIndex = -1;
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