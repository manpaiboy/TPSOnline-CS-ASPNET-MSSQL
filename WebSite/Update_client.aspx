<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Update_client.aspx.cs" Inherits="Update_client" %>

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


<!-- Update_client.aspx
    --------------------- Work Log -----------------------
    7/30/2014 - JA - Setup form fields and code
 -->
    <div class="content-header">
        Company Information
    </div>
    <div class="content">
        <asp:Panel ID="PnlAccount" runat="server" DefaultButton="btnUpdate" style="text-align: center">
            <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>


            <br />
            <br />
            <table>
                <tr>
                    <td style="width: 376px; text-align: right">Company Name:&nbsp;</td>
                    <td style="width: 142px">
                        <asp:TextBox ID="TxtCompany" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 308px; text-align: left;">
                        <asp:RequiredFieldValidator ID="CoNameValidator" runat="server" ErrorMessage="&amp;nbsp;* Required" ForeColor="Red" style="text-align: left" ControlToValidate="TxtCompany"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 376px">&nbsp;</td>
                    <td style="width: 142px">&nbsp;</td>
                    <td style="width: 308px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 376px">&nbsp;</td>
                    <td style="width: 142px">
                        <asp:Button ID="BtnUpdate" class="btn btn-primary" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
                    </td>
                    <td style="width: 308px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 376px">&nbsp;</td>
                    <td style="width: 142px">&nbsp;</td>
                    <td style="width: 308px">&nbsp;</td>
                </tr>
            </table>


        </asp:Panel>
    </div>
</asp:Content>

