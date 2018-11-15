<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListUmat.aspx.cs" Inherits="OnlineRegistration_v2.Admin.ListUmat" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>List Peserta Rejoice</h1>

    <form id="form1" runat="server">

        <div class="form-horizontal">
            <div class="form-group">
                <div class="col-md-6">
                    <div class="input-group" style="position: static">
                        <asp:TextBox ID="txt_search" runat="server" CssClass="form-control" placeholder="Search by Ticket Number/Nama Lengkap" OnTextChanged="txt_search_TextChanged" Width="500px"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btn_search" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btn_search_Click" />
                        </span>
                    </div>
                </div>
            </div>
        </div>

        <br />
        <br />

        <asp:Label ID="lbl_searchresult" runat="server" Text="Data yang anda cari tidak ditemukan!" Visible="false"></asp:Label>
        <asp:GridView ID="gvw_listData" runat="server" CssClass="table table-hover table-bordered" AutoGenerateColumns="False" DataKeyNames="ID"
            AllowPaging="True" OnPageIndexChanging="gvw_listData_PageIndexChanging" OnRowDataBound="gvw_listData_RowDataBound"
            PagerStyle-CssClass="pagination-ys" PagerStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" OnRowCommand="gvw_listData_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text="<%# (Container.DataItemIndex + 1).ToString() %>"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="Customer ID" Visible="False" />
                <asp:BoundField DataField="TicketNumber" HeaderText="Ticket Number">
                    <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="FullName" HeaderText="Nama Lengkap" />
                <asp:BoundField DataField="MobilePhone" HeaderText="Nomor HP" />
                <asp:BoundField DataField="LineID" HeaderText="Line ID" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <div class="input-group" style="position: inherit">
                            <asp:LinkButton ID="lnkSelect" Text="Hadir!" runat="server" CssClass="btn-Hadir" CommandArgument='<%# Eval("ID") %>' OnClick="lnkSelect_Click" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings PageButtonCount="25" Position="TopAndBottom" />
            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Left" />
            <RowStyle VerticalAlign="Middle" />
        </asp:GridView>

    </form>
</body>
</html>
