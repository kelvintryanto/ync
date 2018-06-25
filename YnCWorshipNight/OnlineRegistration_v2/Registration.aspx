<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="OnlineRegistration_v2.Registration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%--<hgroup class="title">
        <h1>Youth in Christ Worship Night</h1>
        <h2>ONLINE REGISTRATION</h2>
    </hgroup>--%>

    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           <%-- Start Logo Column 1 Left--%>
	       <div class="column left">
               <h1>Try This Box</h1>
	       </div>

            <%-- Start Column 2 Right --%>
           <div class="column right">
		        <%-- Start Form Horizontal--%>
		        <div class="form-horizontal">
			        <%-- Nama Lengkap --%>
			        <div class="form-group">
				        <div class="col-md-3">
					        <asp:Label runat="server">Nama Lengkap</asp:Label>
				        </div>
				        <div class="col-md-5">
					        <asp:TextBox runat="server" ID="txtFullname" />
					        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFullname"
					        CssClass="field-validation-error" ErrorMessage="Nama Lengkap wajib diisi!" />
				        </div>
			        </div>

			        <%-- Tanggal Lahir --%>
			        <div class="form-group">
				        <div class="col-md-3">
					        <asp:Label runat="server">Tanggal Lahir</asp:Label>
				        </div>
				        <div class="col-md-5">
					        <asp:TextBox runat="server" ID="txtDOB" />
					        <asp:CalendarExtender ID="txt_CalendarExtender" runat="server"
					        TargetControlID="txtDOB" Format="dd MMMM yyyy"></asp:CalendarExtender>
					        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDOB"
					        CssClass="field-validation-error" ErrorMessage="Tanggal lahir wajib diisi!" />
				        </div>
			        </div>

			        <%-- Nomor HP --%>
			        <div class="form-group">
				        <div class="col-md-3">
					        <asp:Label runat="server">Nomor HP</asp:Label>
				        </div>
				        <div class="col-md-5">
					        <asp:TextBox runat="server" ID="txtMobilePhone" />
					        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMobilePhone"
					        CssClass="field-validation-error" ErrorMessage="Nomor HP wajib diisi!" />
				        </div>
			        </div>

			        <%-- Email --%>
			        <div class="form-group">
				        <div class="col-md-3">
					        <asp:Label runat="server">Email</asp:Label>
				        </div>
				        <div class="col-md-5">
					        <asp:TextBox runat="server" ID="txtEmailAddress" TextMode="Email" />
					        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailAddress"
					        CssClass="field-validation-error" ErrorMessage="Email wajib diisi!" />
				        </div>
			        </div>

			        <%-- Alamat --%>
			        <div class="form-group">
				        <div class="col-md-3">
					        <asp:Label runat="server">Alamat</asp:Label>
				        </div>
				        <div class="col-md-5">
					        <asp:TextBox runat="server" ID="txtHomeAddress" />
					        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtHomeAddress"
					        CssClass="field-validation-error" ErrorMessage="Alamat wajib diisi!" />
				        </div>
			        </div>

			        <%-- Line ID --%>
			        <div class="form-group">
				        <div class="col-md-3">
					        <asp:Label runat="server">Line ID</asp:Label>
				        </div>
				        <div class="col-md-5">
					        <asp:TextBox runat="server" ID="txtLineID" />
					        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLineID"
					        CssClass="field-validation-error" ErrorMessage="Line ID wajib diisi!" />
				        </div>
			        </div>

			        <%-- Gender --%>
			        <div class="form-group">
				        <div class="col-md-3">
					        <asp:Label runat="server">Gender</asp:Label>
				        </div>
				        <div class="col-md-5">
					        <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="True">
					            <asp:ListItem Text="Male" Value="0"></asp:ListItem>
					            <asp:ListItem Text="Female" Value="1"></asp:ListItem>
				            </asp:DropDownList>
			            </div>
		            </div>

		            <%-- Asal Paroki --%>
		            <div class="form-group">
			            <div class="col-md-3">
				            <asp:Label runat="server">Asal Paroki</asp:Label>
			            </div>
			            <div class="col-md-5">
				            <asp:DropDownList ID="ddlAsalParoki" runat="server" AutoPostBack="True">
				            <asp:ListItem Text="Santa Monika" Value="0"></asp:ListItem>
				            <asp:ListItem Text="Bukan Santa Monika" Value="1"></asp:ListItem>
			            </asp:DropDownList>
		                </div>
	                </div>
                </div>

               <div class="input-group-btn">
                    <asp:Button runat="server" Text="Register" CssClass="btn btn-primary" OnClick="button1_Click" />
                </div>
               <%-- End of Form Horizontal --%>
            </div>
            
            
        </ContentTemplate>
    </asp:UpdatePanel>

    

</asp:Content>
