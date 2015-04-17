<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Find_staff.aspx.cs" Inherits="Find_staff" %>

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


<!-- Find_staff.aspx
    --------------------- Work Log -----------------------
    8/3/14 - JA - Begin coding from scratch
 -->

     <div class="content-header" style="text-align: left;">Find Staff for <asp:Label ID="lblCName" runat="server" Text=""></asp:Label></div>
    <div class="content">
        <asp:Button ID="BtnModifyContract" class="btn btn-primary" runat="server" Text="Modify Contract" /><br /><br />
        <asp:Table ID="tblStaff" runat="server" class="blk-border" style="text-align:center;">
        </asp:Table>
    </div>
</asp:Content>

