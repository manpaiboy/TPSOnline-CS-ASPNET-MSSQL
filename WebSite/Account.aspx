<%@ Page Title="TPS - Account Settings" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

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


<!-- Account.aspx
    --------------------- Work Log -----------------------
    7/23/2014 - JA - Modify Register.aspx so this form can be used for updating user information rather than inserting it
 -->
    <div class="content-header">Account Settings</div>
    <div class="content">
        <asp:Panel ID="PnlAccount" runat="server" DefaultButton="btnUpdate" style="text-align: center">
        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <table>
            <tr>
                <td style="width: 198px; text-align: right;">Username:&nbsp;</td>
                <td style="width: 154px"> <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
                <td style="width: 558px; text-align: left;">
                    <div id="UsernameStatus">
                    <asp:CustomValidator ID="UsernameValidator" runat="server" ErrorMessage="* Username not available" ForeColor="Red" OnServerValidate="UsernameValidator_ServerValidate"></asp:CustomValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 198px; text-align: right; height: 22px;">New Password:&nbsp;</td>
                <td style="width: 154px; height: 22px;"><asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox></td>
                <td style="width: 558px; height: 22px; text-align: left;">
                    <asp:Label ID="lblWeak" style="display:none;" runat="server" BackColor="Red" Font-Bold="True" ForeColor="Black" Visible="true" Text="&amp;nbsp;Weak&amp;nbsp;"></asp:Label>
                    <asp:Label ID="lblGood" style="display:none;" runat="server" BackColor="Yellow" Font-Bold="True" ForeColor="Black" Visible="true" Text="&amp;nbsp;Good&amp;nbsp;"></asp:Label>
                    <asp:Label ID="lblStrong" style="display:none;" runat="server" BackColor="#00CC00" Font-Bold="True" ForeColor="Black" Visible="true" Text="&amp;nbsp;Strong&amp;nbsp;"></asp:Label>
                    <asp:CustomValidator ID="PwdStrngthValidator" runat="server" ErrorMessage="* Passwords should contain at least 1 Upper Case letter, 1 Number and no spaces." Font-Bold="False" ForeColor="Red" OnServerValidate="PwdStrngthValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 198px; text-align: right;">Re-type Password:&nbsp;</td>
                <td style="width: 154px"><asp:TextBox ID="txtPwd2" runat="server" TextMode="Password"></asp:TextBox></td>
                <td style="width: 558px; text-align: left;">
                    <asp:CustomValidator ID="PwdMatchValidator" runat="server" ErrorMessage="* Passwords do not match" ForeColor="Red" OnServerValidate="PwdMatchValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 198px; text-align: right; height: 22px;"></td>
                <td style="width: 154px; height: 22px;">
                    <asp:HiddenField ID="HiddenPwd" runat="server" Value="" />
                </td>
                <td style="width: 558px; text-align: left; height: 22px;">
                    <asp:HiddenField ID="HiddenSalt" runat="server" Value="" />
                </td>
            </tr>
            <tr>
                <td style="width: 198px; text-align: right;">First Name:&nbsp;</td>
                <td style="width: 154px"><asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                </td>
                <td style="width: 558px; text-align: left;">
                    <asp:CustomValidator ID="FnameValidator" runat="server" ErrorMessage="* This field cannot be empty" ForeColor="Red" OnServerValidate="FnameValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 198px; text-align: right;">Last Name:&nbsp;</td>
                <td style="width: 154px">
        <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
                </td>
                <td style="width: 558px; text-align: left;">
                    <asp:CustomValidator ID="LnameValidator" runat="server" ErrorMessage="* This field cannot be empty" ForeColor="Red" OnServerValidate="LnameValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 198px; text-align: right;">Phone:&nbsp;</td>
                <td style="width: 154px">
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>

                </td>
                <td style="width: 558px; text-align: left;">
                    <asp:CustomValidator ID="PhoneValidator" runat="server" ErrorMessage="* Invalid phone number - Must be a 10 digit number with no spaces or dashes" ForeColor="Red" OnServerValidate="PhoneValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 198px; text-align: right;">E-Mail:&nbsp;</td>
                <td style="width: 154px">
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td style="width: 558px; text-align: left;">
                    <asp:CustomValidator ID="EmailValidator" runat="server" ErrorMessage="* Invalid E-mail address" ForeColor="Red" OnServerValidate="EmailValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 198px; text-align: right; height: 22px;"></td>
                <td style="width: 154px; height: 22px;">
                    </td>
                <td style="width: 558px; text-align: left; height: 22px;"></td>
            </tr>
            <tr>
                <td style="width: 198px; text-align: right;">&nbsp;</td>
                <td style="width: 154px">
        <asp:Button ID="BtnUpdate" class="btn btn-primary" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
                </td>
                <td style="width: 558px; text-align: left;">&nbsp;</td>
            </tr>
        </table>     
        <br />
        
        <br />
        </asp:Panel>
        </div>

    <script type="text/javascript">

        // Calculates Password strength 
        function strengthCheck(pass) {
            var strength = 0;
            var arr = [/[a-z]+/, /[0-9]+/, /[A-Z]+/];
            jQuery.map(arr, function (regexp) {
                if (pass.match(regexp))
                    strength++;
            });
            // Returns 0-3, Weak-Strong
            return strength;
        }

        // Check Password Strength
        $('#main_txtPwd').keyup(function () {
            $('#main_PwdStrngthValidator').hide();
            var pwd = $('#main_txtPwd').val();
            var strength = strengthCheck(pwd);

            if (pwd.length >= 6 && pwd.indexOf(" ") == -1) { // if password is greater than 8 characters and no spaces

                if (strength >= 3) { // STRONG
                    $('#main_lblWeak').hide();
                    $('#main_lblGood').hide();
                    $('#main_lblStrong').show();
                }
                else if (strength == 2) { // GOOD
                    $('#main_lblWeak').hide();
                    $('#main_lblGood').show();
                    $('#main_lblStrong').hide();
                }
                else { // WEAK
                    $('#main_lblWeak').show();
                    $('#main_lblGood').hide();
                    $('#main_lblStrong').hide();
                }
            }
            else { // WEAK
                $('#main_lblWeak').show();
                $('#main_lblGood').hide();
                $('#main_lblStrong').hide();
            }
        });

    </script>
</asp:Content>

