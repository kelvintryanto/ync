<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListUmat.aspx.cs" Inherits="OnlineRegistration_v2.Admin.ListUmat" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>List Peserta YnC Worship Night</h1>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">       
        <ContentTemplate>
            <div class="form-horizontal">
                    <div class="form-group">                                                            
                        <div class="col-md-6">
                            <div class="input-group" style="position: static">
                                <asp:TextBox ID="txt_search" runat="server" CssClass="form-control" placeholder="Search by Ticket Number/Nama Lengkap" OnTextChanged="txt_search_TextChanged"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:Button ID="btn_search" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btn_search_Click" />
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">                                                            
                        <div class="col-md-9">
                            <div class="col-sm-5">
                                 <label style="text-align: left; padding-left: 8px">Kehadiran Peserta:</label>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="dropdownCustomerStatus" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropdownCustomerStatus_SelectedIndexChanged">
                                    <asp:ListItem Text="Not Coming" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Coming" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
            </div>
            <asp:GridView ID="gvw_listData" runat="server" CssClass="table table-hover table-bordered" AutoGenerateColumns="False" DataKeyNames="ID"
                AllowPaging="True" OnPageIndexChanging="gvw_listData_PageIndexChanging" OnRowDataBound="gvw_listData_RowDataBound"
                PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" OnRowCommand="gvw_listData_RowCommand" >                
                <Columns>
                    <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text="<%# (Container.DataItemIndex + 1).ToString() %>"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="TicketNumber" HeaderText="Ticket Number">
                        <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FullName" HeaderText="Nama Lengkap"/>
                    <asp:BoundField DataField="MobilePhone" HeaderText="Nomor HP"  />                        
                    <asp:BoundField DataField="Email" HeaderText="Email"  />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>                                                                    
                            <div class="input-group" style="position:inherit">
                                <!--<asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                </asp:DropDownList>-->
                                <span class="input-group-btn">
                                    <!-- Button trigger modal -->
                                    <asp:Button ID="Button1" runat="server" Text="HADIR!" CssClass="btn btn-primary" CommandName="ProceedButton" data-toggle="modal" data-target="#myModal" />
                                </span>
                            </div>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                </Columns>
                <PagerSettings PageButtonCount="25" Position="TopAndBottom" />
                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Left" />
                <RowStyle VerticalAlign="Middle" />
            </asp:GridView>                
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Modal -->
    <!-- The Modal -->
    <div class="modal fade" id="myModal">
        <div class="modal-dialog">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Modal Heading</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    Modal body..
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>

            </div>
        </div>
    </div>


</asp:Content>