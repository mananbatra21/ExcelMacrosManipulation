using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using ClosedXML.Excel;
using System.IO;

namespace ExcelMacrosManipulation
{
    public partial class ExcelFunctionality : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrv();
                HideFormUpdated();
            }
        }
        string conStr = "Data Source=(localdb)\\MSSqlLocalDb;Initial Catalog=SignUp;Integrated Security=True";
        public void BindGrv()
        {
            using(SqlConnection con=new SqlConnection(conStr))
            {
                string selectQuerry = "select * from tblEmployee_Details";
                SqlDataAdapter sda=new SqlDataAdapter(selectQuerry,con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    dataGrv.DataSource = dt;
                    dataGrv.DataBind();
                }
                else
                {
                    lblMessage.Text="no data found!!!";
                }
                
            }
        }

        public void DisplayFormUpdate()
        {
            lblEmpCity.Visible = true;
            lblEmpName.Visible = true;
            lblEmpSal.Visible = true;
            txtEmpCity.Visible = true;
            txtEmpName.Visible = true;
            txtEmpSal.Visible = true;
        }

        public void HideFormUpdated()
        {
            lblEmpCity.Visible = false;
            lblEmpName.Visible = false;
            lblEmpSal.Visible = false;
            txtEmpCity.Visible = false;
            txtEmpName.Visible = false;
            txtEmpSal.Visible = false;
        }

        protected void dataGrv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int selectedIndexUpdate;
            int selectedIndexDelete;
            try
            {
                if (e.CommandName == "rowedit")
                {
                    if (lblEmpCity.Visible ==false)
                    {
                        DisplayFormUpdate();
                        lblMessage.Text = "please edit the details and press update button.";
                        selectedIndexUpdate = int.Parse(e.CommandArgument.ToString());
                        lblMessage.Text = selectedIndexUpdate.ToString();
                        SqlConnection con = new SqlConnection(conStr);
                        String st = "select * from tblEmployee_Details where Id=" + selectedIndexUpdate;
                        SqlDataAdapter da = new SqlDataAdapter(st, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DisplayFormUpdate();
                        if (dt.Rows.Count > 0)
                        {
                            txtEmpName.Text = dt.Rows[0][1].ToString();
                            txtEmpCity.Text = dt.Rows[0][2].ToString();
                            txtEmpSal.Text = dt.Rows[0][3].ToString();
                            lblMessage.Text = "Update the Employee details and press the update button.";
                        }
                        else
                        {
                            lblMessage.Text = "row not selected.";
                        }
                    }
                    else
                    {
                        selectedIndexUpdate = int.Parse(e.CommandArgument.ToString());
                        lblMessage.Text = selectedIndexUpdate.ToString();
                        SqlConnection con = new SqlConnection(conStr);
                        String st = "select * from tblEmployee_Details where Id=" + selectedIndexUpdate;
                        SqlDataAdapter da = new SqlDataAdapter(st, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DisplayFormUpdate();
                        if (dt.Rows.Count > 0)
                        {
                            txtEmpName.Text = dt.Rows[0][1].ToString();
                            txtEmpCity.Text = dt.Rows[0][2].ToString();
                            txtEmpSal.Text = dt.Rows[0][3].ToString();
                            lblMessage.Text = "Update the product details and press the update button.";
                        }
                        else
                        {
                            lblMessage.Text = "row not selected.";
                        }
                    }
                    

                }
                if (e.CommandName == "rowdelete")
                {
                    SqlConnection con = new SqlConnection(conStr);
                    con.Open();
                    selectedIndexDelete = int.Parse(e.CommandArgument.ToString());
                    string str = "delete from tblEmployee_Details where Id=" + selectedIndexDelete;
                    SqlCommand sqlcom = new SqlCommand(str, con);
                    sqlcom.ExecuteNonQuery();
                    sqlcom.Dispose();
                    con.Close();

                    BindGrv();
                    con.Dispose();

                    lblMessage.Text = "One row Deleted.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text= ex.Message;
            }
        }

        protected void btnCreateExcel_Click(object sender, EventArgs e)
        {
            
            using(SqlConnection con = new SqlConnection(conStr))
            {
                using(SqlCommand cmd = new SqlCommand("select * from tblEmployee_Details"))
                {
                    using(SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection= con;
                        sda.SelectCommand= cmd;
                        using(DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            using(XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "Employees");
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition","attachment;filename=Employees.xlsx");
                                using(MemoryStream myMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(myMemoryStream);
                                    myMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnAddEmp_Click(object sender, EventArgs e)
        {
            if (lblEmpCity.Visible == false)
            {
                DisplayFormUpdate();
                lblMessage.Text = "please fill the form to add an employee.";
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    string sqlQuerry = "insert into TblEmployee_Details(Name,City,Salary) values('" +
                        txtEmpName.Text + "','" + txtEmpCity.Text + "'," + txtEmpSal.Text + ")";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuerry, conn);
                    cmd.ExecuteNonQuery();
                    BindGrv();
                    conn.Close();
                    lblMessage.Text = "Employee added succesfully.";
                    HideFormUpdated();
                }
            }
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(lblEmpCity.Visible == false)
            {
                DisplayFormUpdate();
                lblMessage.Text = "please select a row to updated by clicking on the edit button on the desired row to be updated.";
            }
            else
            {
                if (txtEmpName.Text != null && txtEmpCity.Text != null && txtEmpSal.Text != null)
                {
                    string SqlQuerry = "update tblEmployee_Details set Name='" + txtEmpName.Text +
                        "',City='" + txtEmpCity.Text + "', Salary=" + txtEmpSal.Text +
                        "where Name='" + txtEmpName.Text + "'";
                    using (SqlConnection conn = new SqlConnection(conStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(SqlQuerry, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        BindGrv();
                        lblMessage.Text = "Selected row updated as specified.";
                        HideFormUpdated();
                    }

                }
                else
                {
                    lblMessage.Text = "please select a row to updated by clicking on the edit button on the desired row to be updated.";
                }
            }
            
        }

        protected void btnBackTOHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmHome.aspx");
        }
    }
}