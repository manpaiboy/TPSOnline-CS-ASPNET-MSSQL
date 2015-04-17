<%@ Page Title="TPS - User Registration" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

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


<!-- Register.aspx
    --------------------- Work Log -----------------------
    7/20/2014 - JA - Design and Build Registration form
    7/21/2014 - JA - Add validation and encryption code and DB Inserts
    7/22/2014 - JA - Added a panel to allow submitting on user pressing Enter
 -->
    <div class="content-header">User Registration</div>
    <div class="content">
        <asp:Panel ID="PnlRegister" runat="server" DefaultButton="btnRegister">
        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <table>
            <tr>
                <td style="width: 132px; text-align: right;">Account Type:&nbsp;</td>
                <td style="width: 204px"> 
                    <asp:RadioButton ID="RadioStaff" runat="server" AutoPostBack="true" GroupName="RadioAccount" Text="&nbsp;Staff - Looking for Work" OnCheckedChanged="RadioAccount_CheckedChanged" Checked="true" />
                    <br />
                    <asp:RadioButton ID="RadioClient" runat="server" AutoPostBack="true" GroupName="RadioAccount" Text="&nbsp;Client - Looking to Hire" OnCheckedChanged="RadioAccount_CheckedChanged" />
                    <br />
                    <asp:RadioButton ID="RadioManager" runat="server" AutoPostBack="true" GroupName="RadioAccount" Text="&nbsp;Manager - TPS Employee" OnCheckedChanged="RadioAccount_CheckedChanged" />
                </td>
                <td style="width: 558px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 132px; text-align: right;">&nbsp;</td>
                <td style="width: 204px"> 
                    &nbsp;</td>
                <td style="width: 558px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 132px; text-align: right;">
                    <asp:Label ID="lblAdminKey" runat="server" Text="Manager Code:&nbsp;"></asp:Label>
                    </td>
                <td style="width: 204px"> 
                    <asp:TextBox ID="txtAdminKey" runat="server"></asp:TextBox>
                </td>
                <td style="width: 558px">
                    <asp:CustomValidator ID="ManagerCodeValidator" runat="server" ErrorMessage="* Invalid Manager Code" OnServerValidate="checkManagerCode_ServerValidate" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 132px; text-align: right;">Username:&nbsp;</td>
                <td style="width: 204px"> <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
                <td style="width: 558px">
                    <div id="UsernameStatus">
                    <asp:CustomValidator ID="UsernameValidator" runat="server" ErrorMessage="* Username not available" ForeColor="Red" OnServerValidate="UsernameValidator_ServerValidate"></asp:CustomValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 132px; text-align: right; height: 22px;">Password:&nbsp;</td>
                <td style="width: 204px; height: 22px;"><asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox></td>
                <td style="width: 558px; height: 22px;">
                    <asp:Label ID="lblWeak" style="display:none;" runat="server" BackColor="Red" Font-Bold="True" ForeColor="Black" Visible="true" Text="&amp;nbsp;Weak&amp;nbsp;"></asp:Label>
                    <asp:Label ID="lblGood" style="display:none;" runat="server" BackColor="Yellow" Font-Bold="True" ForeColor="Black" Visible="true" Text="&amp;nbsp;Good&amp;nbsp;"></asp:Label>
                    <asp:Label ID="lblStrong" style="display:none;" runat="server" BackColor="#00CC00" Font-Bold="True" ForeColor="Black" Visible="true" Text="&amp;nbsp;Strong&amp;nbsp;"></asp:Label>
                    <asp:CustomValidator ID="PwdStrngthValidator" runat="server" ErrorMessage="* Passwords should contain at least 1 Upper Case letter, 1 Number and no spaces." Font-Bold="False" ForeColor="Red" OnServerValidate="PwdStrngthValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 132px; text-align: right;">Re-type Password:&nbsp;</td>
                <td style="width: 204px"><asp:TextBox ID="txtPwd2" runat="server" TextMode="Password"></asp:TextBox></td>
                <td style="width: 558px">
                    <asp:CustomValidator ID="PwdMatchValidator" runat="server" ErrorMessage="* Passwords do not match" ForeColor="Red" OnServerValidate="PwdMatchValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 132px; text-align: right;">&nbsp;</td>
                <td style="width: 204px">&nbsp;</td>
                <td style="width: 558px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 132px; text-align: right;">First Name:&nbsp;</td>
                <td style="width: 204px"><asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                </td>
                <td style="width: 558px">
                    <asp:CustomValidator ID="FnameValidator" runat="server" ErrorMessage="* This field cannot be empty" ForeColor="Red" OnServerValidate="FnameValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 132px; text-align: right;">Last Name:&nbsp;</td>
                <td style="width: 204px">
        <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
                </td>
                <td style="width: 558px">
                    <asp:CustomValidator ID="LnameValidator" runat="server" ErrorMessage="* This field cannot be empty" ForeColor="Red" OnServerValidate="LnameValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 132px; text-align: right;">Phone:&nbsp;</td>
                <td style="width: 204px">
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>

                </td>
                <td style="width: 558px">
                    <asp:CustomValidator ID="PhoneValidator" runat="server" ErrorMessage="* Invalid phone number - Must be a 10 digit number with no spaces or dashes" ForeColor="Red" OnServerValidate="PhoneValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 132px; text-align: right;">E-Mail:&nbsp;</td>
                <td style="width: 204px">
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td style="width: 558px">
                    <asp:CustomValidator ID="EmailValidator" runat="server" ErrorMessage="* Invalid E-mail address" ForeColor="Red" OnServerValidate="EmailValidator_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 132px; text-align: right;">&nbsp;</td>
                <td style="width: 204px">
                    &nbsp;</td>
                <td style="width: 558px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 132px; text-align: right;">&nbsp;</td>
                <td style="width: 204px">
        <asp:Button ID="BtnRegister" class="btn btn-primary" runat="server" Text="Register" OnClick="BtnRegister_Click" />
                </td>
                <td style="width: 558px">&nbsp;</td>
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

