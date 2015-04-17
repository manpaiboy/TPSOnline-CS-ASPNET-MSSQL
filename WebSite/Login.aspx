<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

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


<!-- Login.aspx
    --------------------- Work Log -----------------------
    7/22/2014 - JA - Added user authentication forms and validation code
 -->
    <div class="content-header">User Authorization</div>
    <div class="content" style="text-align: center">

        <asp:Panel ID="PnlLogin" runat="server" DefaultButton="btnLogin">
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        <table>
            <tr>
                <!-- Username form field -->
                <td style="text-align: right; width: 468px">Username:&nbsp;</td>
                <td style="width: 148px">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
                <td style="width: 478px; text-align: left;">
                    &nbsp;</td>
            </tr>
            <tr>
                <!-- Password form field -->
                <td style="text-align: right; width: 468px">Password:&nbsp;</td>
                <td style="width: 148px">
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td style="width: 478px; text-align: left;">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 468px">&nbsp;</td>
                <td style="width: 148px">
                    &nbsp;</td>
                <td style="width: 478px">&nbsp;</td>
            </tr>
            <tr>
                <!-- Login Button -->
                <td style="width: 468px">&nbsp;</td>
                <td style="width: 148px">
                    <asp:Button ID="BtnLogin" runat="server" class="btn btn-primary" OnClick="BtnLogin_Click" Text="Login" />
                </td>
                <td style="width: 478px">&nbsp;</td>
            </tr>
        </table>
        </asp:Panel>

    </div>
</asp:Content>

