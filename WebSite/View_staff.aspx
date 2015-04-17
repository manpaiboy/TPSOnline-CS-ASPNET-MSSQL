<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View_staff.aspx.cs" Inherits="View_Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <!--
    DeVry Senior Project
    CIS 470
    Team C
    Jeremy Adams
    Taunyl Bailey
    Tim Olson
    Rachel Spiegelhoff
    -->


<!-- View_staff.aspx
    --------------------- Work Log -----------------------
    7/30/14 - JA - Setup layout and code
    7/31/14 - JA - Added code to check if staff member or max # of staff has already been requested
 -->
    
    <div class="content-header">
        <asp:Label ID="lblName" runat="server" Text="Error"></asp:Label>
    </div>
    <div class="content" style="text-align:center;"><asp:Label ID="lblError" runat="server" Text=""></asp:Label></div>
    <asp:Panel ID="PnlViewStaff" runat="server" style="text-align: center">
        <div class="content float-left" style="text-align:left;">
            <div class="mini-content float-left">
                <asp:Image ID="ImgPic" runat="server" ImageUrl="~/images/male_avatar.jpg" />
                <br />
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tpsonlineConnectionString %>" SelectCommand="SELECT [contractid], [cname] FROM [contract] WHERE (([status] = @status) AND ([userid] = @userid))">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="status" Type="Int32" />
                        <asp:SessionParameter Name="userid" SessionField="userid" Type="Int64" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <asp:DropDownList ID="Dd_Client_Contracts" runat="server" DataSourceID="SqlDataSource1" DataTextField="cname" DataValueField="contractid">
                </asp:DropDownList>
                <asp:Button ID="Btn_Client_Request" class="btn btn-primary" runat="server" OnClick="Btn_Client_Request_Click" Text="Request" />
                <br />
                <asp:Button ID="Btn_admin_SetActive" class="btn btn-primary" runat="server" OnClick="Btn_admin_SetActive_Click" Text="Set as Active" />
                <asp:Button ID="Btn_admin_SetInactive" class="btn btn-primary" runat="server" OnClick="Btn_admin_SetInactive_Click" Text="Set as Inactive" />
            </div>
            <div class="float-left" style="width:350px;overflow-x:visible;white-space:nowrap;">
                <div class="mini-header float-left">Contact Info</div>
                <div class="mini-content float-left">
                    <div class="float-left" style="width:100px;text-align:right;font-weight:bold;">Phone:&nbsp;</div><asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label><br />
                    <div class="float-left" style="width:100px;text-align:right;font-weight:bold;">E-Mail:&nbsp;</div><asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </div>
                <div class="mini-header float-left">Details</div>
                <div class="mini-content float-left">
                    <div class="float-left" style="width:100px;text-align:right;font-weight:bold;">Field:&nbsp;</div><asp:Label ID="lblField" runat="server" Text="Job"></asp:Label><br />
                    <div class="float-left" style="width:100px;text-align:right;font-weight:bold;">Education:&nbsp;</div><asp:Label ID="lblEdu" runat="server" Text="Edu"></asp:Label><br />
                    <div class="float-left" style="width:100px;text-align:right;font-weight:bold;">Experience:&nbsp;</div><asp:Label ID="lblExp" runat="server" Text="Exp"></asp:Label><br />
                    <div class="float-left" style="width:100px;text-align:right;font-weight:bold;">Salary Range:&nbsp;</div><asp:Label ID="lblSal" runat="server" Text="Sal"></asp:Label><br />
                    <div class="float-left" style="width:100px;text-align:right;font-weight:bold;">Zipcode:&nbsp;</div><asp:Label ID="lblZip" runat="server" Text="Zip"></asp:Label>
                </div>
            </div>
        </div>
        <div class="float-clear"></div>
        <div class="content-header" style="text-align:left;">Resume</div>
        <div class="content" style="text-align:left;">
            <asp:Label ID="lblResume" runat="server" Text="Resume"></asp:Label>
        </div>
    </asp:Panel>
</asp:Content>

