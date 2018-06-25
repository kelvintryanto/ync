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
using System.Data;
//using System.Data.DataSetExtensions;

namespace OnlineRegistration_v2.Admin
{
    public partial class ListUmat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //boundDropDown();
                //boundListData("");
                boundListData("");
            } 
        }

        protected void boundDropDown()
        {
            //DBClass dbclass = new DBClass();



            //dropdownCustomerType.DataSource = dbclass.SelectAllCustomerType();
            //dropdownCustomerType.DataTextField = "CustomerType_Name";
            //dropdownCustomerType.DataValueField = "CustomerType_ID";
            //dropdownCustomerType.DataBind();

            ////dropdownCustomerStatus.DataSource = dbclass.SelectAllCustomer();
            ////dropdownCustomerStatus.DataTextField = "";
            ////dropdownCustomerStatus.DataValueField = "CustomerStatusCode";
            ////dropdownCustomerStatus.DataBind();


            //dropdownPhoneIs.DataSource = dbclass.SelectAllCallStatusByParentID(null);
            //dropdownPhoneIs.DataTextField = "CallStatus_Name";
            //dropdownPhoneIs.DataValueField = "CallStatus_ID";
            //dropdownPhoneIs.DataBind();
            //dropdownPhoneIs.Items.Insert(0, new ListItem("- select -", "0"));

            //dropdownPhoneIs.SelectedIndex = 0;
            //boundDropDownCaseCategory1(Convert.ToInt32(dropdownPhoneIs.SelectedValue));
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            boundListData(txt_search.Text);
        }

        protected void boundListData(String searchvalue)
        //protected void boundListData()
        {
            DataTable listpeserta = GetDataPeserta();

            if (searchvalue == "")
                gvw_listData.DataSource = listpeserta;
            else
                gvw_listData.DataSource = listpeserta.AsEnumerable()
                            .Where(x => x.Field<string>("TicketNumber").ToUpper().Contains(searchvalue.ToUpper()) || x.Field<string>("FullName").ToUpper().Contains(searchvalue.ToUpper()))
                            .CopyToDataTable();
                //gvw_listData.DataSource = customers.FindAll(x => x.Customer_Name.ToUpper().Contains(searchvalue.ToUpper()) || x.BoltNumber.Contains(searchvalue));

            gvw_listData.DataBind();

            //DBClass dbclass = new DBClass();

            //WindowsPrincipal wp = (WindowsPrincipal)Thread.CurrentPrincipal;
            //Int32 SystemUser_ID = 0;
            //if (wp != null)
            //{
            //    List<select_SystemUser_Result> systemusers = dbclass.SelectSystemUserByADUserName(wp.Identity.Name);
            //    if (systemusers.Count > 0)
            //        SystemUser_ID = systemusers[0].SystemUser_ID;
            //}


            //if (Page.RouteData.Values["Customer_Type"] != null)
            //    dropdownCustomerType.SelectedValue = Page.RouteData.Values["Customer_Type"].ToString();
            ////List<select_CustomerByType_Result> customers = dbclass.SelectAllCustomerByType(Convert.ToInt32(dropdownCustomerType.SelectedValue), 0);
            //List<select_CustomerByType_Result> customers = dbclass.SelectAllCustomerByType(Convert.ToInt32(dropdownCustomerType.SelectedValue), Convert.ToInt32(dropdownCustomerStatus.SelectedValue), SystemUser_ID);
            //DateTime today = DateTime.Today;

            //customers = customers.FindAll(x => x.FollowUpDate.Equals(DateTime.Today));


            ////String lastcallstatus = DataBinder.Eval(gridviewrow.DataItem, "Customer_ID");

            //if (searchvalue == "")
            //    gvw_listData.DataSource = customers;
            //else
            //    gvw_listData.DataSource = customers.FindAll(x => x.Customer_Name.ToUpper().Contains(searchvalue.ToUpper()) || x.BoltNumber.Contains(searchvalue));

            //gvw_listData.DataBind();
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
            //cmd.Parameters.AddWithValue("@SearchInput", _searchvalue);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();

            return dt;
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text == "Done")
                {
                    ((Button)e.Row.FindControl("Button1")).Visible = false;
                }

            }
        }

        protected void gvw_listData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ProceedButton")
            {
                //GridViewRow gridviewrow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                ////DropDownList ddl = (DropDownList)gridviewrow.FindControl("DropDownList1");

                //DBClass dbclass = new DBClass();

                //Int32 Customer_ID = (Int32)gvw_listData.DataKeys[gridviewrow.RowIndex].Value;
                ////Int32 Customer_ID = Convert.ToInt32(DataBinder.Eval(gridviewrow.DataItem, "Customer_ID"));
                ////Int32 result = dbclass.UpdateCustomerStatus(Customer_ID, Convert.ToInt32(ddl.SelectedValue));
                //customer_id.Value = Customer_ID.ToString();
                ////if (ddl.SelectedItem.Text.ToUpper() == "ANSWER")
                ////  Response.Redirect("First2Days/" + Customer_ID.ToString());
                ////else
                //// boundListData("");

                ////bindPhoneIs();
                ////bindCategory1();
                ////Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "$(#CallStatusModal).modal('show');", true);

                //category1.Visible = false;
                //category2.Visible = false;
                //category3.Visible = false;
                //followup.Visible = false;
                //callstatus.Visible = false;

            }

        }



        

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            //boundListData(txt_search.Text);
        }
    

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            //if (dropdownPhoneIs.SelectedValue == "1" && dropdownCallCategory1.SelectedValue == "4")
            //{
            //    if (dropdownCustomerType.SelectedValue == "1")
            //    {
            //        Response.RedirectToRoute("55D", new { Customer_ID = customer_id.Value, Customer_Type = dropdownCustomerType.SelectedValue, PhoneIs = dropdownPhoneIs.SelectedValue, Category1 = dropdownCallCategory1.SelectedValue });
            //    }
            //    else if (dropdownCustomerType.SelectedValue == "2")
            //    {
            //        Response.RedirectToRoute("CampaignA", new { Customer_ID = customer_id.Value, Customer_Type = dropdownCustomerType.SelectedValue, PhoneIs = dropdownPhoneIs.SelectedValue, Category1 = dropdownCallCategory1.SelectedValue });
            //    }
            //    else if (dropdownCustomerType.SelectedValue == "3")
            //    {
            //        Response.RedirectToRoute("CampaignB", new { Customer_ID = customer_id.Value, Customer_Type = dropdownCustomerType.SelectedValue, PhoneIs = dropdownPhoneIs.SelectedValue, Category1 = dropdownCallCategory1.SelectedValue });
            //    }
            //    else if (dropdownCustomerType.SelectedValue == "4")
            //    {
            //        Response.RedirectToRoute("CampaignC", new { Customer_ID = customer_id.Value, Customer_Type = dropdownCustomerType.SelectedValue, PhoneIs = dropdownPhoneIs.SelectedValue, Category1 = dropdownCallCategory1.SelectedValue });
            //    }
            //}
            //else
            //{
            //    //DBClass dbclass = new DBClass();

            //    //DateTime outboundresponsedatetime = System.DateTime.Now;
            //    //select_SystemUser_Result x = dbclass.SelectSystemUserByADUserName(User.Identity.Name).FirstOrDefault();
            //    //Int32 agentid = x.SystemUser_ID;
            //    //Int32 customerid = Convert.ToInt32(customer_id.Value);
            //    //Int32 packetdbid = Convert.ToInt32(dropdownCustomerType.SelectedValue);

            //    //String phoneis = Convert.ToString(dropdownPhoneIs.SelectedItem);
            //    //String category1 = Convert.ToString(dropdownCallCategory1.SelectedItem);
            //    //String category2 = Convert.ToString(dropdownCallCategory2.SelectedItem);
            //    //String category3 = Convert.ToString(dropdownCallCategory3.SelectedItem);
            //    //String followup = Convert.ToString(dropdownFollowUp.SelectedItem);
            //    //String lastcallstatus = Convert.ToString(dropdownCallStatus.SelectedItem);

            //    //OutboundResponse request = new OutboundResponse();
            //    //request.OutboundResponseDateTime = outboundresponsedatetime;
            //    //request.Agent_ID = agentid;
            //    //request.Customer_ID = customerid;
            //    //request.CallAttempt = 1;
            //    //request.PhoneIs = phoneis;
            //    //request.Category1 = category1;
            //    //request.Category2 = category2;
            //    //request.Category3 = category3;
            //    //request.FollowUp = followup;

            //    //request.PacketDB_ID = packetdbid;
            //    //request.LastCallStatus = lastcallstatus;

            //    //List<select_CustomerByID_Result> customers = dbclass.SelectAllCustomerByID(customerid);
            //    //if (customers.Count > 0)
            //    //    request.ActivationDate = customers[0].ActivationDate;

            //    //List<select_OutboundResponse_Result> responses = dbclass.SelectOutboundResponse(customerid);
            //    //if (responses.Count > 0)
            //    //{
            //    //    request.OutboundResponse_ID = responses[0].OutboundResponse_ID;
            //    //    Int32 result = dbclass.UpdateOutboundResponse(request);

            //    //    //select_OutboundResponse_Result sor = dbclass.SelectOutboundResponse(customerid).FirstOrDefault();
            //    //    //Int32 callAttempt = Convert.ToInt32(sor.CallAttempt);
            //    //    //if (callAttempt == 3)
            //    //    //{
            //    //    //    dbclass.UpdateCustomerStatus(Convert.ToInt32(customer_id.Value), 36);
            //    //    //}
            //    //}
            //    //else
            //    //{
            //    //    Int32 result = dbclass.InsertOutboundResponse(request);
            //    //}

            //    //dbclass.UpdateCustomerStatus(Convert.ToInt32(customer_id.Value), Convert.ToInt32(dropdownCallStatus.SelectedValue));
            //    //Page.RouteData.Values["Customer_Type"] = null;
            //    //boundListData("");
            //    ////Response.RedirectToRoute("CustomerLists");
            //}

        }

        protected void dropdownCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.RouteData.Values["Customer_Type"] = null;
            //boundListData("");
        }

        protected void dropdownCustomerStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.RouteData.Values["Customer_Type"] = null;
            //boundListData("");
        }
    }
}