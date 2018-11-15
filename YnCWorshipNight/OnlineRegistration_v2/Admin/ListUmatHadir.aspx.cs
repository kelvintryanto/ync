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

namespace OnlineRegistration_v2.Admin
{
    public partial class ListUmatHadir : System.Web.UI.Page
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
            DataTable listpeserta = GetDataPesertaHadir();

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


            //DataTable listpeserta = GetDataPesertaHadir();

            //if (searchvalue == "")
            //    gvw_listData.DataSource = listpeserta;
            //else
            //    gvw_listData.DataSource = listpeserta.AsEnumerable()
            //                .Where(x => x.Field<string>("TicketNumber").ToUpper().Contains(searchvalue.ToUpper()) || x.Field<string>("FullName").ToUpper().Contains(searchvalue.ToUpper()))
            //                .CopyToDataTable();

            //gvw_listData.DataBind();
        }

        #region Private Function
        private static String ConnString()
        {
            return ConfigurationManager.ConnectionStrings["YnCDB_Connection"].ToString();
        }

        private static DataTable GetDataPesertaHadir()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(ConnString());
            SqlCommand cmd = new SqlCommand("usp_Registration_GetDataPesertaHadir", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();

            return dt;
        }

        #endregion

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            boundListData(txt_search.Text);
        }

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
    }
}