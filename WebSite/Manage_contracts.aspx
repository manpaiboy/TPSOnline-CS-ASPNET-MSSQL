<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Manage_contracts.aspx.cs" Inherits="Manage_contracts" %>

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


<!-- Manage_contracts.aspx
    --------------------- Work Log -----------------------
    7/28/14 - TB - Begin coding from scratch
    8/2/14 - JA - Make some modifications to TB's code
 -->

     <div class="content-header" style="text-align: left">Manage Contracts</div>
    <div class="content">
        <asp:Button ID="BtnNewContract" class="btn btn-primary" runat="server" Text="+ New Contract" PostBackUrl="~/New_contract.aspx" /><br /><br />
        <asp:Table ID="tblContracts" runat="server" class="blk-border" style="text-align:center;">
        </asp:Table>
    </div>
</asp:Content>

