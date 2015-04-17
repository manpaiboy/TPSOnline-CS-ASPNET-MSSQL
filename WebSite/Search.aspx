<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

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


<!-- Search.aspx
    --------------------- Work Log -----------------------
    8/4/14 - JA - Begin coding from scratch
 -->

     <div class="content-header" style="text-align: left;">Search</div>
    <div class="content">
        <asp:Panel ID="PnlSearch" runat="server" DefaultButton="BtnSearch">
            <asp:TextBox ID="txtSearch" runat="server" class="txt" Width="614px"></asp:TextBox>
            <asp:Button ID="BtnSearch" class="btn btn-primary" runat="server" Text="Search" OnClick="BtnSearch_Click" />
        </asp:Panel>
        <br />
        <asp:Table ID="tblSearch" runat="server" class="blk-border" style="text-align:left;width:100%;margin:auto;">
        </asp:Table>
    </div>
    </asp:Content>

