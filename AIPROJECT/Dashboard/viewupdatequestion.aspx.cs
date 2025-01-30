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
    public partial class viewupdatequestion : System.Web.UI.Page
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
                gvbind();
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
                //int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
                GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
                string lblquescode = ((Label)row.FindControl("lblquescode")).Text;
                Application["lblquescode"] = lblquescode.ToString();
                string lblquestion = ((Label)row.FindControl("lblquestion")).Text;
                string lbloption1 = ((Label)row.FindControl("lbloption1")).Text;
                string lbloption2 = ((Label)row.FindControl("lbloption2")).Text;
                string lbloption3 = ((Label)row.FindControl("lbloption3")).Text;
                string lbloption4 = ((Label)row.FindControl("lbloption4")).Text;
                string lblcorrectans = ((Label)row.FindControl("lblcorrectans")).Text;
                string lblclass = ((Label)row.FindControl("lblClass")).Text;
                string lblSubject = ((Label)row.FindControl("lblSubject")).Text;


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
                ddlsubject.SelectedValue = ddlsubject.Items.FindByText(lblSubject).Value;
                txtQuestion.Text = lblquestion;
                txtopt1.Text = lbloption1;
                txtopt2.Text = lbloption2;
                txtopt3.Text = lbloption3;
                txtopt4.Text = lbloption4;
                txtcorrect.Text = lblcorrectans;


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
                string labelID = ((Label)row.FindControl("lblquescode")).Text;

                conn.Open();
                SqlCommand cmd = new SqlCommand("delete FROM QuestionBank where QuesCode='" + labelID + "'", conn);

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
            string param = "sp_questionbank";
            sqlcon.Open();


            try
            {
                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "getdata");
                com.Parameters.AddWithValue("@QuesCode", "");
                com.Parameters.AddWithValue("@QuestName", "");
                com.Parameters.AddWithValue("@option1", "");
                com.Parameters.AddWithValue("@option2", "");
                com.Parameters.AddWithValue("@option3", "");
                com.Parameters.AddWithValue("@option4", "");
                com.Parameters.AddWithValue("@Correctanw", "");
                com.Parameters.AddWithValue("@Class", "");
                com.Parameters.AddWithValue("@subject", "");
                com.Parameters.AddWithValue("@UpdatedDate", "");



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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updateRecord();
            GridView1.EditIndex = -1;
            clear();
        }
        public void updateRecord()
        {

            string classvalue = "";
            if (ddlclass.SelectedItem.Text == "Class V")
            {
                classvalue = "fifth";
            }
            else if (ddlclass.SelectedItem.Text == "Class VI")
            {
                classvalue = "sixth";
            }
            else if (ddlclass.SelectedItem.Text == "Class VII")
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


            SqlConnection sqlcon = new SqlConnection(CS);
            string param = "sp_questionbank";
            sqlcon.Open();
            try
            {

                SqlCommand com = new SqlCommand(param, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "update");
                com.Parameters.AddWithValue("@QuesCode", Application["lblquescode"].ToString());
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

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your data updated sucessfully');", true);
                    gridArea.Visible = true;

                    formArea.Visible = false;
                    gvbind();

                }
                sqlcon.Close();



                /* SqlCommand cmd = new SqlCommand("update classWiseSubject set title='" + txttitle.Text.ToString().Trim() +
                     "',decription='" + txtdescription.Text.ToString().Trim() +
                     "',videolink='" + txtvideolink.Text.ToString().Trim() + "',class='" + selectedClass.ToString().Trim() +
                     "',subject='" + ddlsubject.SelectedItem.Text.ToString().Trim() + "' where srno='" + Convert.ToInt32(Application["txtSrno"].ToString()) + "'", sqlcon);

                 int i = cmd.ExecuteNonQuery();
                 if (i != 0)
                 {

                     ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your data updated sucessfully');", true);
                     gridArea.Visible = true;
                     addcontent.Visible = true;
                     formArea.Visible = false;
                     gvbind();

                 }
                 sqlcon.Close();*/


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
            txtQuestion.Text = "";
            txtopt1.Text = "";
            txtopt2.Text = "";
            txtopt3.Text = "";
            txtopt4.Text = "";
            txtcorrect.Text = "";
            ddlsubject.SelectedValue = ddlsubject.Items.FindByText("-Select Subject-").Value;
            ddlclass.SelectedValue = ddlclass.Items.FindByText("-Select Class-").Value;
        }
    }
}