using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Security.Principal;
using System.Threading;
using ExtensionMethods;
//using System.Data.DataSetExtensions;

namespace OnlineRegistration_v2.Admin
{
    public partial class ListUmat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                boundListData("");
            } 
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            boundListData(txt_search.Text);
        }

        protected void boundListData(String searchvalue)
        {
            DataTable listpesertahasilsearch = new DataTable();

            DataTable listpeserta = GetDataPeserta();

            bool exists = (listpeserta.AsEnumerable()
                            .Where(x => x.Field<string>("TicketNumber").ToUpper().Contains(searchvalue.ToUpper()) || x.Field<string>("FullName").ToUpper().Contains(searchvalue.ToUpper())))
                            .Any();

            if (searchvalue == "")
            {
                gvw_listData.Visible = true;
                lbl_searchresult.Visible = false;
                gvw_listData.DataSource = listpeserta;
                gvw_listData.DataBind();
            }
            else
            {
                if (exists)
                {
                    gvw_listData.Visible = true;
                    lbl_searchresult.Visible = false;

                    listpesertahasilsearch = listpeserta.AsEnumerable()
                                .Where(x => x.Field<string>("TicketNumber").ToUpper().Contains(searchvalue.ToUpper()) || x.Field<string>("FullName").ToUpper().Contains(searchvalue.ToUpper()))
                                .CopyToDataTable();

                    gvw_listData.DataSource = listpesertahasilsearch;
                    gvw_listData.DataBind();
                }
                else
                {
                    gvw_listData.Visible = false;
                    lbl_searchresult.Visible = true;
                }
            }
                

            //DataSet studentsList = students.GetAllStudents();
            //bool empty = IsEmpty(studentsList); // check DataSet here, see the link above
            //if (empty)
            //{
            //    GridView1.Visible = false;
            //}
            //else
            //{
            //    GridView1.DataSource = studentsList;
            //    GridView1.DataBind();
            //}
        }


        

        #region Private Function
        private static String ConnString()
        {
            return ConfigurationManager.ConnectionStrings["YnCDB_Connection"].ToString();
        }

        private static DataTable GetDataPeserta()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(ConnString());
            SqlCommand cmd = new SqlCommand("usp_Registration_GetAllDataPeserta", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@IsComing", _isComing);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();

            return dt;
        }

        private static Int32 doUpdateKehadiranPeserta(Int32 _umatID)
        {
            SqlConnection conn = new SqlConnection(ConnString());
            SqlCommand cmd = new SqlCommand("usp_UpdateStatusPeserta", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@umatID", _umatID);

            SqlParameter returnparameter = new SqlParameter("@returnvalue", SqlDbType.Int);
            returnparameter.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnparameter);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Int32 returnvalue = (Int32)returnparameter.Value;

            return returnvalue;
        }

        #endregion

        

        protected void gvw_listData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvw_listData.PageIndex = e.NewPageIndex;
            Page.RouteData.Values["Customer_Type"] = null;
            boundListData("");
        }

        protected void gvw_listData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.Cells[5].Text == "Done")
            //    {
            //        ((Button)e.Row.FindControl("Button1")).Visible = false;
            //    }

            //}
        }

        protected void gvw_listData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "ProceedButton")
            //{
            //    GridViewRow gridviewrow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
            //    Int32 Customer_ID = (Int32)gvw_listData.DataKeys[gridviewrow.RowIndex].Value;
            //    customer_id.Value = Customer_ID.ToString();
            //}

        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            //boundListData(txt_search.Text);
        }

        protected void lnkSelect_Click(object sender, EventArgs e)
        {
            int umatID = Convert.ToInt32((sender as LinkButton).CommandArgument);

            try
            {
                Int32 returnvalue = doUpdateKehadiranPeserta(umatID);

                Response.Redirect("~/Admin/ListUmat.aspx", false);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Proses gagal! Silakan coba kembali!')", true);
            }
        }
    }

}