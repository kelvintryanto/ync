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
	       <div class="column red" style="vertical-align:middle; text-align: center; ">
               <div class="paddingdalam" style="padding-top:35%">
                   <img src="images\rejoice_logo.svg"  width="50%" alt="Alternate Text" />
               </div>
                
	       </div>

            <%-- Start Column 2 Right --%>
           <div class="column blue">
		        <%-- Start Form Horizontal--%>
		        <div class="form-horizontal paddingdalam">
                    <%--judul--%>
                    <div style="text-align: center">
                        <h1>Online Registration</h1>
                        <asp:Label runat="server">* Wajib Diisi</asp:Label>
                    </div>
                    <br />

			        <%-- Nama Lengkap --%>
			        <div class="form-group">
				        <div class="col-md-3">
					        <asp:Label runat="server">Nama Lengkap*</asp:Label>
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
					        <asp:Label runat="server">Tanggal Lahir*</asp:Label>
				        </div>
				        <div class="col-md-5">
					        <asp:TextBox runat="server" ID="txtDOB" />
					        <asp:CalendarExtender ID="txt_CalendarExtender" runat="server"
					        TargetControlID="txtDOB" Format="dd-MMM-yyyy"></asp:CalendarExtender>
					        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDOB"
					        CssClass="field-validation-error" ErrorMessage="Tanggal lahir wajib diisi!" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ErrorMessage="Not a valid Date Format!" ControlToValidate="txtDOB"
                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$">
                            </asp:RegularExpressionValidator>
                        </div>
			        </div>

			        <%-- Nomor HP --%>
			        <div class="form-group">
				        <div class="col-md-3">
					        <asp:Label runat="server">Nomor HP*</asp:Label>
				        </div>
				        <div class="col-md-5">
					        <asp:TextBox runat="server" ID="txtMobilePhone" />
					        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMobilePhone"
					        CssClass="field-validation-error" ErrorMessage="Nomor HP wajib diisi!" />
                            <asp:RegularExpressionValidator ID="revPhone" runat="server"
                                ErrorMessage="Not a valid phone number!" ControlToValidate="txtMobilePhone"
                                ValidationExpression="(\+62 ((\d{3}([ -]\d{3,})([- ]\d{4,})?)|(\d+)))|(\(\d+\) \d+)|\d{3}( \d+)+|(\d+[ -]\d+)|\d+">
                            </asp:RegularExpressionValidator>
                            
                        </div>
			        </div>

			        <%-- Email --%>
			        <div class="form-group">
				        <div class="col-md-3">
					        <asp:Label runat="server">Email*</asp:Label>
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
					        <asp:Label runat="server">Alamat*</asp:Label>
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
			            <div class="col-md-4">
				            <asp:DropDownList ID="ddlAsalParoki" runat="server" AutoPostBack="True" OnSelectedIndexChanged = "ddlAsalParoki_OnSelectedIndexChanged">
				                <asp:ListItem Text="Santa Monika" Value="0"></asp:ListItem>
				                <asp:ListItem Text="Others" Value="1"></asp:ListItem>
			                </asp:DropDownList>
		                </div>
                        <div class="col-md-0" runat="server" id="othersDiv" visible="false">
					        <asp:TextBox runat="server" ID="txtOthers" />
				        </div>
	                </div>
                </div>

               <div class="input-group-btn" style="padding-left: 15px; text-align:center">
                    <asp:Button runat="server" Text="Register" CssClass="btn btn-primary" OnClick="button1_Click" />
                </div>
               <%-- End of Form Horizontal --%>
            </div>
            
            
        </ContentTemplate>
    </asp:UpdatePanel>

    
</asp:Content>

