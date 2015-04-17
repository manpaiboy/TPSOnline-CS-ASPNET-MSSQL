<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View_requests.aspx.cs" Inherits="View_requests" %>

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


<!-- View_requests.aspx
    --------------------- Work Log -----------------------
    7/31/14 - JA - Begin coding from scratch
 -->

    <div class="content-header">Requests</div>
    <div class="content" style="text-align:center;">
        <asp:Label ID="lblEvent" runat="server" Text="Event Label"></asp:Label>
    </div>
    <div class="content">
        <asp:Table ID="tblRequest" runat="server" class="blk-border" style="text-align:center;">
        </asp:Table>
    </div>
</asp:Content>

